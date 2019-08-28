using Rest414Test.Services;

namespace Rest414Test.Tools
{
    public static class OnTimedEvent
    {
        public static string GetAliveTokens(AdminService adminService)
        {
            string aliveTokens = adminService.GetAliveTokens();
            return aliveTokens;
        }
    }
}
