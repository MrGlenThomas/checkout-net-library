namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    //TODO: Inherit from BasePagination?
    public class GetDrinks
    {
        public int? PageSize { get; set; }

        public int? Page { get; set; }
    }
}
