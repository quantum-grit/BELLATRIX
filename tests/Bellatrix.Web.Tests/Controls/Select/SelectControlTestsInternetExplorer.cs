﻿// <copyright file="SelectControlTestsInternetExplorer.cs" company="Automate The Planet Ltd.">
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
    [AllureSuite("Select Control")]
    public class SelectControlTestsInternetExplorer : MSTest.WebTest
    {
        public override void TestInit() => App.NavigationService.NavigateToLocalPage(ConfigurationService.GetSection<TestPagesSettings>().SelectLocalPage);

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void SelectByTextToAwesome_When_UseSelectByTextMethod_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect");

            selectElement.SelectByText("Awesome");

            Assert.AreEqual("bella2", selectElement.GetSelected().Value);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void SelectByIndexToAwesome_When_UseSelectByTextMethod_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect");

            selectElement.SelectByIndex(2);

            Assert.AreEqual("bella2", selectElement.GetSelected().Value);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnAwesome_When_UseGetSelectedValueMethod_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect2");

            Assert.AreEqual("bella2", selectElement.GetSelected().Value);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnRed_When_Hover_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect1");

            selectElement.Hover();

            Assert.AreEqual("color: red;", selectElement.GetStyle());
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnBlue_When_Focus_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect2");

            selectElement.Focus();

            Assert.AreEqual("color: blue;", selectElement.GetStyle());
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnFalse_When_DisabledAttributeNotPresent_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect");

            bool isDisabled = selectElement.IsDisabled;

            Assert.IsFalse(isDisabled);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnTrue_When_DisabledAttributePresent_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect3");

            bool isDisabled = selectElement.IsDisabled;

            Assert.IsTrue(isDisabled);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnTrue_When_RequiredAttributePresent_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect4");

            var actualValue = selectElement.IsRequired;

            Assert.IsTrue(actualValue);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void ReturnFalse_When_RequiredAttributeNotPresent_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect");

            var actualValue = selectElement.IsRequired;

            Assert.IsFalse(actualValue);
        }

        [TestMethod]
        [Ignore, TestCategory(Categories.InternetExplorer), TestCategory(Categories.Windows)]
        public void Return3Options_When_GetAllOptions_InternetExplorer()
        {
            var selectElement = App.ElementCreateService.CreateById<Select>("mySelect");

            var allOptions = selectElement.GetAllOptions();

            Assert.AreEqual(3, allOptions.Count);
        }
    }
}