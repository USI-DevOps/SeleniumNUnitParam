using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Keys;

namespace SeleniumNUnitParam
{
    public class BrowserTest : Hooks
    {     
        /*[Test]
        public void Test()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement element = Driver.FindElement(By.Id("q"));
            element.SendKeys("selenium webdriver");
            System.Threading.Thread.Sleep(5000);
            Driver.FindElement(By.Name("btnG")).Click();
            
            // Get the search results panel that contains the link for each result.
            IWebElement resultsPanel = Driver.FindElement(By.Id("search"));

            // Get all the links only contained within the search result panel.
            //ReadOnlyCollection<IWebElement> searchResults = resultsPanel.FindElements(By.XPath(".//a"));

            // Print the text for every link in the search results.
            //foreach (IWebElement result in searchResults)
            //{
                //Console.WriteLine(result.Text);
            //}

            Assert.That(Driver.PageSource.Contains("selenium webdriver"), Is.EqualTo(true), "The text selenium webdriver doest not exist");
        }
    
        [Test]
        public void PluralsightTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            
            var searchText = Driver.FindElement(By.Id("q"));
            searchText.SendKeys("Pluralsight");
            System.Threading.Thread.Sleep(5000);
            
            searchText.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);
            Assert.That(Driver.PageSource.Contains("Pluralsight"), Is.EqualTo(true), "The text Pluralsight doest not exist");
        }*/
        
        [Test]
        public void ExecuteAutomationTest()
        {
            Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            Driver.FindElement(By.Name("UserName")).SendKeys("admin");
            Driver.FindElement(By.Name("Password")).SendKeys("admin");
            Driver.FindElement(By.Name("Login")).Submit();
            System.Threading.Thread.Sleep(2000);
            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true), "The text selenium doest not exist");
        }

        [Test]
        public void GoogleTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("Selenium");
            System.Threading.Thread.Sleep(5000);
            Driver.FindElement(By.Name("q")).SendKeys(Keys.ENTER); 
            //Driver.FindElement(By.Name("btnG")).Click();
            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true), "The text selenium doest not exist");
        }
    }
}
