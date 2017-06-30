namespace Checkout.ApiServices.ShoppingList
{
    using RequestModels;
    using ResponseModels;
    using SharedModels;
    using Utilities;

    public class ShoppingListService
    {
        /// <summary>
        /// Adds a drink to the shopping list.
        /// </summary>
        public HttpResponse<OkResponse> AddDrink(AddDrink requestModel)
        {
            return new ApiHttpClient().PostRequest<OkResponse>(ApiUrls.AddDrink, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Get all drinks from the shopping list
        /// </summary>
        public HttpResponse<ShoppingListDrinks> GetDrinks(GetDrinks requestModel)
        {
            var getDrinksUri = ApiUrls.GetDrinks;

            if (requestModel.PageSize.HasValue)
            {
                getDrinksUri = UrlHelper.AddParameterToUrl(getDrinksUri, "pageSize", requestModel.PageSize);
            }

            if (requestModel.Page.HasValue)
            {
                getDrinksUri = UrlHelper.AddParameterToUrl(getDrinksUri, "page", requestModel.Page);
            }

            return new ApiHttpClient().GetRequest<ShoppingListDrinks>(getDrinksUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Get a drink from the shopping list by name.
        /// </summary>
        public HttpResponse<ShoppingListDrink> GetDrink(GetDrink requestModel)
        {
            return new ApiHttpClient().PostRequest<ShoppingListDrink>(string.Format(ApiUrls.GetDrink, requestModel.DrinkName), AppSettings.SecretKey);
        }

        /// <summary>
        /// Get a drink from the shopping list by name.
        /// </summary>
        public HttpResponse<OkResponse> UpdateDrink(UpdateDrink requestModel)
        {
            return new ApiHttpClient().PostRequest<OkResponse>(string.Format(ApiUrls.UpdateDrink, requestModel.DrinkName), AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Delete a drink from the shopping list by name.
        /// </summary>
        public HttpResponse<OkResponse> DeleteDrink(DeleteDrink requestModel)
        {
            return new ApiHttpClient().PostRequest<OkResponse>(string.Format(ApiUrls.DeleteDrink, requestModel.DrinkName), AppSettings.SecretKey);
        }
    }
}
