namespace OOTMPTracker
{
    partial class PlayersForm
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
            this.playersTitle = new System.Windows.Forms.Label();
            this.playerListText = new System.Windows.Forms.TextBox();
            this.maxPlayersText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playersTitle
            // 
            this.playersTitle.AutoSize = true;
            this.playersTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playersTitle.ForeColor = System.Drawing.Color.White;
            this.playersTitle.Location = new System.Drawing.Point(12, 9);
            this.playersTitle.Name = "playersTitle";
            this.playersTitle.Size = new System.Drawing.Size(77, 28);
            this.playersTitle.TabIndex = 0;
            this.playersTitle.Text = "Players:";
            // 
            // playerListText
            // 
            this.playerListText.BackColor = System.Drawing.Color.Black;
            this.playerListText.Location = new System.Drawing.Point(12, 40);
            this.playerListText.Multiline = true;
            this.playerListText.Name = "playerListText";
            this.playerListText.ReadOnly = true;
            this.playerListText.Size = new System.Drawing.Size(220, 398);
            this.playerListText.TabIndex = 1;
            // 
            // maxPlayersText
            // 
            this.maxPlayersText.AutoSize = true;
            this.maxPlayersText.BackColor = System.Drawing.Color.Black;
            this.maxPlayersText.ForeColor = System.Drawing.Color.White;
            this.maxPlayersText.Location = new System.Drawing.Point(150, 20);
            this.maxPlayersText.Name = "maxPlayersText";
            this.maxPlayersText.Size = new System.Drawing.Size(82, 15);
            this.maxPlayersText.TabIndex = 2;
            this.maxPlayersText.Text = "Max Players: 0";
            // 
            // PlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(244, 450);
            this.Controls.Add(this.maxPlayersText);
            this.Controls.Add(this.playerListText);
            this.Controls.Add(this.playersTitle);
            this.Name = "PlayersForm";
            this.Text = "Player List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label playersTitle;
        private TextBox playerListText;
        private Label maxPlayersText;
    }
}