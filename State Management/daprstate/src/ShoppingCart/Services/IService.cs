using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public interface IService<T> where T : class
    {
        Task<List<T>> Update(string session, JsonPatchDocument<List<T>> items);
        Task Save(string session, List<T> entity);
        Task<List<T>> Get(string session);
    }
}