using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    public class CardDetailsPage : BasePage
    {
        public IWebDriver _driver;
        public CardDetailsPageMap _CardDetailsPageMap;
        public CardDetailsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _CardDetailsPageMap = new CardDetailsPageMap(_driver);
        }

        public IWebElement GetCardRarity()
        {
            return _CardDetailsPageMap.CardRarity;
        }
    }
    public class CardDetailsPageMap
    {
        public IWebDriver _driver;
        public CardDetailsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardRarity => _driver.FindElement(By.CssSelector("div[class='card__rarity']"));
    }
}
