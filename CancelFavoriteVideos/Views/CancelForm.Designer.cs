namespace CancelFavoriteVideos.Views
{
    partial class CancelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            videoCountTextBox = new TextBox();
            profilePathLabel = new Label();
            runButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // videoCountTextBox
            // 
            videoCountTextBox.Font = new Font("Yu Gothic UI", 11F);
            videoCountTextBox.Location = new Point(132, 87);
            videoCountTextBox.Name = "videoCountTextBox";
            videoCountTextBox.Size = new Size(81, 27);
            videoCountTextBox.TabIndex = 3;
            // 
            // profilePathLabel
            // 
            profilePathLabel.AutoSize = true;
            profilePathLabel.Font = new Font("Yu Gothic UI", 11F);
            profilePathLabel.Location = new Point(72, 90);
            profilePathLabel.Name = "profilePathLabel";
            profilePathLabel.Size = new Size(54, 20);
            profilePathLabel.TabIndex = 4;
            profilePathLabel.Text = "動画数";
            // 
            // runButton
            // 
            runButton.Location = new Point(230, 85);
            runButton.Name = "runButton";
            runButton.Size = new Size(73, 31);
            runButton.TabIndex = 5;
            runButton.Text = "実行";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += RunButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 11F);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(40, 22);
            label1.Name = "label1";
            label1.Size = new Size(288, 20);
            label1.TabIndex = 6;
            label1.Text = "※すべてのChromeを閉じてから実行してください";
            // 
            // CancelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 159);
            Controls.Add(label1);
            Controls.Add(runButton);
            Controls.Add(videoCountTextBox);
            Controls.Add(profilePathLabel);
            Name = "CancelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "実行";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox videoCountTextBox;
        private Label profilePathLabel;
        private Button runButton;
        private Label label1;
    }
}