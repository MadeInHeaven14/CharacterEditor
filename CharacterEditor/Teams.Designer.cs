namespace CharacterEditor
{
    partial class Teams
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_SecondTeam = new System.Windows.Forms.ListBox();
            this.lb_FirstTeam = new System.Windows.Forms.ListBox();
            this.lb_AllCharacters = new System.Windows.Forms.ListBox();
            this.button_Teams = new System.Windows.Forms.Button();
            this.label_FirstTeam = new System.Windows.Forms.Label();
            this.label_AllCharacters = new System.Windows.Forms.Label();
            this.label_SecondTeam = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label_SecondTeam);
            this.panel1.Controls.Add(this.label_AllCharacters);
            this.panel1.Controls.Add(this.label_FirstTeam);
            this.panel1.Controls.Add(this.lb_SecondTeam);
            this.panel1.Controls.Add(this.lb_FirstTeam);
            this.panel1.Controls.Add(this.lb_AllCharacters);
            this.panel1.Controls.Add(this.button_Teams);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 495);
            this.panel1.TabIndex = 0;
            // 
            // lb_SecondTeam
            // 
            this.lb_SecondTeam.FormattingEnabled = true;
            this.lb_SecondTeam.ItemHeight = 20;
            this.lb_SecondTeam.Location = new System.Drawing.Point(848, 66);
            this.lb_SecondTeam.Name = "lb_SecondTeam";
            this.lb_SecondTeam.Size = new System.Drawing.Size(326, 324);
            this.lb_SecondTeam.TabIndex = 27;
            // 
            // lb_FirstTeam
            // 
            this.lb_FirstTeam.FormattingEnabled = true;
            this.lb_FirstTeam.ItemHeight = 20;
            this.lb_FirstTeam.Location = new System.Drawing.Point(47, 66);
            this.lb_FirstTeam.Name = "lb_FirstTeam";
            this.lb_FirstTeam.Size = new System.Drawing.Size(326, 324);
            this.lb_FirstTeam.TabIndex = 26;
            // 
            // lb_AllCharacters
            // 
            this.lb_AllCharacters.FormattingEnabled = true;
            this.lb_AllCharacters.ItemHeight = 20;
            this.lb_AllCharacters.Location = new System.Drawing.Point(451, 66);
            this.lb_AllCharacters.Name = "lb_AllCharacters";
            this.lb_AllCharacters.Size = new System.Drawing.Size(326, 324);
            this.lb_AllCharacters.TabIndex = 25;
            // 
            // button_Teams
            // 
            this.button_Teams.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Teams.Location = new System.Drawing.Point(517, 409);
            this.button_Teams.Name = "button_Teams";
            this.button_Teams.Size = new System.Drawing.Size(203, 63);
            this.button_Teams.TabIndex = 24;
            this.button_Teams.Text = "Автораспределение";
            this.button_Teams.UseVisualStyleBackColor = true;
            this.button_Teams.Click += new System.EventHandler(this.button_Teams_Click);
            // 
            // label_FirstTeam
            // 
            this.label_FirstTeam.AutoSize = true;
            this.label_FirstTeam.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_FirstTeam.Location = new System.Drawing.Point(138, 9);
            this.label_FirstTeam.Name = "label_FirstTeam";
            this.label_FirstTeam.Size = new System.Drawing.Size(123, 31);
            this.label_FirstTeam.TabIndex = 28;
            this.label_FirstTeam.Text = "First Team";
            // 
            // label_AllCharacters
            // 
            this.label_AllCharacters.AutoSize = true;
            this.label_AllCharacters.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_AllCharacters.Location = new System.Drawing.Point(547, 9);
            this.label_AllCharacters.Name = "label_AllCharacters";
            this.label_AllCharacters.Size = new System.Drawing.Size(162, 31);
            this.label_AllCharacters.TabIndex = 29;
            this.label_AllCharacters.Text = "All Characters";
            // 
            // label_SecondTeam
            // 
            this.label_SecondTeam.AutoSize = true;
            this.label_SecondTeam.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_SecondTeam.Location = new System.Drawing.Point(948, 9);
            this.label_SecondTeam.Name = "label_SecondTeam";
            this.label_SecondTeam.Size = new System.Drawing.Size(154, 31);
            this.label_SecondTeam.TabIndex = 30;
            this.label_SecondTeam.Text = "Second Team";
            // 
            // Teams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 495);
            this.Controls.Add(this.panel1);
            this.Name = "Teams";
            this.Text = "Teams";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button_Teams;
        private ListBox lb_SecondTeam;
        private ListBox lb_FirstTeam;
        private ListBox lb_AllCharacters;
        private Label label_SecondTeam;
        private Label label_AllCharacters;
        private Label label_FirstTeam;
    }
}