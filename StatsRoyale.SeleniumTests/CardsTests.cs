using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StatsRoyale.SeleniumFramework.Pages;

namespace StatsRoyale.SeleniumTests
{
    [TestClass]
    public class CardsTests
    {
        //this is a global variable in which all test methods in this class can use.
        IWebDriver driver;
        [TestMethod]
        public void AssertIceSpiritCardIsOnCardPage()
        {
            //use our Page Map Pattern Classes

            CardsPage _cardsPage = new CardsPage(driver);
            _cardsPage.GoTo();
            var card = _cardsPage.GetCardByCardName("Ice Spirit");
            Assert.IsTrue(card.Displayed);
        }

        [TestMethod]
        public void AssertIceSpiritCardStatsOnDetailsPage()
        {

            CardsPage _cardsPage = new CardsPage(driver);
            _cardsPage.GoTo();
            _cardsPage.GetCardByCardName("Ice Spirit").Click();
            CardDetailsPage _cardDetailsPage = new CardDetailsPage(driver);
            var cardRarity = _cardDetailsPage.GetCardRarity().Text.Split(',');

            Assert.AreEqual("Troop", cardRarity[0]);
            Assert.AreEqual("Arena 8", cardRarity[1].Trim());


        }

        [TestInitialize]
        public void Setup()
        {
            //Created a chrome driver and launches chrome
            driver = new ChromeDriver();
            //This will expand the chrome window
            driver.Manage().Window.Maximize();
            //Navigate to the website
            driver.Navigate().GoToUrl("https://statsroyale.com/");

        }

        [TestCleanup]
        public void Teardown()
        {
            //Close all chrome tabs
            driver.Quit();
        }
        
    }
}
