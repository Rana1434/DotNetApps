using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test2()
        {
            IWebDriver _driver = new ChromeDriver();
            HomePage hp = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(2000);

            Assert.NotNull(hp._logo);
            hp.Search("Selenium");
            Thread.Sleep(2000);
            Assert.True(_driver.Title.Contains("Selenium"));
        }

        [Fact]
        public void Test1()
        {
                //open google chrome: install google chrome driver for selenium
                //browse google: Driver.OpenUrl();
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(3000);
                IWebElement element = driver.FindElement(By.Name("q"));
                Assert.NotNull(element);//test case

                element.SendKeys("selenium");
            driver.FindElement(By.XPath("//body")).Click();

            //element.Submit();
            Thread.Sleep(500);


            IWebElement btnsearch = driver.FindElement(By.Name("btnK"));

                Assert.NotNull(btnsearch);
            btnsearch.Click();


            IWebElement link = driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div/div/div/div/div/div/div[1]/div/span/a/h3"));
            link.Click();
            Thread.Sleep(2000);


            //IWebElement linktext1 = driver.FindElement(By.LinkText("Seleniumwebdriver"));
            //Assert.NotNull(linktext1);
            //type the word selenium in search text box
            //click search: find() and click search
            //in the result set find the first link and click it
            //browae to that clicked link



        }
        

    }
    public class HomePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement _searchtxtbox;

        [FindsBy(How = How.Name, Using = "btnK")]
        private IWebElement _searchbtn;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div/img")]
        public IWebElement _logo;

        [FindsBy(How = How.XPath, Using = "//*[@id='gbwa']/div/a")]
        public IWebElement _apps;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Search(string searchText)
        {
            _searchtxtbox.SendKeys(searchText);
            _searchtxtbox.Submit();
            //_searchbtn.Click();
            Thread.Sleep(2000);
        }
        
    }

}