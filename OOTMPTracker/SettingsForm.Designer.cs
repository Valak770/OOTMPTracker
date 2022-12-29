namespace OOTMPTracker
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.portInput = new System.Windows.Forms.TextBox();
            this.hostButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionsInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(78, 8);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(110, 23);
            this.nameInput.TabIndex = 3;
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(78, 46);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(110, 23);
            this.ipInput.TabIndex = 4;
            // 
            // portInput
            // 
            this.portInput.Location = new System.Drawing.Point(78, 84);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(110, 23);
            this.portInput.TabIndex = 5;
            // 
            // hostButton
            // 
            this.hostButton.Location = new System.Drawing.Point(0, 238);
            this.hostButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(56, 22);
            this.hostButton.TabIndex = 6;
            this.hostButton.Text = "Host";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.hostButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(59, 238);
            this.joinButton.Margin = new System.Windows.Forms.Padding(0);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(56, 22);
            this.joinButton.TabIndex = 7;
            this.joinButton.Text = "Join";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(154, 238);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 22);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max # of Connecting Players";
            // 
            // connectionsInput
            // 
            this.connectionsInput.Location = new System.Drawing.Point(167, 122);
            this.connectionsInput.Name = "connectionsInput";
            this.connectionsInput.Size = new System.Drawing.Size(21, 23);
            this.connectionsInput.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 259);
            this.Controls.Add(this.connectionsInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.hostButton);
            this.Controls.Add(this.portInput);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox nameInput;
        private TextBox ipInput;
        private TextBox portInput;
        private Button hostButton;
        private Button joinButton;
        private Button cancelButton;
        private Label label4;
        private TextBox connectionsInput;
    }
}