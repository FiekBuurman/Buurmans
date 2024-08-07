﻿namespace Buurmans.AmbiLight.Form.Views
{
    partial class SettingsView
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
            this.ResetSettingsButton = new System.Windows.Forms.Button();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.DelayInMillisecondsLabel = new System.Windows.Forms.Label();
            this.DelayInMillisecondsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PixelSkipStepsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PixelSkipStepsLabel = new System.Windows.Forms.Label();
            this.ColorSettingsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SelectAllColorsButton = new System.Windows.Forms.Button();
            this.SelectNoneColorsButton = new System.Windows.Forms.Button();
            this.BrokerTextBox = new System.Windows.Forms.TextBox();
            this.BrokerLabel = new System.Windows.Forms.Label();
            this.ClientIdLabel = new System.Windows.Forms.Label();
            this.ClientIdTextBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.TopicLabel = new System.Windows.Forms.Label();
            this.TopicTextBox = new System.Windows.Forms.TextBox();
            this.PortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PortLabel = new System.Windows.Forms.Label();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.TimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MqttSettingsPanel = new System.Windows.Forms.Panel();
            this.TestMqttButton = new System.Windows.Forms.Button();
            this.MqttSettingsHeaderLabel = new System.Windows.Forms.Label();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.ColorSettingLabel = new System.Windows.Forms.Label();
            this.CaptureSettingsPanel = new System.Windows.Forms.Panel();
            this.CaptureSettingsLabel = new System.Windows.Forms.Label();
            this.DebugSettingsLabel = new System.Windows.Forms.Label();
            this.DebugSettingsPanel = new System.Windows.Forms.Panel();
            this.LogLevelDescriptionLabel = new System.Windows.Forms.Label();
            this.LogLevelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.LogLevelTypLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DelayInMillisecondsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelSkipStepsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            this.MqttSettingsPanel.SuspendLayout();
            this.ColorPanel.SuspendLayout();
            this.CaptureSettingsPanel.SuspendLayout();
            this.DebugSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResetSettingsButton
            // 
            this.ResetSettingsButton.Location = new System.Drawing.Point(364, 406);
            this.ResetSettingsButton.Name = "ResetSettingsButton";
            this.ResetSettingsButton.Size = new System.Drawing.Size(171, 50);
            this.ResetSettingsButton.TabIndex = 1;
            this.ResetSettingsButton.Text = "Reset";
            this.ResetSettingsButton.UseVisualStyleBackColor = true;
            this.ResetSettingsButton.Click += new System.EventHandler(this.ResetSettingsButton_Click);
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Location = new System.Drawing.Point(547, 406);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(171, 50);
            this.SaveSettingsButton.TabIndex = 2;
            this.SaveSettingsButton.Text = "Save && Close";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // DelayInMillisecondsLabel
            // 
            this.DelayInMillisecondsLabel.AutoSize = true;
            this.DelayInMillisecondsLabel.Location = new System.Drawing.Point(179, 44);
            this.DelayInMillisecondsLabel.Name = "DelayInMillisecondsLabel";
            this.DelayInMillisecondsLabel.Size = new System.Drawing.Size(75, 13);
            this.DelayInMillisecondsLabel.TabIndex = 3;
            this.DelayInMillisecondsLabel.Text = "Capture delay:";
            this.DelayInMillisecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DelayInMillisecondsNumericUpDown
            // 
            this.DelayInMillisecondsNumericUpDown.Location = new System.Drawing.Point(260, 42);
            this.DelayInMillisecondsNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.DelayInMillisecondsNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DelayInMillisecondsNumericUpDown.Name = "DelayInMillisecondsNumericUpDown";
            this.DelayInMillisecondsNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.DelayInMillisecondsNumericUpDown.TabIndex = 4;
            this.DelayInMillisecondsNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // PixelSkipStepsNumericUpDown
            // 
            this.PixelSkipStepsNumericUpDown.Location = new System.Drawing.Point(260, 68);
            this.PixelSkipStepsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PixelSkipStepsNumericUpDown.Name = "PixelSkipStepsNumericUpDown";
            this.PixelSkipStepsNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.PixelSkipStepsNumericUpDown.TabIndex = 6;
            this.PixelSkipStepsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PixelSkipStepsLabel
            // 
            this.PixelSkipStepsLabel.AutoSize = true;
            this.PixelSkipStepsLabel.Location = new System.Drawing.Point(197, 70);
            this.PixelSkipStepsLabel.Name = "PixelSkipStepsLabel";
            this.PixelSkipStepsLabel.Size = new System.Drawing.Size(54, 13);
            this.PixelSkipStepsLabel.TabIndex = 5;
            this.PixelSkipStepsLabel.Text = "Pixel Step";
            this.PixelSkipStepsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ColorSettingsPanel
            // 
            this.ColorSettingsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.ColorSettingsPanel.ColumnCount = 3;
            this.ColorSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColorSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColorSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ColorSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ColorSettingsPanel.Location = new System.Drawing.Point(4, 44);
            this.ColorSettingsPanel.Name = "ColorSettingsPanel";
            this.ColorSettingsPanel.RowCount = 8;
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorSettingsPanel.Size = new System.Drawing.Size(338, 265);
            this.ColorSettingsPanel.TabIndex = 10;
            // 
            // SelectAllColorsButton
            // 
            this.SelectAllColorsButton.Location = new System.Drawing.Point(5, 314);
            this.SelectAllColorsButton.Name = "SelectAllColorsButton";
            this.SelectAllColorsButton.Size = new System.Drawing.Size(166, 22);
            this.SelectAllColorsButton.TabIndex = 11;
            this.SelectAllColorsButton.Text = "Select All";
            this.SelectAllColorsButton.UseVisualStyleBackColor = true;
            this.SelectAllColorsButton.Click += new System.EventHandler(this.SelectAllColorsButton_Click);
            // 
            // SelectNoneColorsButton
            // 
            this.SelectNoneColorsButton.Location = new System.Drawing.Point(177, 314);
            this.SelectNoneColorsButton.Name = "SelectNoneColorsButton";
            this.SelectNoneColorsButton.Size = new System.Drawing.Size(166, 22);
            this.SelectNoneColorsButton.TabIndex = 12;
            this.SelectNoneColorsButton.Text = "Select None";
            this.SelectNoneColorsButton.UseVisualStyleBackColor = true;
            this.SelectNoneColorsButton.Click += new System.EventHandler(this.SelectNoneColorsButton_Click);
            // 
            // BrokerTextBox
            // 
            this.BrokerTextBox.Location = new System.Drawing.Point(121, 60);
            this.BrokerTextBox.Name = "BrokerTextBox";
            this.BrokerTextBox.Size = new System.Drawing.Size(200, 20);
            this.BrokerTextBox.TabIndex = 14;
            // 
            // BrokerLabel
            // 
            this.BrokerLabel.AutoSize = true;
            this.BrokerLabel.Location = new System.Drawing.Point(30, 63);
            this.BrokerLabel.Name = "BrokerLabel";
            this.BrokerLabel.Size = new System.Drawing.Size(41, 13);
            this.BrokerLabel.TabIndex = 15;
            this.BrokerLabel.Text = "Broker:";
            // 
            // ClientIdLabel
            // 
            this.ClientIdLabel.AutoSize = true;
            this.ClientIdLabel.Location = new System.Drawing.Point(30, 141);
            this.ClientIdLabel.Name = "ClientIdLabel";
            this.ClientIdLabel.Size = new System.Drawing.Size(42, 13);
            this.ClientIdLabel.TabIndex = 17;
            this.ClientIdLabel.Text = "ClientId";
            // 
            // ClientIdTextBox
            // 
            this.ClientIdTextBox.Location = new System.Drawing.Point(121, 138);
            this.ClientIdTextBox.Name = "ClientIdTextBox";
            this.ClientIdTextBox.Size = new System.Drawing.Size(200, 20);
            this.ClientIdTextBox.TabIndex = 16;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(30, 167);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(60, 13);
            this.UserNameLabel.TabIndex = 19;
            this.UserNameLabel.Text = "UserName:";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(121, 164);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.UserNameTextBox.TabIndex = 18;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(30, 193);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswordLabel.TabIndex = 21;
            this.PasswordLabel.Text = "Password:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(121, 190);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(200, 20);
            this.PasswordTextBox.TabIndex = 20;
            // 
            // TopicLabel
            // 
            this.TopicLabel.AutoSize = true;
            this.TopicLabel.Location = new System.Drawing.Point(30, 219);
            this.TopicLabel.Name = "TopicLabel";
            this.TopicLabel.Size = new System.Drawing.Size(37, 13);
            this.TopicLabel.TabIndex = 23;
            this.TopicLabel.Text = "Topic:";
            // 
            // TopicTextBox
            // 
            this.TopicTextBox.Location = new System.Drawing.Point(121, 216);
            this.TopicTextBox.Name = "TopicTextBox";
            this.TopicTextBox.Size = new System.Drawing.Size(200, 20);
            this.TopicTextBox.TabIndex = 22;
            // 
            // PortNumericUpDown
            // 
            this.PortNumericUpDown.Location = new System.Drawing.Point(246, 86);
            this.PortNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.PortNumericUpDown.Name = "PortNumericUpDown";
            this.PortNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.PortNumericUpDown.TabIndex = 25;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(30, 88);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(80, 13);
            this.PortLabel.TabIndex = 26;
            this.PortLabel.Text = "Port: (0 = none)";
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.AutoSize = true;
            this.TimeoutLabel.Location = new System.Drawing.Point(30, 114);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(48, 13);
            this.TimeoutLabel.TabIndex = 28;
            this.TimeoutLabel.Text = "Timeout:";
            // 
            // TimeoutNumericUpDown
            // 
            this.TimeoutNumericUpDown.Location = new System.Drawing.Point(246, 112);
            this.TimeoutNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.TimeoutNumericUpDown.TabIndex = 27;
            this.TimeoutNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // MqttSettingsPanel
            // 
            this.MqttSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MqttSettingsPanel.Controls.Add(this.TestMqttButton);
            this.MqttSettingsPanel.Controls.Add(this.MqttSettingsHeaderLabel);
            this.MqttSettingsPanel.Controls.Add(this.BrokerTextBox);
            this.MqttSettingsPanel.Controls.Add(this.TimeoutLabel);
            this.MqttSettingsPanel.Controls.Add(this.BrokerLabel);
            this.MqttSettingsPanel.Controls.Add(this.TimeoutNumericUpDown);
            this.MqttSettingsPanel.Controls.Add(this.ClientIdTextBox);
            this.MqttSettingsPanel.Controls.Add(this.PortLabel);
            this.MqttSettingsPanel.Controls.Add(this.ClientIdLabel);
            this.MqttSettingsPanel.Controls.Add(this.PortNumericUpDown);
            this.MqttSettingsPanel.Controls.Add(this.UserNameTextBox);
            this.MqttSettingsPanel.Controls.Add(this.TopicLabel);
            this.MqttSettingsPanel.Controls.Add(this.UserNameLabel);
            this.MqttSettingsPanel.Controls.Add(this.TopicTextBox);
            this.MqttSettingsPanel.Controls.Add(this.PasswordTextBox);
            this.MqttSettingsPanel.Controls.Add(this.PasswordLabel);
            this.MqttSettingsPanel.Location = new System.Drawing.Point(364, 115);
            this.MqttSettingsPanel.Name = "MqttSettingsPanel";
            this.MqttSettingsPanel.Size = new System.Drawing.Size(354, 275);
            this.MqttSettingsPanel.TabIndex = 29;
            // 
            // TestMqttButton
            // 
            this.TestMqttButton.Location = new System.Drawing.Point(246, 243);
            this.TestMqttButton.Name = "TestMqttButton";
            this.TestMqttButton.Size = new System.Drawing.Size(75, 22);
            this.TestMqttButton.TabIndex = 30;
            this.TestMqttButton.Text = "Test MQTT";
            this.TestMqttButton.UseVisualStyleBackColor = true;
            this.TestMqttButton.Click += new System.EventHandler(this.TestMqttButton_Click);
            // 
            // MqttSettingsHeaderLabel
            // 
            this.MqttSettingsHeaderLabel.AutoSize = true;
            this.MqttSettingsHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MqttSettingsHeaderLabel.Location = new System.Drawing.Point(87, 5);
            this.MqttSettingsHeaderLabel.Name = "MqttSettingsHeaderLabel";
            this.MqttSettingsHeaderLabel.Size = new System.Drawing.Size(176, 25);
            this.MqttSettingsHeaderLabel.TabIndex = 29;
            this.MqttSettingsHeaderLabel.Text = "MQTT Settings:";
            this.MqttSettingsHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorPanel
            // 
            this.ColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPanel.Controls.Add(this.ColorSettingLabel);
            this.ColorPanel.Controls.Add(this.ColorSettingsPanel);
            this.ColorPanel.Controls.Add(this.SelectAllColorsButton);
            this.ColorPanel.Controls.Add(this.SelectNoneColorsButton);
            this.ColorPanel.Location = new System.Drawing.Point(8, 115);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(350, 341);
            this.ColorPanel.TabIndex = 30;
            // 
            // ColorSettingLabel
            // 
            this.ColorSettingLabel.AutoSize = true;
            this.ColorSettingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorSettingLabel.Location = new System.Drawing.Point(75, 9);
            this.ColorSettingLabel.Name = "ColorSettingLabel";
            this.ColorSettingLabel.Size = new System.Drawing.Size(176, 25);
            this.ColorSettingLabel.TabIndex = 31;
            this.ColorSettingLabel.Text = "Allowed Colors:";
            this.ColorSettingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CaptureSettingsPanel
            // 
            this.CaptureSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CaptureSettingsPanel.Controls.Add(this.CaptureSettingsLabel);
            this.CaptureSettingsPanel.Controls.Add(this.PixelSkipStepsNumericUpDown);
            this.CaptureSettingsPanel.Controls.Add(this.DelayInMillisecondsLabel);
            this.CaptureSettingsPanel.Controls.Add(this.DelayInMillisecondsNumericUpDown);
            this.CaptureSettingsPanel.Controls.Add(this.PixelSkipStepsLabel);
            this.CaptureSettingsPanel.Location = new System.Drawing.Point(8, 9);
            this.CaptureSettingsPanel.Name = "CaptureSettingsPanel";
            this.CaptureSettingsPanel.Size = new System.Drawing.Size(350, 100);
            this.CaptureSettingsPanel.TabIndex = 31;
            // 
            // CaptureSettingsLabel
            // 
            this.CaptureSettingsLabel.AutoSize = true;
            this.CaptureSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptureSettingsLabel.Location = new System.Drawing.Point(81, 5);
            this.CaptureSettingsLabel.Name = "CaptureSettingsLabel";
            this.CaptureSettingsLabel.Size = new System.Drawing.Size(195, 25);
            this.CaptureSettingsLabel.TabIndex = 31;
            this.CaptureSettingsLabel.Text = "Capture Settings:";
            this.CaptureSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DebugSettingsLabel
            // 
            this.DebugSettingsLabel.AutoSize = true;
            this.DebugSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugSettingsLabel.Location = new System.Drawing.Point(81, 5);
            this.DebugSettingsLabel.Name = "DebugSettingsLabel";
            this.DebugSettingsLabel.Size = new System.Drawing.Size(180, 25);
            this.DebugSettingsLabel.TabIndex = 31;
            this.DebugSettingsLabel.Text = "Debug Settings:";
            this.DebugSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DebugSettingsPanel
            // 
            this.DebugSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DebugSettingsPanel.Controls.Add(this.LogLevelDescriptionLabel);
            this.DebugSettingsPanel.Controls.Add(this.LogLevelTypeComboBox);
            this.DebugSettingsPanel.Controls.Add(this.DebugSettingsLabel);
            this.DebugSettingsPanel.Controls.Add(this.LogLevelTypLabel);
            this.DebugSettingsPanel.Location = new System.Drawing.Point(364, 9);
            this.DebugSettingsPanel.Name = "DebugSettingsPanel";
            this.DebugSettingsPanel.Size = new System.Drawing.Size(350, 100);
            this.DebugSettingsPanel.TabIndex = 32;
            // 
            // LogLevelDescriptionLabel
            // 
            this.LogLevelDescriptionLabel.Location = new System.Drawing.Point(3, 71);
            this.LogLevelDescriptionLabel.Name = "LogLevelDescriptionLabel";
            this.LogLevelDescriptionLabel.Size = new System.Drawing.Size(346, 25);
            this.LogLevelDescriptionLabel.TabIndex = 33;
            this.LogLevelDescriptionLabel.Text = "Currently Logging: Info, warnings && Errors";
            this.LogLevelDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogLevelTypeComboBox
            // 
            this.LogLevelTypeComboBox.FormattingEnabled = true;
            this.LogLevelTypeComboBox.Location = new System.Drawing.Point(200, 41);
            this.LogLevelTypeComboBox.Name = "LogLevelTypeComboBox";
            this.LogLevelTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.LogLevelTypeComboBox.TabIndex = 32;
            this.LogLevelTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.LogLevelTypeComboBox_SelectedIndexChanged);
            // 
            // LogLevelTypLabel
            // 
            this.LogLevelTypLabel.AutoSize = true;
            this.LogLevelTypLabel.Location = new System.Drawing.Point(141, 44);
            this.LogLevelTypLabel.Name = "LogLevelTypLabel";
            this.LogLevelTypLabel.Size = new System.Drawing.Size(53, 13);
            this.LogLevelTypLabel.TabIndex = 3;
            this.LogLevelTypLabel.Text = "Log level:";
            this.LogLevelTypLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 465);
            this.Controls.Add(this.DebugSettingsPanel);
            this.Controls.Add(this.CaptureSettingsPanel);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.MqttSettingsPanel);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.ResetSettingsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.SettingsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DelayInMillisecondsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelSkipStepsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            this.MqttSettingsPanel.ResumeLayout(false);
            this.MqttSettingsPanel.PerformLayout();
            this.ColorPanel.ResumeLayout(false);
            this.ColorPanel.PerformLayout();
            this.CaptureSettingsPanel.ResumeLayout(false);
            this.CaptureSettingsPanel.PerformLayout();
            this.DebugSettingsPanel.ResumeLayout(false);
            this.DebugSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ResetSettingsButton;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.Label DelayInMillisecondsLabel;
        private System.Windows.Forms.NumericUpDown DelayInMillisecondsNumericUpDown;
        private System.Windows.Forms.NumericUpDown PixelSkipStepsNumericUpDown;
        private System.Windows.Forms.Label PixelSkipStepsLabel;
        private System.Windows.Forms.TableLayoutPanel ColorSettingsPanel;
        private System.Windows.Forms.Button SelectAllColorsButton;
        private System.Windows.Forms.Button SelectNoneColorsButton;
        private System.Windows.Forms.TextBox BrokerTextBox;
        private System.Windows.Forms.Label BrokerLabel;
        private System.Windows.Forms.Label ClientIdLabel;
        private System.Windows.Forms.TextBox ClientIdTextBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label TopicLabel;
        private System.Windows.Forms.TextBox TopicTextBox;
        private System.Windows.Forms.NumericUpDown PortNumericUpDown;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.NumericUpDown TimeoutNumericUpDown;
        private System.Windows.Forms.Panel MqttSettingsPanel;
        private System.Windows.Forms.Label MqttSettingsHeaderLabel;
        private System.Windows.Forms.Button TestMqttButton;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Label ColorSettingLabel;
        private System.Windows.Forms.Panel CaptureSettingsPanel;
        private System.Windows.Forms.Label CaptureSettingsLabel;
        private System.Windows.Forms.Label DebugSettingsLabel;
        private System.Windows.Forms.Panel DebugSettingsPanel;
        private System.Windows.Forms.Label LogLevelTypLabel;
        private System.Windows.Forms.ComboBox LogLevelTypeComboBox;
        private System.Windows.Forms.Label LogLevelDescriptionLabel;
    }
}