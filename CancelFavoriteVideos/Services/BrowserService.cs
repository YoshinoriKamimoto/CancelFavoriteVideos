using CancelFavoriteVideos.Constants;
using CancelFavoriteVideos.DataAccess;
using CancelFavoriteVideos.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CancelFavoriteVideos.Services
{
    // ブラウザ操作処理
    internal class BrowserService
    {
        // Chromeプロフィール取得
        public ChromeProfile GetChromeProfile()
        {
            using (BrowserManager browserManager = new BrowserManager())
            {
                browserManager.NewDriver();
                browserManager.GoToUrl(GlobalConstant.ChromeVersionUrl);
                string chromeProfileInfo = browserManager.GetWebElement(WebElementType.Id, "profile_path").Text;
                string profilePath = ReplaceTmpProfilePath(chromeProfileInfo);
                Debug.WriteLine(profilePath);
                string profileName = chromeProfileInfo.Substring(chromeProfileInfo.LastIndexOf("\\") + 1);
                return new ChromeProfile(profilePath, profileName);
            }
        }

        // 一時プロフィールパスを置換
        private string ReplaceTmpProfilePath(string sourceProfilePath)
        {
            const string pattern = @"Temp.*";
            const string targetWord = @"Google\Chrome\User Data";
            return Regex.Replace(sourceProfilePath, pattern, targetWord);
        }

        // 高評価取り消し
        public int CancelFavorites(int vidoCount, ChromeProfile chromeProfile)
        {
            int canceledCount = 0;
            using (BrowserManager browserManager = new BrowserManager())
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--user-data-dir=" + chromeProfile.Path);
                chromeOptions.AddArgument("--profile-directory=" + chromeProfile.Name);
                browserManager.NewDriver(chromeOptions);
                browserManager.SetImplicitWait();

                // 指定した本数の高評価を取り消し
                browserManager.GoToUrl(GlobalConstant.YoutubeFavoriteVideosTopUrl);
                for (int i = 0; i < vidoCount; i++)
                {
                    // 高評価ボタンを取得
                    browserManager.RefreshUrl(GlobalConstant.YoutubeFavoriteVideosTopUrl);
                    browserManager.GetWebElement(WebElementType.Id, "video-title").Click();
                    IWebElement favoriteButtonElement = GetFavoriteButtonElement(browserManager, 5);
                    if (favoriteButtonElement == null)
                    {
                        throw new InvalidOperationException("高評価ボタン要素が見つかりませんでした");
                    }
                    favoriteButtonElement.Click(); // 高評価取り消し
                    canceledCount++;
                    browserManager.GoToUrl(GlobalConstant.YoutubeFavoriteVideosTopUrl); // 高評価トップページに戻る
                }
            }

            return canceledCount;
        }

        // 高評価ボタン取得
        private IWebElement GetFavoriteButtonElement(BrowserManager browserManager, int recursionCount)
        {
            IWebElement favoriteButtonElement = null;

            Thread.Sleep(500);
            List<IWebElement> webElements = browserManager.GetWebElements(WebElementType.XPath, "//button");
            foreach (IWebElement webElement in webElements)
            {
                // aria-label属性の属性値で高評価ボタンかチェック
                string value = webElement.GetAttribute("aria-label");
                if (value == null)
                {
                    continue;
                }

                if ((value.Contains("高評価") && value.Contains("件")) || value.Contains("高く評価"))
                {
                    // 高評価ボタンに該当
                    favoriteButtonElement = webElement;
                    break;
                }
            }

            // 再帰処理
            if (favoriteButtonElement == null)
            {
                favoriteButtonElement = GetFavoriteButtonElement(browserManager, --recursionCount);
            }
            return favoriteButtonElement;
        }
    }
}
