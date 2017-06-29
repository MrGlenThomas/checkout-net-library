using System.Collections.Generic;
using Checkout.ApiServices.ShoppingList.RequestModels;

namespace Checkout.ApiServices.ShoppingList.ResponseModels
{
    public class ShoppingListDrinks
    {
        public IEnumerable<ShoppingListDrink> Drinks { get; set; }
    }
}
