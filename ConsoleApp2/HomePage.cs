using ConsoleApp2.BaseClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class HomePage
    {
        private IWebDriver Driver;

        public HomePage(IWebDriver driver) //initializing Constructor for HomePage
        {
            this.Driver = driver;
        }




        public void Login(string UserName, string password) //Login method
        {
            Driver.FindElement(By.Id("txt-username")).SendKeys(UserName); //sending Username in Username text field
            Driver.FindElement(By.Id("txt-password")).SendKeys(password); //sending Password in password text field
            Thread.Sleep(3000);    //waiting for 3 seconds
            Driver.FindElement(By.Id("btn-login")).Click();  //Clicking login button

        }

        public void ClkBtnAppointment()
        {
            IWebElement BtnAppointment = Driver.FindElement(By.Id("btn-make-appointment"));//Assigning IwebElement button
            BtnAppointment.Click();
        }

        public bool? MakeappoinymentIsDisplayed()
        {
            return Driver.FindElement(By.XPath("//h2[contains(text(),'Make Appointment')]")).Displayed;
        }

        public bool? VerifyAppointmentConfirmationText(string v)
        {
            //string txt = Driver.FindElement(By.XPath("//section[@id='summary']/div/div/div/h2")).Text;
            //if (txt == v)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
           return Driver.FindElement(By.XPath("//section[@id='summary']/div/div/div/h2")).Text.Equals(v);
        }

        public bool? VerifyLoginText(string v)
        {
            return Driver.FindElement(By.XPath("//section[@id='login']/div/div/div/h2")).Text.Equals(v);
        }

        

        public bool? VerifyFailedLoginText(string v)
        {
            return Driver.FindElement(By.XPath("//section[@id='login']/div/div/div/p[2]")).Text.Equals(v);
        }

        public bool? VerifyHomeLinkText(string v)
        {
            return Driver.FindElement(By.LinkText("Home")).Text.Equals(v);
        }

        public bool? VerifyHistorylinkText(string v)
        {
            return Driver.FindElement(By.LinkText("History")).Text.Equals(v);
        }

        public bool? VerifyProfilelinkText(string v)
        {
            return Driver.FindElement(By.LinkText("Profile")).Text.Equals(v);
        }

        public bool? VerifyLogoutlinkText(string v)
        {
            return Driver.FindElement(By.LinkText("Logout")).Text.Equals(v);
        }
    }
}
