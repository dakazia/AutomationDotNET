using System;
using AutomationFramework.PageObjects;
using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    internal class GoogleCalculatorTest : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            CalculatorPage.OpenPage();
            CalculatorPage.SwitchToFrame(CalculatorPage.FrameCalculator);
            CalculatorPage.SwitchToFrame(CalculatorPage.FrameInsideFrameCalculator);
        }

        [Test]
        public void VerifyEnablingButtons()
        {

            var instanceArea = CalculatorPage.CalculatorPart.InstancesArea;

            instanceArea.Instances.SendKeys(two);
            CalculatorPage.CalculatorPart.SelectItem(instanceArea.Series, SeriesN2);
            CalculatorPage.CalculatorPart.SelectItem(instanceArea.MachineType, N2Standard4);
            CalculatorPage.CalculatorPart.SelectItem(instanceArea.DataCenterLocation, BelgiumLocation);

            Assert.IsTrue(instanceArea.AddToEstimateButton.Enabled, "Add to Estimate button isn't enabled");

            instanceArea.AddToEstimateButton.Click();

            var soleTenantArea = CalculatorPage.CalculatorPart.SoleTenantNodesArea;

            CalculatorPage.CalculatorPart.SoleTenantNodesArea.NumberOfNodes.SendKeys(two);
            CalculatorPage.CalculatorPart.SoleTenantNodesArea.AddGpuCheckbox.Click();

            Wait.For(() => soleTenantArea.GpuType.Displayed, 3000);
            CalculatorPage.CalculatorPart.SelectItem(soleTenantArea.GpuType, NVIDIATeslaV100);
            CalculatorPage.CalculatorPart.SelectItem(soleTenantArea.GpuNumber, eight);

            Assert.IsTrue(CalculatorPage.CalculatorPart.SoleTenantNodesArea.AddToEstimateButton.Enabled, "Add to Estimate button isn't enabled");
            CalculatorPage.CalculatorPart.SoleTenantNodesArea.AddToEstimateButton.Click();



            Thread.Sleep(3000);
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
