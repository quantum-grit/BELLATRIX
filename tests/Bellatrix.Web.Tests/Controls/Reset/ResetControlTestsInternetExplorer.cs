﻿// <copyright file="ResetControlTestsInternetExplorer.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Web.Tests.Controls
{
    [TestClass]
    [Browser(BrowserType.InternetExplorer, Lifecycle.ReuseIfStarted)]
    [AllureSuite("Reset Control")]
    public class ResetControlTestsInternetExplorer : MSTest.WebTest
    {
        public override void TestInit() => App.NavigationService.NavigateToLocalPage(ConfigurationService.GetSection<TestPagesSettings>().ResetLocalPage);

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void SetTextToStop_When_UseClickMethod_InternetExplorer()
        {
            var buttonElement = App.ElementCreateService.CreateById<Reset>("myButton");

            buttonElement.Click();

            Assert.AreEqual("Stop", buttonElement.Value);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnRed_When_Hover_InternetExplorer()
        {
            var buttonElement = App.ElementCreateService.CreateById<Reset>("myButton1");

            buttonElement.Hover();

            Assert.AreEqual("color: red;", buttonElement.GetStyle());
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnBlue_When_Focus_InternetExplorer()
        {
            var buttonElement = App.ElementCreateService.CreateById<Reset>("myButton2");

            buttonElement.Focus();

            Assert.AreEqual("color: blue;", buttonElement.GetStyle());
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnFalse_When_DisabledAttributeNotPresent_InternetExplorer()
        {
            var buttonElement = App.ElementCreateService.CreateById<Reset>("myButton");

            bool isDisabled = buttonElement.IsDisabled;

            Assert.IsFalse(isDisabled);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnTrue_When_DisabledAttributePresent_InternetExplorer()
        {
            var buttonElement = App.ElementCreateService.CreateById<Reset>("myButton3");

            bool isDisabled = buttonElement.IsDisabled;

            Assert.IsTrue(isDisabled);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnStart_When_ValueAttributePresent_InternetExplorer()
        {
            var buttonElement = App.ElementCreateService.CreateById<Reset>("myButton");

            var actualValue = buttonElement.Value;

            Assert.AreEqual("Start", actualValue);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnEmpty_When_UseInnerText_InternetExplorer()
        {
            var buttonElement = App.ElementCreateService.CreateById<Reset>("myButton");

            Assert.AreEqual(string.Empty, buttonElement.InnerText);
        }
    }
}