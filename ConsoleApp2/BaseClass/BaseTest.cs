using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void open()
        {
            driver = new ChromeDriver();   //initializing chromedriver
            driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/"); //Opening URL in Chromedriver window
            driver.Manage().Window.Maximize();  //Maximizing Window
            InitializeBase(driver);   //initializingBase function
        }



        [TearDown]
        public void close()
        {
             driver.Quit(); // Closing Driver
        }

        public HomePage hp;  //declaring HomePage

        public void InitializeBase(IWebDriver driver)
        {
            hp = new HomePage(driver);  // creating object for HomePage;
        }
    }
}
