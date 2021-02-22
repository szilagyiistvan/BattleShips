
namespace Battleships
{
    partial class BattleshipsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShoot = new System.Windows.Forms.Button();
            this.tbShoot = new System.Windows.Forms.TextBox();
            this.lblShoot = new System.Windows.Forms.Label();
            this.lblShootResult = new System.Windows.Forms.Label();
            this.tbShips = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbShips = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnShoot
            // 
            this.btnShoot.Location = new System.Drawing.Point(244, 12);
            this.btnShoot.Name = "btnShoot";
            this.btnShoot.Size = new System.Drawing.Size(75, 23);
            this.btnShoot.TabIndex = 0;
            this.btnShoot.Text = "Shoot";
            this.btnShoot.UseVisualStyleBackColor = true;
            this.btnShoot.Click += new System.EventHandler(this.btnShoot_Click);
            // 
            // tbShoot
            // 
            this.tbShoot.Location = new System.Drawing.Point(138, 12);
            this.tbShoot.Name = "tbShoot";
            this.tbShoot.Size = new System.Drawing.Size(100, 23);
            this.tbShoot.TabIndex = 1;
            // 
            // lblShoot
            // 
            this.lblShoot.AutoSize = true;
            this.lblShoot.Location = new System.Drawing.Point(25, 16);
            this.lblShoot.Name = "lblShoot";
            this.lblShoot.Size = new System.Drawing.Size(110, 15);
            this.lblShoot.TabIndex = 2;
            this.lblShoot.Text = "Enter field (e.g. A5):";
            // 
            // lblShootResult
            // 
            this.lblShootResult.AutoSize = true;
            this.lblShootResult.Location = new System.Drawing.Point(326, 16);
            this.lblShootResult.Name = "lblShootResult";
            this.lblShootResult.Size = new System.Drawing.Size(0, 15);
            this.lblShootResult.TabIndex = 3;
            // 
            // tbShips
            // 
            this.tbShips.Location = new System.Drawing.Point(508, 16);
            this.tbShips.Multiline = true;
            this.tbShips.Name = "tbShips";
            this.tbShips.ReadOnly = true;
            this.tbShips.Size = new System.Drawing.Size(222, 75);
            this.tbShips.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(427, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Restart";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbShips
            // 
            this.cbShips.AutoSize = true;
            this.cbShips.Location = new System.Drawing.Point(614, 98);
            this.cbShips.Name = "cbShips";
            this.cbShips.Size = new System.Drawing.Size(86, 19);
            this.cbShips.TabIndex = 6;
            this.cbShips.Text = "Show Ships";
            this.cbShips.UseVisualStyleBackColor = true;
            this.cbShips.CheckedChanged += new System.EventHandler(this.cbShips_CheckedChanged);
            // 
            // BattleshipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 531);
            this.Controls.Add(this.cbShips);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tbShips);
            this.Controls.Add(this.lblShootResult);
            this.Controls.Add(this.lblShoot);
            this.Controls.Add(this.tbShoot);
            this.Controls.Add(this.btnShoot);
            this.Name = "BattleshipsForm";
            this.Text = "BattleShips";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShoot;
        private System.Windows.Forms.TextBox tbShoot;
        private System.Windows.Forms.Label lblShoot;
        private System.Windows.Forms.Label lblShootResult;
        private System.Windows.Forms.TextBox tbShips;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox cbShips;
    }
}

