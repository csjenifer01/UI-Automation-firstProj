using BigSmall.CommonMethodObjects;
using System;
using TechTalk.SpecFlow;

namespace BigSmall.StepDefinitions
{
    [Binding]
    public class SearchProductSteps
    {
        SearchProductObjects obj = new SearchProductObjects();

        [When(@"User enters product name in search bar and User press Enter")]
        public void WhenUserEntersProductNameInSearchBarAndUserPressEnter()
        {
            obj.EnterProductToSearch();
        }


        [Then(@"Products related the searched product should be displayed")]
        public void ThenProductsRelatedTheSearchedProductShouldBeDisplayed()
        {
            obj.VerifyProductSearch();
        }
    }
}
