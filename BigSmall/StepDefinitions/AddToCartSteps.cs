using BigSmall.CommonMethodObjects;
using System;
using TechTalk.SpecFlow;

namespace BigSmall.StepDefinitions
{
    [Binding]
    public class AddToCartSteps
    {
        AddToCartObjects obj = new AddToCartObjects();
        SearchProductObjects obj1 = new SearchProductObjects();
        WishListObjects obj2 = new WishListObjects();

        [When(@"User searches for an item and selects an item")]
        public void WhenUserSearchesForAnItemAndSelectsAnItem()
        {
            obj1.EnterProductToSearch();
            obj2.selectItem();
        }

        [When(@"User clicks on Add to Cart")]
        public void WhenUserClicksOnAddToCart()
        {
            obj.AddItemToCart();
        }

        [Then(@"User should be able to view the item in shopping cart")]
        public void ThenUserShouldBeAbleToViewTheItemInShoppingCart()
        {
            obj.VerifyCartItem();
        }
    }
}
