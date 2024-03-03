using CancelFavoriteVideos.Models;
using CancelFavoriteVideos.Services;
using System.Diagnostics;

namespace CancelFavoriteVideos.Views
{
    // Chromeプロフィール設定画面
    public partial class SetupForm : Form
    {
        private ChromeProfile currentChromProfile = null;

        public SetupForm()
        {
            InitializeComponent();
        }

        // 設定値自動取得ボタン
        private void GetSettingsButton_Click(object sender, EventArgs e)
        {
            // Chromeプロフィール自動取得
            if (!AutoAcquireChromeProfileProcess())
            {
                return;
            }
        }

        // 設定完了ボタン
        private void SetupButton_Click(object sender, EventArgs e)
        {
            // 現在のChromeプロフィールを取得
            if (!GetCurrentChromeProfileProcess())
            {
                return;
            }

            // 取り消し実行画面表示
            StartupCancelForm();
        }

        // Chromプロフィール自動取得処理
        private bool AutoAcquireChromeProfileProcess()
        {
            // Webを操作してChromeプロフィールを取得
            try
            {
                ChromeProfile chromeProfile = new BrowserService().GetChromeProfile();
                profilePathTextBox.Text = chromeProfile.Path;
                profileNameTextBox.Text = chromeProfile.Name;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"自動取得エラー\n{ex}");
                MessageBox.Show($"自動取得エラー\n\n{ex}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // 現在のChromeプロフィール取得処理
        private bool GetCurrentChromeProfileProcess()
        {
            string path = profilePathTextBox.Text;
            string name = profileNameTextBox.Text;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("プロフィールパスを入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("プロフィール名を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.currentChromProfile = new ChromeProfile(path, name);
            return true;
        }

        // 取り消し実行画面表示処理
        private void StartupCancelForm()
        {
            CancelForm cancelForm = null;
            try
            {
                cancelForm = new CancelForm(this.currentChromProfile);
                this.Visible = false;
                cancelForm.ShowDialog();
                this.Visible = true;
            }
            finally
            {
                cancelForm?.Dispose();
            }
        }
    }
}
