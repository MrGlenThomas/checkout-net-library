using System.Linq;
using System.Net;
using Checkout.ApiServices.ShoppingList.RequestModels;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.ShoppingListService
{
    [TestFixture]
    class ShoppingListServiceTests : BaseServiceTests
    {
        [Test]
        public void AddDrinkDoesntAllowDuplicate()
        {
            var name = "TestDrink1";
            var quantity = 100;

            var drinkCreateModel = TestHelper.GetDrinksCreateModel(name, quantity);

            var response1 = CheckoutClient.ShoppingListService.AddDrink(drinkCreateModel);

            response1.Should().NotBeNull();
            response1.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var response2 = CheckoutClient.ShoppingListService.AddDrink(drinkCreateModel);

            response2.Should().NotBeNull();
            response2.HttpStatusCode.Should().Be(HttpStatusCode.Conflict);
        }

        [Test]
        public void GetDrinks()
        {
            var name = "TestDrink1";
            var quantity = 100;

            var drinkCreateModel = TestHelper.GetDrinksCreateModel(name, quantity);
            CheckoutClient.ShoppingListService.AddDrink(drinkCreateModel);

            var response = CheckoutClient.ShoppingListService.GetDrinks(new GetDrinks());

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Drinks.Count().Should().Be(1);
            response.Model.Drinks.Single().DrinkName.Should().BeEquivalentTo(name);
            response.Model.Drinks.Single().Quantity.Should().Be(quantity);
        }

        [Test]
        public void GetDrink()
        {
            var name = "TestDrink1";
            var quantity = 100;

            var drinkCreateModel = TestHelper.GetDrinksCreateModel(name, quantity);
            CheckoutClient.ShoppingListService.AddDrink(drinkCreateModel);

            var getDrinkModel = TestHelper.GetDrinkByNameModel(name);

            var response = CheckoutClient.ShoppingListService.GetDrink(getDrinkModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.DrinkName.Should().BeEquivalentTo(name);
            response.Model.Quantity.Should().Be(quantity);
        }

        [Test]
        public void UpdateDrink()
        {
            var name = "TestDrink1";
            var initialQuantity = 100;
            var updatedQuantity = 500;

            var drinkCreateModel = TestHelper.GetDrinksCreateModel(name, initialQuantity);
            CheckoutClient.ShoppingListService.AddDrink(drinkCreateModel);

            var getDrinkModel = TestHelper.GetDrinkByNameModel(name);

            var getDrinkInitialResponse = CheckoutClient.ShoppingListService.GetDrink(getDrinkModel);

            getDrinkInitialResponse.Should().NotBeNull();
            getDrinkInitialResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getDrinkInitialResponse.Model.DrinkName.Should().BeEquivalentTo(name);
            getDrinkInitialResponse.Model.Quantity.Should().Be(initialQuantity);

            var updateDrinkModel = TestHelper.GetDrinksUpdateModel(name, updatedQuantity);

            var updateDrinkResponse = CheckoutClient.ShoppingListService.UpdateDrink(updateDrinkModel);

            updateDrinkResponse.Should().NotBeNull();
            updateDrinkResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var getDrinkUpdatedResponse = CheckoutClient.ShoppingListService.GetDrink(getDrinkModel);

            getDrinkUpdatedResponse.Should().NotBeNull();
            getDrinkUpdatedResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getDrinkUpdatedResponse.Model.DrinkName.Should().BeEquivalentTo(name);
            getDrinkUpdatedResponse.Model.Quantity.Should().Be(updatedQuantity);
        }

        [Test]
        public void DeleteDrink()
        {
            var name = "TestDrink1";
            var quantity = 100;


            var drinkCreateModel = TestHelper.GetDrinksCreateModel(name, quantity);
            CheckoutClient.ShoppingListService.AddDrink(drinkCreateModel);

            var getDrinkModel = TestHelper.GetDrinkByNameModel(name);

            var getDrinkInitialResponse = CheckoutClient.ShoppingListService.GetDrink(getDrinkModel);

            getDrinkInitialResponse.Should().NotBeNull();
            getDrinkInitialResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getDrinkInitialResponse.Model.DrinkName.Should().BeEquivalentTo(name);
            getDrinkInitialResponse.Model.Quantity.Should().Be(quantity);

            var deleteDrinkModel = TestHelper.GetDeleteDrinkModel(name);

            var deleteDrinkResponse = CheckoutClient.ShoppingListService.DeleteDrink(deleteDrinkModel);

            deleteDrinkResponse.Should().NotBeNull();
            deleteDrinkResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var getDrinkUpdatedResponse = CheckoutClient.ShoppingListService.GetDrink(getDrinkModel);

            getDrinkUpdatedResponse.Should().NotBeNull();
            getDrinkUpdatedResponse.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
