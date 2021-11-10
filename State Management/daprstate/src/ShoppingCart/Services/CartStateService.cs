using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.JsonPatch;
using ShoppingCart.Content.Activities.Cart.Post.Models;
using ShoppingCart.Content.Exceptions;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class CartStateService : IService<Item>
    {
        private const string DAPR_STORE_NAME = "cart-service";
        private readonly DaprClient _client;

        public CartStateService(DaprClient client)
        {
            _client = client;
        }

        public async Task<List<Item>> Update(string session, JsonPatchDocument<List<Item>> items,  CancellationToken cancellationToken)
        {
            var (currentItems, etag) = await _client.GetStateAndETagAsync<List<Item>>(DAPR_STORE_NAME, session, cancellationToken: cancellationToken);
            items.ApplyTo(currentItems);
            await _client.TrySaveStateAsync(DAPR_STORE_NAME, session, currentItems, etag, cancellationToken: cancellationToken);
            return currentItems;
        }
        public async Task<bool> Save(string session, List<Item> entity,  CancellationToken cancellationToken)
       {
           var stateEntry = await _client.GetStateEntryAsync<List<Item>>(DAPR_STORE_NAME, session, default, cancellationToken: cancellationToken);
           if (stateEntry.Value is not null) return true;
           await _client.SaveStateAsync(DAPR_STORE_NAME, session, entity, cancellationToken: cancellationToken);
           return false;

       }

       public async Task<List<Item>>Get(string session,  CancellationToken cancellationToken)
       {
          return await _client.GetStateAsync<List<Item>>(DAPR_STORE_NAME, session, ConsistencyMode.Strong, cancellationToken: cancellationToken);

       }

      
    }
}