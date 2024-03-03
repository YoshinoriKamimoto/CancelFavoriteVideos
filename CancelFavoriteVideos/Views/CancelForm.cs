using CancelFavoriteVideos.Models;
using CancelFavoriteVideos.Services;
using System.Diagnostics;

namespace CancelFavoriteVideos.Views
{
    // 取り消し実行画面
    internal partial class CancelForm : Form
    {
        private ChromeProfile chromeProfile;

        public CancelForm(ChromeProfile chromeProfile)
        {
            InitializeComponent();
            this.chromeProfile = chromeProfile;
        }

        // 実行ボタン
        private void RunButton_Click(object sender, EventArgs e)
        {
            // 高評価取り消し実行
            if (!CancelFavoritesProcess())
            {
                return;
            }
        }

        // 高評価取り消し実行処理
        private bool CancelFavoritesProcess()
        {
            int videoCount = 0;
            if (string.IsNullOrEmpty(videoCountTextBox.Text))
            {
                MessageBox.Show("動画数を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(videoCountTextBox.Text, out videoCount))
            {
                MessageBox.Show("動画数の入力フォーマットが不正です\n入力内容を確認してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (videoCount < 1)
            {
                MessageBox.Show("動画数は自然数で入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                int canceledCount = new BrowserService().CancelFavorites(videoCount, this.chromeProfile);
                MessageBox.Show($"{canceledCount}本の高評価を取り消しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"高評価取り消し実行エラー\n{ex}");
                MessageBox.Show($"高評価取り消し実行エラー\n\n{ex}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
