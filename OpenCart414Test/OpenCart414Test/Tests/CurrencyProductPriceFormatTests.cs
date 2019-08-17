using System;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Data;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class CurrencyProductPriceFormatTests : TestRunner
    {/*
        [TestCase(Currency.US_DOLLAR, @"^\$\d+\.\d{2}")]
        [TestCase(Currency.EURO, @"\d+\.\d{2}€$")]
        [TestCase(Currency.POUND_STERLING, @"^£\d+\.\d{2}")]
        public void CheckCurrencyFormatOfNewPrice(Currency currency, string pattern)
        {
            HomePage UserHomePage = LoadHomePage();
            UserHomePage = UserHomePage.ChooseCurrency(currency);
            string newPrice = UserHomePage.GetProductNewPrice(ProductRepository.GetCanonEos5D());
            Console.WriteLine(newPrice);
            StringAssert.IsMatch(pattern, newPrice);

        }
        
        [TestCase(Currency.US_DOLLAR, @"^\$\d+\.\d{2}")]
        [TestCase(Currency.EURO, @"\d+\.\d{2}€$")]
        [TestCase(Currency.POUND_STERLING, @"^£\d+\.\d{2}")]
        public void CheckCurrencyFormatOfOldPrice(Currency currency, string pattern)
        {
            HomePage UserHomePage = LoadHomePage();
            UserHomePage = UserHomePage.ChooseCurrency(currency);
            string oLdPrice = UserHomePage.GetProductOldPrice(ProductRepository.GetCanonEos5D());
            Console.WriteLine(oLdPrice);
            StringAssert.IsMatch(pattern, oLdPrice);

        }

        [TestCase(Currency.US_DOLLAR, @"^\$\d+\.\d{2}")]
        [TestCase(Currency.EURO, @"\d+\.\d{2}€$")]
        [TestCase(Currency.POUND_STERLING, @"^£\d+\.\d{2}")]
        public void CheckCurrencyFormatOfExTax(Currency currency, string pattern)
        {
            HomePage UserHomePage = LoadHomePage();
            UserHomePage = UserHomePage.ChooseCurrency(currency);
            string exTax = UserHomePage.GetProductExTax(ProductRepository.GetCanonEos5D());
            Console.WriteLine(exTax);
            StringAssert.IsMatch(pattern, exTax);

        }
        */

    }
}
