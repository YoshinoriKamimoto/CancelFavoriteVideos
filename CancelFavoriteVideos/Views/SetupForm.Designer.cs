namespace CancelFavoriteVideos.Views
{
    partial class SetupForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            setupButton = new Button();
            profilePathTextBox = new TextBox();
            profilePathLabel = new Label();
            profileNameLabel = new Label();
            profileNameTextBox = new TextBox();
            setupGroupBox = new GroupBox();
            getSettingsButton = new Button();
            label1 = new Label();
            chromeVersionLinkLabel = new LinkLabel();
            setupGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // setupButton
            // 
            setupButton.Location = new Point(523, 122);
            setupButton.Name = "setupButton";
            setupButton.Size = new Size(73, 31);
            setupButton.TabIndex = 1;
            setupButton.Text = "設定完了";
            setupButton.UseVisualStyleBackColor = true;
            setupButton.Click += SetupButton_Click;
            // 
            // profilePathTextBox
            // 
            profilePathTextBox.Font = new Font("Yu Gothic UI", 11F);
            profilePathTextBox.Location = new Point(121, 43);
            profilePathTextBox.Name = "profilePathTextBox";
            profilePathTextBox.Size = new Size(475, 27);
            profilePathTextBox.TabIndex = 2;
            // 
            // profilePathLabel
            // 
            profilePathLabel.AutoSize = true;
            profilePathLabel.Font = new Font("Yu Gothic UI", 11F);
            profilePathLabel.Location = new Point(21, 46);
            profilePathLabel.Name = "profilePathLabel";
            profilePathLabel.Size = new Size(94, 20);
            profilePathLabel.TabIndex = 2;
            profilePathLabel.Text = "プロフィールパス";
            // 
            // profileNameLabel
            // 
            profileNameLabel.AutoSize = true;
            profileNameLabel.Font = new Font("Yu Gothic UI", 11F);
            profileNameLabel.Location = new Point(29, 92);
            profileNameLabel.Name = "profileNameLabel";
            profileNameLabel.Size = new Size(86, 20);
            profileNameLabel.TabIndex = 4;
            profileNameLabel.Text = "プロフィール名";
            // 
            // profileNameTextBox
            // 
            profileNameTextBox.Font = new Font("Yu Gothic UI", 11F);
            profileNameTextBox.Location = new Point(121, 89);
            profileNameTextBox.Name = "profileNameTextBox";
            profileNameTextBox.Size = new Size(153, 27);
            profileNameTextBox.TabIndex = 3;
            profileNameTextBox.Text = "Default";
            // 
            // setupGroupBox
            // 
            setupGroupBox.Controls.Add(getSettingsButton);
            setupGroupBox.Controls.Add(label1);
            setupGroupBox.Controls.Add(chromeVersionLinkLabel);
            setupGroupBox.Controls.Add(profilePathTextBox);
            setupGroupBox.Controls.Add(setupButton);
            setupGroupBox.Controls.Add(profileNameLabel);
            setupGroupBox.Controls.Add(profilePathLabel);
            setupGroupBox.Controls.Add(profileNameTextBox);
            setupGroupBox.Location = new Point(17, 13);
            setupGroupBox.Name = "setupGroupBox";
            setupGroupBox.Size = new Size(622, 168);
            setupGroupBox.TabIndex = 5;
            setupGroupBox.TabStop = false;
            // 
            // getSettingsButton
            // 
            getSettingsButton.Location = new Point(444, 122);
            getSettingsButton.Name = "getSettingsButton";
            getSettingsButton.Size = new Size(73, 31);
            getSettingsButton.TabIndex = 0;
            getSettingsButton.Text = "自動取得";
            getSettingsButton.UseVisualStyleBackColor = true;
            getSettingsButton.Click += GetSettingsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 11F);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(280, 92);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 7;
            label1.Text = "※基本変更なし";
            // 
            // chromeVersionLinkLabel
            // 
            chromeVersionLinkLabel.Location = new Point(0, 0);
            chromeVersionLinkLabel.Name = "chromeVersionLinkLabel";
            chromeVersionLinkLabel.Size = new Size(100, 23);
            chromeVersionLinkLabel.TabIndex = 8;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 199);
            Controls.Add(setupGroupBox);
            Name = "SetupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "設定";
            setupGroupBox.ResumeLayout(false);
            setupGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button setupButton;
        private TextBox profilePathTextBox;
        private Label profilePathLabel;
        private Label profileNameLabel;
        private TextBox profileNameTextBox;
        private GroupBox setupGroupBox;
        private LinkLabel chromeVersionLinkLabel;
        private Label label1;
        private Button getSettingsButton;
    }
}
