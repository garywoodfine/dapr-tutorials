using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.JsonPatch;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class CartStateService : IService<Item>
    {
        private const string DAPR_STORE_NAME = "cart";
        private readonly DaprClient _client;

        public CartStateService(DaprClient client)
        {
            _client = client;
        }


        public async Task<List<Item>> Update(string session, JsonPatchDocument<List<Item>> items)
        {
            var currentItems = await Get(session);
            items.ApplyTo(currentItems);
            Save(session, currentItems);
            
            return currentItems;
        }

        public async Task Save(string session, List<Item> entity)
       {
           await  _client.SaveStateAsync(DAPR_STORE_NAME, session , entity);
       }

       public async Task<List<Item>>Get(string session)
       {
           return  await _client.GetStateAsync<List<Item>>(DAPR_STORE_NAME, session);
       }
    }
}