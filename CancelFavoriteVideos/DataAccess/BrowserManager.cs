using CancelFavoriteVideos.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CancelFavoriteVideos.DataAccess
{
    // ブラウザ操作管理
    internal class BrowserManager : IDisposable
    {
        private ChromeDriver chromeDriver = null;

        // ドライバ初期化
        public void NewDriver(ChromeOptions chromeOptions = null)
        {
            if (this.chromeDriver != null)
            {
                throw new InvalidOperationException("WebDriverインスタンスはすでに初期化されています");
            }
            if (chromeOptions == null)
            {
                this.chromeDriver = new ChromeDriver();
            }
            else
            {
                this.chromeDriver = new ChromeDriver(chromeOptions);
            }
        }

        // 暗黙的な待機を設定
        public void SetImplicitWait(int seconds = 10)
        {
            CheckDriverInstance();
            this.chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        // ドライバ初期化チェック
        public void CheckDriverInstance()
        {
            if (this.chromeDriver == null)
            {
                throw new InvalidOperationException("WebDriverインスタンスが初期化されていません");
            }
        }

        // リソース開放
        public void Dispose()
        {
            this.chromeDriver?.Quit();
        }

        // URL遷移
        public void GoToUrl(string url)
        {
            CheckDriverInstance();
            this.chromeDriver.Navigate().GoToUrl(url);
        }

        // ひとつ前のURLに戻る
        public void BackUrl()
        {
            CheckDriverInstance();
            this.chromeDriver.Navigate().Back();
        }

        // 現在のURL取得
        public string GetCurrentUrl()
        {
            CheckDriverInstance();
            return this.chromeDriver.Url;
        }

        // URL再読み込み
        public void RefreshUrl(string url)
        {
            CheckDriverInstance();
            this.chromeDriver.Navigate().Refresh();
        }

        // 要素取得
        public IWebElement GetWebElement(WebElementType elementType, string elementName, int recursionCount = 10)
        {
            CheckDriverInstance();

            IWebElement webElement = null;
            try
            {
                switch (elementType)
                {
                    case WebElementType.Id:
                        webElement = this.chromeDriver.FindElement(By.Id(elementName));
                        break;
                    case WebElementType.Name:
                        webElement = this.chromeDriver.FindElement(By.Name(elementName));
                        break;
                    case WebElementType.ClassName:
                        webElement = this.chromeDriver.FindElement(By.ClassName(elementName));
                        break;
                    case WebElementType.TagName:
                        webElement = this.chromeDriver.FindElement(By.TagName(elementName));
                        break;
                    case WebElementType.LinkText:
                        webElement = this.chromeDriver.FindElement(By.LinkText(elementName));
                        break;
                    case WebElementType.CssSelector:
                        webElement = this.chromeDriver.FindElement(By.CssSelector(elementName));
                        break;
                    case WebElementType.XPath:
                        webElement = this.chromeDriver.FindElement(By.XPath(elementName));
                        break;
                    default:
                        throw new NotSupportedException(elementType + "は定義されていません");
                }
            }
            catch (NoSuchElementException)
            {
                // 再帰処理
                if (recursionCount > 0)
                {
                    Thread.Sleep(500);
                    webElement = GetWebElement(elementType, elementName, --recursionCount);
                }
                else
                {
                    throw;
                }
            }

            return webElement;
        }

        // 要素群取得
        public List<IWebElement> GetWebElements(WebElementType elementType, string elementName)
        {
            CheckDriverInstance();

            List<IWebElement> webElements = new List<IWebElement>();
            switch (elementType)
            {
                case WebElementType.Id:
                    webElements.AddRange(this.chromeDriver.FindElements(By.Id(elementName)));
                    break;
                case WebElementType.Name:
                    webElements.AddRange(this.chromeDriver.FindElements(By.Name(elementName)));
                    break;
                case WebElementType.ClassName:
                    webElements.AddRange(this.chromeDriver.FindElements(By.ClassName(elementName)));
                    break;
                case WebElementType.TagName:
                    webElements.AddRange(this.chromeDriver.FindElements(By.TagName(elementName)));
                    break;
                case WebElementType.LinkText:
                    webElements.AddRange(this.chromeDriver.FindElements(By.LinkText(elementName)));
                    break;
                case WebElementType.CssSelector:
                    webElements.AddRange(this.chromeDriver.FindElements(By.CssSelector(elementName)));
                    break;
                case WebElementType.XPath:
                    webElements.AddRange(this.chromeDriver.FindElements(By.XPath(elementName)));
                    break;
                default:
                    throw new NotSupportedException(elementType + "は定義されていません");
            }

            return webElements;
        }
    }
}
