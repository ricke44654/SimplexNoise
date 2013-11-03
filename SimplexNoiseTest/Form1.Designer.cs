namespace SimplexNoiseTest
{
    partial class Form1
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
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.butGenerate = new System.Windows.Forms.Button();
            this.pbNoise = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXResolution = new System.Windows.Forms.TextBox();
            this.txtYResolution = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersistence = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLargestFeature = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckInvert = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGeneratedSeed = new System.Windows.Forms.TextBox();
            this.ckColorize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoise)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seed:";
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(54, 6);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(64, 20);
            this.txtSeed.TabIndex = 0;
            // 
            // butGenerate
            // 
            this.butGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGenerate.Location = new System.Drawing.Point(630, 4);
            this.butGenerate.Name = "butGenerate";
            this.butGenerate.Size = new System.Drawing.Size(99, 23);
            this.butGenerate.TabIndex = 8;
            this.butGenerate.Text = "Generate";
            this.butGenerate.UseVisualStyleBackColor = true;
            this.butGenerate.Click += new System.EventHandler(this.butGenerate_Click);
            // 
            // pbNoise
            // 
            this.pbNoise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNoise.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbNoise.Location = new System.Drawing.Point(12, 67);
            this.pbNoise.Name = "pbNoise";
            this.pbNoise.Size = new System.Drawing.Size(717, 526);
            this.pbNoise.TabIndex = 3;
            this.pbNoise.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X Res:";
            // 
            // txtXResolution
            // 
            this.txtXResolution.Location = new System.Drawing.Point(170, 6);
            this.txtXResolution.Name = "txtXResolution";
            this.txtXResolution.Size = new System.Drawing.Size(45, 20);
            this.txtXResolution.TabIndex = 1;
            // 
            // txtYResolution
            // 
            this.txtYResolution.Location = new System.Drawing.Point(276, 6);
            this.txtYResolution.Name = "txtYResolution";
            this.txtYResolution.Size = new System.Drawing.Size(45, 20);
            this.txtYResolution.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y Res:";
            // 
            // txtPersistence
            // 
            this.txtPersistence.Location = new System.Drawing.Point(410, 6);
            this.txtPersistence.Name = "txtPersistence";
            this.txtPersistence.Size = new System.Drawing.Size(50, 20);
            this.txtPersistence.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Persistence:";
            // 
            // txtLargestFeature
            // 
            this.txtLargestFeature.Location = new System.Drawing.Point(564, 6);
            this.txtLargestFeature.Name = "txtLargestFeature";
            this.txtLargestFeature.Size = new System.Drawing.Size(50, 20);
            this.txtLargestFeature.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Largest Feature:";
            // 
            // ckInvert
            // 
            this.ckInvert.AutoSize = true;
            this.ckInvert.Location = new System.Drawing.Point(276, 37);
            this.ckInvert.Name = "ckInvert";
            this.ckInvert.Size = new System.Drawing.Size(91, 17);
            this.ckInvert.TabIndex = 6;
            this.ckInvert.Text = "Invert Results";
            this.ckInvert.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Generated Seed:";
            // 
            // txtGeneratedSeed
            // 
            this.txtGeneratedSeed.Location = new System.Drawing.Point(107, 35);
            this.txtGeneratedSeed.Name = "txtGeneratedSeed";
            this.txtGeneratedSeed.ReadOnly = true;
            this.txtGeneratedSeed.Size = new System.Drawing.Size(119, 20);
            this.txtGeneratedSeed.TabIndex = 5;
            // 
            // ckColorize
            // 
            this.ckColorize.AutoSize = true;
            this.ckColorize.Location = new System.Drawing.Point(410, 38);
            this.ckColorize.Name = "ckColorize";
            this.ckColorize.Size = new System.Drawing.Size(63, 17);
            this.ckColorize.TabIndex = 7;
            this.ckColorize.Text = "Colorize";
            this.ckColorize.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.butGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 605);
            this.Controls.Add(this.ckColorize);
            this.Controls.Add(this.txtGeneratedSeed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckInvert);
            this.Controls.Add(this.txtLargestFeature);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPersistence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtYResolution);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXResolution);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbNoise);
            this.Controls.Add(this.butGenerate);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbNoise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Button butGenerate;
        private System.Windows.Forms.PictureBox pbNoise;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXResolution;
        private System.Windows.Forms.TextBox txtYResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersistence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLargestFeature;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckInvert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGeneratedSeed;
        private System.Windows.Forms.CheckBox ckColorize;
    }
}

