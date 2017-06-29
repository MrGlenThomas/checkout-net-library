namespace Checkout.ApiServices.ShoppingList
{
    using RequestModels;
    using ResponseModels;
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

        /// <summary>
        /// Gets all drinks from the shopping list
        /// </summary>
        public HttpResponse<ShoppingListDrinks> GetDrinks(GetDrinks requestModel)
        {
            return new ApiHttpClient().PostRequest<ShoppingListDrinks>(ApiUrls.GetDrinks, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Gets a drink from the shopping list by name.
        /// </summary>
        public HttpResponse<ShoppingListDrink> GetDrink(GetDrink requestModel)
        {
            return new ApiHttpClient().PostRequest<ShoppingListDrink>(ApiUrls.GetDrink, AppSettings.SecretKey, requestModel);
        }
    }
}
