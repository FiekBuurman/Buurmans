namespace Buurmans.AmbiLight.Form.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.OutputColorPanel = new System.Windows.Forms.Panel();
            this.OutputColorLabel = new System.Windows.Forms.Label();
            this.ShowSettingsButton = new System.Windows.Forms.Button();
            this.OutputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.OutputBitmapPictureBox = new System.Windows.Forms.PictureBox();
            this.OutputColorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputBitmapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(3, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(210, 49);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(217, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(210, 49);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // OutputColorPanel
            // 
            this.OutputColorPanel.Controls.Add(this.OutputColorLabel);
            this.OutputColorPanel.Location = new System.Drawing.Point(3, 208);
            this.OutputColorPanel.Name = "OutputColorPanel";
            this.OutputColorPanel.Size = new System.Drawing.Size(424, 45);
            this.OutputColorPanel.TabIndex = 3;
            // 
            // OutputColorLabel
            // 
            this.OutputColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputColorLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputColorLabel.Location = new System.Drawing.Point(0, 0);
            this.OutputColorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OutputColorLabel.Name = "OutputColorLabel";
            this.OutputColorLabel.Size = new System.Drawing.Size(424, 45);
            this.OutputColorLabel.TabIndex = 0;
            this.OutputColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowSettingsButton
            // 
            this.ShowSettingsButton.Location = new System.Drawing.Point(217, 433);
            this.ShowSettingsButton.Name = "ShowSettingsButton";
            this.ShowSettingsButton.Size = new System.Drawing.Size(210, 34);
            this.ShowSettingsButton.TabIndex = 4;
            this.ShowSettingsButton.Text = "Settings";
            this.ShowSettingsButton.UseVisualStyleBackColor = true;
            this.ShowSettingsButton.Click += new System.EventHandler(this.ShowSettingsButton_Click);
            // 
            // OutputRichTextBox
            // 
            this.OutputRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OutputRichTextBox.Location = new System.Drawing.Point(3, 259);
            this.OutputRichTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.OutputRichTextBox.Name = "OutputRichTextBox";
            this.OutputRichTextBox.ReadOnly = true;
            this.OutputRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.OutputRichTextBox.Size = new System.Drawing.Size(423, 167);
            this.OutputRichTextBox.TabIndex = 5;
            this.OutputRichTextBox.Text = "";
            this.OutputRichTextBox.TextChanged += new System.EventHandler(this.OutputRichTextBox_TextChanged);
            // 
            // OutputBitmapPictureBox
            // 
            this.OutputBitmapPictureBox.Location = new System.Drawing.Point(3, 57);
            this.OutputBitmapPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputBitmapPictureBox.Name = "OutputBitmapPictureBox";
            this.OutputBitmapPictureBox.Size = new System.Drawing.Size(424, 146);
            this.OutputBitmapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OutputBitmapPictureBox.TabIndex = 6;
            this.OutputBitmapPictureBox.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 479);
            this.Controls.Add(this.OutputBitmapPictureBox);
            this.Controls.Add(this.OutputRichTextBox);
            this.Controls.Add(this.ShowSettingsButton);
            this.Controls.Add(this.OutputColorPanel);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ambi Light MQTT";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.OutputColorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutputBitmapPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Panel OutputColorPanel;
        private System.Windows.Forms.Button ShowSettingsButton;
        private System.Windows.Forms.RichTextBox OutputRichTextBox;
        private System.Windows.Forms.Label OutputColorLabel;
        private System.Windows.Forms.PictureBox OutputBitmapPictureBox;
    }
}