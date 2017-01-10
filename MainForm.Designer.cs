namespace JagerSimulation1
{
    partial class MainForm
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
            this.pnlGraphics = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnStartSAM = new System.Windows.Forms.Button();
            this.btnHeatSAM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlGraphics
            // 
            this.pnlGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGraphics.BackColor = System.Drawing.Color.White;
            this.pnlGraphics.Location = new System.Drawing.Point(12, 12);
            this.pnlGraphics.Name = "pnlGraphics";
            this.pnlGraphics.Size = new System.Drawing.Size(701, 433);
            this.pnlGraphics.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(412, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(331, 451);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStartSAM
            // 
            this.btnStartSAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartSAM.Location = new System.Drawing.Point(635, 451);
            this.btnStartSAM.Name = "btnStartSAM";
            this.btnStartSAM.Size = new System.Drawing.Size(75, 23);
            this.btnStartSAM.TabIndex = 3;
            this.btnStartSAM.Text = "SAM";
            this.btnStartSAM.UseVisualStyleBackColor = true;
            this.btnStartSAM.Click += new System.EventHandler(this.btnStartSAM_Click);
            // 
            // btnHeatSAM
            // 
            this.btnHeatSAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeatSAM.Location = new System.Drawing.Point(554, 451);
            this.btnHeatSAM.Name = "btnHeatSAM";
            this.btnHeatSAM.Size = new System.Drawing.Size(75, 23);
            this.btnHeatSAM.TabIndex = 4;
            this.btnHeatSAM.Text = "Heat SAM";
            this.btnHeatSAM.UseVisualStyleBackColor = true;
            this.btnHeatSAM.Click += new System.EventHandler(this.btnHeatSAM_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 486);
            this.Controls.Add(this.btnHeatSAM);
            this.Controls.Add(this.btnStartSAM);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlGraphics);
            this.Name = "MainForm";
            this.Text = "Jager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGraphics;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnStartSAM;
        private System.Windows.Forms.Button btnHeatSAM;
    }
}

