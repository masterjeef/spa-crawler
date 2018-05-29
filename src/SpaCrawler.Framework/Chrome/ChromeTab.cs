using System;

namespace SpaCrawler.Framework.Chrome
{
    public class ChromeTab : IDisposable
    {
        public ChromeTab()
        {
        }

        public void Dispose()
        {
            // close the chrome tab (we want to end the current session)
        }
    }
}