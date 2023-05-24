﻿using EuroVaistineFramework;
using EuroVaistineFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace EuroVaistineTests.EuroVaistineScenarios
{
    internal class LogIn 
    {
        [SetUp]
        public void SetUp()
        {
            Driver.InitializeDriver();
            EuroVaistineMainPage.Open();
        }

        [Test]
        public void LogInWithInvalidCredentials()
        {
            string email = "test@test.com";
            string slaptazodis = "test";
            string expectedResult = "Pašto adresas nerastas. Prašome įvesti teisingą el. pašto adresą";

            EuroVaistineShoppingCart.ClickOnAdvertButton();
            EuroVaistineShoppingCart.ClickOnSlapukai();
            EuroVaistineMainPage.ClickButtonPrisijungti();
            EuroVaistineMainPage.EnterElektroninisPastas(email);
            EuroVaistineMainPage.EnterSlaptazodis(slaptazodis);
            EuroVaistineMainPage.ClickButtonPrisijungtiZalias();
           
            string actualResult  = EuroVaistineMainPage.GetAlertMessage(); 

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenshotFilePath = Driver.TakeScreenshot(TestContext.CurrentContext.Test.MethodName);
                TestContext.AddTestAttachment(screenshotFilePath);
            }

            Driver.ShutdownDriver();
        }
    }
}
