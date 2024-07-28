namespace Buurmans.AmbiLight.Form.Views
{
    partial class MqttView
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.PublishMessageButton = new System.Windows.Forms.Button();
            this.OutputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.Disconnectbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 674);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(90, 50);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // PublishMessageButton
            // 
            this.PublishMessageButton.Location = new System.Drawing.Point(218, 674);
            this.PublishMessageButton.Name = "PublishMessageButton";
            this.PublishMessageButton.Size = new System.Drawing.Size(200, 50);
            this.PublishMessageButton.TabIndex = 1;
            this.PublishMessageButton.Text = "Publish Message";
            this.PublishMessageButton.UseVisualStyleBackColor = true;
            this.PublishMessageButton.Click += new System.EventHandler(this.PublishMessageButton_Click);
            // 
            // OutputRichTextBox
            // 
            this.OutputRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OutputRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputRichTextBox.Location = new System.Drawing.Point(12, 342);
            this.OutputRichTextBox.Name = "OutputRichTextBox";
            this.OutputRichTextBox.Size = new System.Drawing.Size(406, 312);
            this.OutputRichTextBox.TabIndex = 2;
            this.OutputRichTextBox.Text = "";
            this.OutputRichTextBox.TextChanged += new System.EventHandler(this.OutputRichTextBox_TextChanged);
            // 
            // Disconnectbutton
            // 
            this.Disconnectbutton.Location = new System.Drawing.Point(108, 674);
            this.Disconnectbutton.Name = "Disconnectbutton";
            this.Disconnectbutton.Size = new System.Drawing.Size(90, 50);
            this.Disconnectbutton.TabIndex = 3;
            this.Disconnectbutton.Text = "Disconnect";
            this.Disconnectbutton.UseVisualStyleBackColor = true;
            this.Disconnectbutton.Click += new System.EventHandler(this.Disconnectbutton_Click);
            // 
            // MqttView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 736);
            this.Controls.Add(this.Disconnectbutton);
            this.Controls.Add(this.OutputRichTextBox);
            this.Controls.Add(this.PublishMessageButton);
            this.Controls.Add(this.ConnectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MqttView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MqttView";
            this.Load += new System.EventHandler(this.MqttView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button PublishMessageButton;
        private System.Windows.Forms.RichTextBox OutputRichTextBox;
        private System.Windows.Forms.Button Disconnectbutton;
    }
}