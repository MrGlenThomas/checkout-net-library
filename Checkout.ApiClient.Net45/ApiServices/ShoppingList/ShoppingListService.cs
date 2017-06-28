namespace Checkout.ApiServices.ShoppingList
{
    using RequestModels;
    using SharedModels;

    public class ShoppingListService
    {
        /// <summary>
        /// Adds a drink to the shopping list.
        /// </summary>
        public HttpResponse<object> AddDrink(AddDrink requestModel)
        {
            return new ApiHttpClient().PostRequest<object>(ApiUrls.AddDrink, AppSettings.SecretKey, requestModel);
        }
    }
}
