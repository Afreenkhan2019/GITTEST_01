using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using ConsoleApp2.BaseClass;
using System.Threading;
using ConsoleApp2;

namespace POMProject
{
    [TestFixture]
    public class Program : BaseTest //Inherits Base Test
    {
        //IWebDriver driver = new ChromeDriver();

       
        static void Main(string[] args)
        {
        }

       
        [Test, Category("Smoke")]
        public void Testmethod1()
        {
            // //IWebDriver driver = new ChromeDriver();
            // //driver.Navigate().GoToUrl("https://www.facebook.com/");
            // driver.Manage().Window.Maximize();
            // IWebElement EmailText= driver.FindElement(By.XPath("//input[@id='email']"));
            // EmailText.SendKeys("testafreenme@gmail.com");
            // Thread.Sleep(3000);
            // EmailText.Clear();
            // EmailText.SendKeys("testafreenme@gmail.com");
            // EmailText.Clear();
            // driver.FindElement(By.LinkText("Create New Account")).Click();
            // Thread.Sleep(5000);
            // IWebElement monthDropDownList = driver.FindElement(By.XPath("//select[@id='month']"));
            //// monthDropDownList.Click();
            // SelectElement element = new SelectElement(monthDropDownList);
            // Thread.Sleep(5000);
            // element.SelectByIndex(10);
            // Thread.Sleep(5000);
            // element.SelectByText("Mar");
            // Thread.Sleep(5000);
            // element.SelectByValue("7");
            // Thread.Sleep(5000);
            //IWebElement BtnAppointment = driver.FindElement(By.Id("btn-make-appointment"));
            //BtnAppointment.Click();
            //IWebElement TxtUsername = driver.FindElement(By.Id("txt-username"));
            //TxtUsername.SendKeys("John Doe");
            //IWebElement txtPassowrd = driver.FindElement(By.Id("txt-password"));
            //txtPassowrd.SendKeys("ThisIsNotAPassword");
            //IWebElement btnLogin = driver.FindElement(By.Id("btn-login"));
            //btnLogin.Click();

            //IWebElement DDlFacility = driver.FindElement(By.Id("combo_facility"));
            //DDlFacility.Click();
            //SelectElement element = new SelectElement(DDlFacility);
            //element.SelectByValue("Seoul CURA Healthcare Center");
            //Thread.Sleep(5000);
            //IWebElement readmission = driver.FindElement(By.Id("chk_hospotal_readmission"));
            //readmission.Click();
            //IWebElement RadioHealthCare = driver.FindElement(By.XPath("//input[@id='radio_program_medicaid']"));
            //RadioHealthCare.Click();
            //Thread.Sleep(5000);
            //IWebElement TxtVisitDate = driver.FindElement(By.Id("txt_visit_date"));
            //TxtVisitDate.Click();
            //TxtVisitDate.SendKeys("28/07/2022");
            
            //IWebElement txtComment = driver.FindElement(By.Id("txt_comment"));
            //txtComment.SendKeys(" This is the request for Appointment");
            //Thread.Sleep(5000);
            //IWebElement btnBookAppointment = driver.FindElement(By.Id("btn-book-appointment"));
            //BtnAppointment.Click();
            //Thread.Sleep(5000);
           

        }
        [Test, Category("Regression")]
        public void Testmethod2()//Valid login
        {
            
            IWebElement BtnAppointment = driver.FindElement(By.Id("btn-make-appointment")); //Assigning IwebElement button
            BtnAppointment.Click();  // Clicking Iwebelement
            hp.Login("John Doe", "ThisIsNotAPassword"); //calling login method from homePage 
                                                        //Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Make Appointment')]")).Displayed);  // providing Assertion to verify text


            Assert.IsTrue(hp.MakeappoinymentIsDisplayed());



        }
        /// <summary>
        /// 
        /// </summary>

