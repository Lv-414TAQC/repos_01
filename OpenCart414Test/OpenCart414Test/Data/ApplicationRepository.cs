using System;
using System.Collections.Generic;

namespace OpenCart414Test.Data
{
    public sealed class ApplicationRepository
    {
        private ApplicationRepository() { }

        public static SearchDTO GetCurrencyDTO(Currency currency)
        {
            SearchDTO result = null;
            IDictionary<Currency, SearchDTO> сurrencies = new Dictionary<Currency, SearchDTO>();
            сurrencies.Add(Currency.EURO, new SearchDTO("Euro", "EUR"));
            сurrencies.Add(Currency.POUND_STERLING, new SearchDTO("Pound Sterling", "GBP"));
            сurrencies.Add(Currency.US_DOLLAR, new SearchDTO("US Dollar", "USD"));
            result = сurrencies[currency];
            if (result == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("Currency not Found.");
            }
            return result;
        }

        public static SearchDTO GetLoggedMyAccountDTO(LoggedMyAccount loggedMyAccount)
        {
            SearchDTO result = null;
            IDictionary<LoggedMyAccount, SearchDTO> loggedMyAccounts = new Dictionary<LoggedMyAccount, SearchDTO>();
            loggedMyAccounts.Add(LoggedMyAccount.MY_ACCOUNT, new SearchDTO("My Account", ".dropdown-menu-right li a[href*='/account']"));
            loggedMyAccounts.Add(LoggedMyAccount.ORDER_HISTORY, new SearchDTO("Order History", ".dropdown-menu-right li a[href*='/order']"));
            loggedMyAccounts.Add(LoggedMyAccount.TRANSACTIONS, new SearchDTO("Transactions", ".dropdown-menu-right li a[href*='/transaction']"));
            loggedMyAccounts.Add(LoggedMyAccount.DOWNLOADS, new SearchDTO("Downloads", ".dropdown-menu-right li a[href*='/download']"));
            loggedMyAccounts.Add(LoggedMyAccount.LOGOUT, new SearchDTO("Logout", ".dropdown-menu-right li a[href*='/logout']"));
            result = loggedMyAccounts[loggedMyAccount];
            if (result == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("Currency not Found.");
            }
            return result;
        }

        public static SearchDTO GetUnloggedMyAccountDTO(UnloggedMyAccount unloggedMyAccount)
        {
            SearchDTO result = null;
            IDictionary<UnloggedMyAccount, SearchDTO> unloggedMyAccounts = new Dictionary<UnloggedMyAccount, SearchDTO>();
            unloggedMyAccounts.Add(UnloggedMyAccount.REGISTER, new SearchDTO("Register", ".dropdown-menu-right li a[href*='/register']"));
            unloggedMyAccounts.Add(UnloggedMyAccount.LOGIN, new SearchDTO("Login", ".dropdown-menu-right li a[href*='/login']"));
            result = unloggedMyAccounts[unloggedMyAccount];
            if (result == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("Currency not Found.");
            }
            return result;
        }

    }
}
