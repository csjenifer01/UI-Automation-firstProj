using BigSmall.CommonMethodObjects;
using System;
using TechTalk.SpecFlow;

namespace BigSmall.StepDefinitions
{
    [Binding]
    public class WishListSteps
    {
        public class WishListStepDefinitions
        {
            WishListObjects obj = new WishListObjects();
            SearchProductObjects obj1 = new SearchProductObjects();

            [When(@"User searches a valid product and User press Enter")]
            public void WhenUserSearchesAValidProductAndUserPressEnter()
            {
                obj1.EnterProductToSearch();
            }

            [When(@"User selects the item")]
            public void WhenUserSelectsTheItem()
            {
                obj.selectItem();
            }

            [When(@"User clicks on add to wishlist")]
            public void WhenUserClicksOnAddToWishlist()
            {
                obj.AddToWishlist();
            }

            [When(@"User clicks on wish list")]
            public void WhenUserClicksOnWishList()
            {
                obj.ClickWishList();
            }

            [Then(@"User should be able to view the item added to the wish list")]
            public void ThenUserShouldBeAbleToViewTheItemAddedToTheWishList()
            {
                obj.VerifyWishlistItem();
            }
        }
    }
}
