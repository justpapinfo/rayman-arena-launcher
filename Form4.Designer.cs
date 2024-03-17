namespace luncher_rayman_aréna
{
    partial class Form4
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CaseHDVersion = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BoutonTelchargement = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LabMessageTel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BoutonValidaton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(650, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(40, 92);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // CaseHDVersion
            // 
            this.CaseHDVersion.AutoSize = true;
            this.CaseHDVersion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.CaseHDVersion.Location = new System.Drawing.Point(230, 88);
            this.CaseHDVersion.Name = "CaseHDVersion";
            this.CaseHDVersion.Size = new System.Drawing.Size(103, 22);
            this.CaseHDVersion.TabIndex = 2;
            this.CaseHDVersion.Text = "Version HD";
            this.CaseHDVersion.UseVisualStyleBackColor = true;
            this.CaseHDVersion.CheckedChanged += new System.EventHandler(this.CaseHDVersion_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BoutonTelchargement);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CaseHDVersion);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(245, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 199);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Version à telecharger";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Version normal( SD)";
            // 
            // BoutonTelchargement
            // 
            this.BoutonTelchargement.BackColor = System.Drawing.Color.OliveDrab;
            this.BoutonTelchargement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BoutonTelchargement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoutonTelchargement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoutonTelchargement.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BoutonTelchargement.Location = new System.Drawing.Point(103, 141);
            this.BoutonTelchargement.Name = "BoutonTelchargement";
            this.BoutonTelchargement.Size = new System.Drawing.Size(180, 38);
            this.BoutonTelchargement.TabIndex = 5;
            this.BoutonTelchargement.Text = "Telechargement";
            this.BoutonTelchargement.UseVisualStyleBackColor = false;
            this.BoutonTelchargement.Click += new System.EventHandler(this.BoutonTelchargement_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "désiré telecharger";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Veuillez choisir la ou les version du jeux que vous ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(255, 324);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(339, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // LabMessageTel
            // 
            this.LabMessageTel.AutoSize = true;
            this.LabMessageTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabMessageTel.ForeColor = System.Drawing.Color.Red;
            this.LabMessageTel.Location = new System.Drawing.Point(84, 283);
            this.LabMessageTel.Name = "LabMessageTel";
            this.LabMessageTel.Size = new System.Drawing.Size(216, 13);
            this.LabMessageTel.TabIndex = 5;
            this.LabMessageTel.Text = "Telechargement en cours , veuillez patienter";
            this.LabMessageTel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(239, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(365, 34);
            this.label4.TabIndex = 6;
            this.label4.Text = "Centre de telechargement";
            // 
            // BoutonValidaton
            // 
            this.BoutonValidaton.BackColor = System.Drawing.Color.OliveDrab;
            this.BoutonValidaton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BoutonValidaton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoutonValidaton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoutonValidaton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BoutonValidaton.Location = new System.Drawing.Point(589, 382);
            this.BoutonValidaton.Name = "BoutonValidaton";
            this.BoutonValidaton.Size = new System.Drawing.Size(180, 38);
            this.BoutonValidaton.TabIndex = 7;
            this.BoutonValidaton.Text = "OK";
            this.BoutonValidaton.UseVisualStyleBackColor = false;
            this.BoutonValidaton.Visible = false;
            this.BoutonValidaton.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::luncher_rayman_aréna.Properties.Resources.RayArenaDefOnline113logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 110);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "(2 go)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "(6 go)";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BoutonValidaton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabMessageTel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.Text = "55";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox CaseHDVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BoutonTelchargement;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LabMessageTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BoutonValidaton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}