        [Test, Category("Smoke")]
        public void Testmethod3()//Filling appointment form
        {
           
            IWebElement BtnAppointment = driver.FindElement(By.Id("btn-make-appointment"));//Assigning IwebElement
            BtnAppointment.Click();  // Clicking Iwebelement
            hp.Login("John Doe", "ThisIsNotAPassword");  //calling login method from homePage 

            // Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Make Appointment')]")).Displayed); // providing Assertion to verify text


            Assert.IsTrue(hp.MakeappoinymentIsDisplayed());



            IWebElement DDlFacility = driver.FindElement(By.Id("combo_facility")); //Assigning IwebElement
            DDlFacility.Click();  //Clicking DropdownList
            SelectElement element = new SelectElement(DDlFacility);  //Assigning Dropdownlist to SelectElement
            element.SelectByValue("Seoul CURA Healthcare Center");  //Selecting a value in dropdownlist
            IWebElement readmission = driver.FindElement(By.Id("chk_hospotal_readmission")); //Assigning IwebElement checkbox
            readmission.Click();  //Clicking Checkbox
            IWebElement RadioHealthCare = driver.FindElement(By.XPath("//input[@id='radio_program_medicaid']")); // Assigning Iwebeement radiobutton
            RadioHealthCare.Click();  //Clicking radio button
            IWebElement TxtVisitDate = driver.FindElement(By.Id("txt_visit_date"));  //Assigning IwebElement datepicker
            TxtVisitDate.Click();  //Clicking at date picker
            TxtVisitDate.SendKeys("28/07/2022"); // Entering date in datePicker
            IWebElement txtComment = driver.FindElement(By.Id("txt_comment"));  //Assigning IwebElement comment textbox 
            txtComment.SendKeys(" This is the request for Appointment");  //Entering text in comment webelement
         // IWebElement btnBookAppointment = driver.FindElement(By.Id("btn-book-appointment"));
            bool staleElement = driver.FindElement(By.Id("btn-book-appointment")).Enabled; //declared bool stale element enabled
           
            while (staleElement)
            {
                try
                {                    
                    driver.FindElement(By.Id("btn-book-appointment")).Click();//Clicked make appointment button
                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("btn-book-appointment")));
            //BtnAppointment.Click();
            // Assert.AreEqual("Appointment Confirmation", driver.FindElement(By.XPath("//section[@id='summary']/div/div/div/h2")).Text);  //// providing Assertion to compare text




            Assert.IsTrue(hp.VerifyAppointmentConfirmationText("Appointment Confirmation"));
        }

        [Test]
        public void Testmethod4()//login with invalid password
        {
           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30); //Applying implicit wait
            //IWebElement BtnAppointment = driver.FindElement(By.Id("btn-make-appointment"));//Assigning IwebElement button
            //BtnAppointment.Click(); // Clicking Iwebelement
            hp.ClkBtnAppointment();
            //Assert.AreEqual("Login", driver.FindElement(By.XPath("//section[@id='login']/div/div/div/h2")).Text);  // Providing Assertion to verify text

            Assert.IsTrue(hp.VerifyLoginText("Login"));


            hp.Login("John Doe", "ThisIsNotAPassword1");//calling login method from homePage
            //Assert.AreEqual("Login failed! Please ensure the username and password are valid.", driver.FindElement(By.XPath("//section[@id='login']/div/div/div/p[2]")).Text);//providing Assertion to compare text


            Assert.IsTrue(hp.VerifyFailedLoginText("Login failed! Please ensure the username and password are valid."));



        }

        [Test]
        public void Testmethod5()//Verifying Menu links
        {
            
            IWebElement BtnAppointment = driver.FindElement(By.Id("btn-make-appointment"));//Assigning IwebElement button
            BtnAppointment.Click(); // Clicking Iwebelement
            hp.Login("John Doe", "ThisIsNotAPassword");//calling login method from homePage
                                                       //Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Make Appointment')]")).Displayed);// providing assertion to verify text

            Assert.IsTrue(hp.MakeappoinymentIsDisplayed());


            driver.FindElement(By.XPath("//a[@id='menu-toggle']/i")).Click(); //Clicking on side menu 


            //Assert.AreEqual("Home", driver.FindElement(By.LinkText("Home")).Text); //Providing Assertion for verifying text
            //Assert.AreEqual("History", driver.FindElement(By.LinkText("History")).Text);  //Providing Assertion for verifying text             
            //Assert.AreEqual("Profile", driver.FindElement(By.LinkText("Profile")).Text);//Providing Assertion for verifying text
            //Assert.AreEqual("Logout", driver.FindElement(By.LinkText("Logout")).Text);//Providing Assertion for verifying text

            Assert.IsTrue(hp.VerifyHomeLinkText("Home"));
            Assert.IsTrue(hp.VerifyHistorylinkText("History"));
            Assert.IsTrue(hp.VerifyProfilelinkText("Profile"));
            Assert.IsTrue(hp.VerifyLogoutlinkText("Logout"));

        }

        [Test]
        public void Testmethod6()//login from side menu
        {
           

            driver.FindElement(By.XPath("//a[@id='menu-toggle']/i")).Click();// Clicking on Side Menu 
            driver.FindElement(By.XPath("//a[contains(text(),'Login')]")).Click(); //Clicking at login from side menu  
            //Assert.AreEqual("Login", driver.FindElement(By.XPath("//section[@id='login']/div/div/div/h2")).Text); //Providing assertion to compare text

            Assert.IsTrue(hp.VerifyLoginText("Login"));


            hp.Login("John Doe", "ThisIsNotAPassword1");//calling login method from homePage
                                                        //Assert.AreEqual("Login failed! Please ensure the username and password are valid.", driver.FindElement(By.XPath("//section[@id='login']/div/div/div/p[2]")).Text);//Providing assertion to compare text

            Assert.IsTrue(hp.VerifyFailedLoginText("Login failed! Please ensure the username and password are valid."));

        }

    }

}

   
  
