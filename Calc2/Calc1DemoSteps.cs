using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calc2
{
    [Binding]
    public class Calc1DemoSteps
    {
        private Window _mainWindow;


        
        private string ConvertToName(string s)
        {

            if (s == "+")
            {
                return "Add";
            }
           
            if (s == ",")
            {
                return "Decimal separator";
            }

            if (s == "-")
            {
                return "Subtract";
            }

            if (s == "*")
            {
                return "Multiply";
            }

            if (s == "/")
            {
                return "Divide";
            }
            return s;

            }
        

        [Given(@"I have opened calculator")]
        public void GivenIHaveOpenedCalculator()
        {
            var app = Application.Launch("calc.exe");
             _mainWindow = app.GetWindow("Calculator");
            
        }

        [After]
        public void CloseCalculator()
        {
            _mainWindow.Close();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string p0)
        {
            decimal dummy;
            // if it's not a number, find the whole button name...
            if (!decimal.TryParse(p0,out dummy))
            {

                var button = _mainWindow.Get<Button>(ConvertToName(p0));
                //var criteria = SearchCriteria.ByClassName("Button");
                //var button = _mainWindow.GetMultiple(criteria);
                button.Click();
            }
            else
            {
                // it is a number, press each digit seperately....
                foreach (var number in p0)
                {
                    var button = _mainWindow.Get<Button>(ConvertToName(number.ToString()));
                    //var criteria = SearchCriteria.ByClassName("Button");
                    //var button = _mainWindow.GetMultiple(criteria);
                    button.Click();
                }
            }   
        }       

        [When(@"I press (.*)")]
        public void WhenIPressEquals(string p0)
        {
            
           //var criteria = SearchCriteria.ByClassName("Button");
            //var button = _mainWindow.GetMultiple(criteria);
            var button = _mainWindow.Get<Button>(ConvertToName(p0));
            button.Click();
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string p0)
        {

            // find this window....
            //var criteria = SearchCriteria.ByClassName("Static");
            //var display = _mainWindow.GetMultiple(criteria);

            var criteria = SearchCriteria.ByAutomationId("150");
            var display = _mainWindow.Get(criteria);
            Assert.AreEqual(display.Name, p0);

            // read the text.
            // Assert text == p0;
            // ScenarioContext.Current.Pending();
        }
    }
}
