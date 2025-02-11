﻿// <copyright file="UntilExist.cs" company="Automate The Planet Ltd.">
// Copyright 2021 Automate The Planet Ltd.
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
using System;
using OpenQA.Selenium;

namespace Bellatrix.Web.Untils
{
    public class WaitToExistStrategy : WaitStrategy
    {
        public WaitToExistStrategy(int? timeoutInterval = null, int? sleepInterval = null)
            : base(timeoutInterval, sleepInterval)
        {
            TimeoutInterval = timeoutInterval ?? ConfigurationService.GetSection<WebSettings>().TimeoutSettings.ElementToExistTimeout;
        }

        public override void WaitUntil<TBy>(TBy by)
        {
            WaitUntil(d => ElementExists(WrappedWebDriver, by), TimeoutInterval, SleepInterval);
        }

        public override void WaitUntil<TBy>(TBy by, Component parent)
        {
            WaitUntil(d => ElementExists(parent.WrappedElement, by), TimeoutInterval, SleepInterval);
        }

        private bool ElementExists<TBy>(ISearchContext searchContext, TBy by)
            where TBy : FindStrategy
        {
            try
            {
                var element = searchContext.FindElement(by.Convert());
                return element != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}