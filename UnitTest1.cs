using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Easy_Test_C_sharp
{
    public class Tests
    {
        IWebDriver driver;
        string titleOfMainPage = "Learn Selenium with Best Practices and Examples | Selenium Easy";
        string urlOfPage = "https://www.seleniumeasy.com/";
        string expectedUrlOfSearchFieldTest = "https://www.seleniumeasy.com/search/node/selenium";
        string expectedUrlOfGUITest = "https://www.seleniumeasy.com/selenium-tutorials";
        string urlSeleniumTutorials = "https://www.seleniumeasy.com/selenium-tutorials";
        string searchItem = "Java";
        string urlNotCorrect = "URL is not correct";
        string xpathOfSearchField = "/html/body/header/div/div[1]/div/section/form/div/div/div[1]/input";
        string xpathOfsearchButton = "#search-block-form > div > div > div.input-group > span > button";
        string xpathOfSeleniumButton = "/html/body/header/div/div[2]/nav/ul/li[2]/a";
        string xpathOfJavaSubButtonInSeleniumButton = "/html/body/header/div/div[2]/nav/ul/li[2]/ul/li[1]/a";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\rafalkorzeniec\Desktop\ChromeDriver\");
            driver.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver.Manage().Window.Size = new System.Drawing.Size(900, 700);

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(10);

        }

        [Test]
        public void titleMainPageTest()
        {
            driver.Navigate().GoToUrl(urlOfPage);
            Assert.AreEqual(driver.Title, titleOfMainPage);
        }

        [Test]
        public void searchFieldTest()
        {
            driver.Navigate().GoToUrl(urlOfPage);
            IWebElement searchField = driver.FindElement(By.XPath(xpathOfSearchField));
            searchField.SendKeys(searchItem);
            driver.FindElement(By.CssSelector(xpathOfsearchButton)).Click();

            Assert.AreNotEqual(urlOfPage, expectedUrlOfSearchFieldTest, urlNotCorrect);
        }

        [Test]
        public void GUITest()
        {
            driver.Navigate().GoToUrl(urlOfPage);
            IWebElement button1 = driver.FindElement(By.XPath(xpathOfSeleniumButton));
            button1.Click();
            IWebElement button2 = driver.FindElement(By.XPath(xpathOfJavaSubButtonInSeleniumButton));
            button2.Click();
            Assert.AreEqual(expectedUrlOfGUITest, urlSeleniumTutorials, urlNotCorrect);
        }

        [TearDown]
        public void QuickDriver()
        {
            driver.Quit();
        }
    }
}