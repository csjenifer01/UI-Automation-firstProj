using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Gherkin.Ast;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Feature = AventStack.ExtentReports.Gherkin.Model.Feature;
using Scenario = AventStack.ExtentReports.Gherkin.Model.Scenario;

namespace project1.Utilities
{
    [Binding]
    public class BaseClass
    {
        public static ExtentReports extents;
        public static ExtentTest feature;
        public static ExtentTest scenario;


        public static IWebDriver driver;
        public static object scenarioContext;

        [BeforeFeature]
        public static void featureBrowser(FeatureContext featureContext)
        {
            feature = extents.CreateTest<Feature>(featureContext.FeatureInfo.Title);

        }
        [BeforeScenario]
        public void launchbrowser(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        [AfterScenario]
        public static void CleanUP()
        {
            driver.Quit();
        }
        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporte = new ExtentHtmlReporter(@"C:\Users\mindtreejanedge225\Documents\BigSmall\BigSmall\index.html");
            htmlReporte.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extents = new ExtentReports();
            extents.AttachReporter(htmlReporte);
        }

        [AfterTestRun]
        public static void CloseExtentReport()

        {

            extents.Flush();
        }

        [BeforeScenario]
        public static void Initialise(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bigsmall.in");
        }

        [AfterStep]

        public static void InsertReportingStep(ScenarioContext scenarioContext)
        {

            if (scenarioContext.TestError == null)
            {

                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);

                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);

                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }

            if (scenarioContext.TestError != null)
            {
                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")

                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (stepType == "When")

                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);

            }
        }
    }
}









