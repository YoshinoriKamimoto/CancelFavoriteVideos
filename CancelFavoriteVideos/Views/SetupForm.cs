using CancelFavoriteVideos.Models;
using CancelFavoriteVideos.Services;
using System.Diagnostics;

namespace CancelFavoriteVideos.Views
{
    // Chrome�v���t�B�[���ݒ���
    public partial class SetupForm : Form
    {
        private ChromeProfile currentChromProfile = null;

        public SetupForm()
        {
            InitializeComponent();
        }

        // �ݒ�l�����擾�{�^��
        private void GetSettingsButton_Click(object sender, EventArgs e)
        {
            // Chrome�v���t�B�[�������擾
            if (!AutoAcquireChromeProfileProcess())
            {
                return;
            }
        }

        // �ݒ芮���{�^��
        private void SetupButton_Click(object sender, EventArgs e)
        {
            // ���݂�Chrome�v���t�B�[�����擾
            if (!GetCurrentChromeProfileProcess())
            {
                return;
            }

            // ���������s��ʕ\��
            StartupCancelForm();
        }

        // Chrom�v���t�B�[�������擾����
        private bool AutoAcquireChromeProfileProcess()
        {
            // Web�𑀍삵��Chrome�v���t�B�[�����擾
            try
            {
                ChromeProfile chromeProfile = new BrowserService().GetChromeProfile();
                profilePathTextBox.Text = chromeProfile.Path;
                profileNameTextBox.Text = chromeProfile.Name;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�����擾�G���[\n{ex}");
                MessageBox.Show($"�����擾�G���[\n\n{ex}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // ���݂�Chrome�v���t�B�[���擾����
        private bool GetCurrentChromeProfileProcess()
        {
            string path = profilePathTextBox.Text;
            string name = profileNameTextBox.Text;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("�v���t�B�[���p�X����͂��Ă�������", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("�v���t�B�[��������͂��Ă�������", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.currentChromProfile = new ChromeProfile(path, name);
            return true;
        }

        // ���������s��ʕ\������
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
