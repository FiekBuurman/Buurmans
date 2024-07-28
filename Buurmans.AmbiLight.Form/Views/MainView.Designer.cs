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
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CurrentColorToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.OutputPanel = new System.Windows.Forms.Panel();
            this.ShowSettingsButton = new System.Windows.Forms.Button();
            this.MqttButton = new System.Windows.Forms.Button();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(200, 50);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(212, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(200, 50);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentColorToolStripStatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 268);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(424, 22);
            this.MainStatusStrip.TabIndex = 2;
            // 
            // CurrentColorToolStripStatusLabel
            // 
            this.CurrentColorToolStripStatusLabel.Name = "CurrentColorToolStripStatusLabel";
            this.CurrentColorToolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // OutputPanel
            // 
            this.OutputPanel.Location = new System.Drawing.Point(12, 69);
            this.OutputPanel.Name = "OutputPanel";
            this.OutputPanel.Size = new System.Drawing.Size(400, 165);
            this.OutputPanel.TabIndex = 3;
            // 
            // ShowSettingsButton
            // 
            this.ShowSettingsButton.Location = new System.Drawing.Point(12, 240);
            this.ShowSettingsButton.Name = "ShowSettingsButton";
            this.ShowSettingsButton.Size = new System.Drawing.Size(200, 25);
            this.ShowSettingsButton.TabIndex = 4;
            this.ShowSettingsButton.Text = "Settings";
            this.ShowSettingsButton.UseVisualStyleBackColor = true;
            this.ShowSettingsButton.Click += new System.EventHandler(this.ShowSettingsButton_Click);
            // 
            // MqttButton
            // 
            this.MqttButton.Location = new System.Drawing.Point(218, 240);
            this.MqttButton.Name = "MqttButton";
            this.MqttButton.Size = new System.Drawing.Size(194, 25);
            this.MqttButton.TabIndex = 5;
            this.MqttButton.Text = "MQTT";
            this.MqttButton.UseVisualStyleBackColor = true;
            this.MqttButton.Click += new System.EventHandler(this.MqttButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 290);
            this.Controls.Add(this.MqttButton);
            this.Controls.Add(this.ShowSettingsButton);
            this.Controls.Add(this.OutputPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen AmbiLight 2 MQTT";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel CurrentColorToolStripStatusLabel;
        private System.Windows.Forms.Panel OutputPanel;
        private System.Windows.Forms.Button ShowSettingsButton;
        private System.Windows.Forms.Button MqttButton;
    }
}