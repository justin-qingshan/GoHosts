namespace GoHosts
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
            this.update = new System.Windows.Forms.Button();
            this.Label_LastUpdate = new System.Windows.Forms.Label();
            this.Label_Size = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(15, 61);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 21);
            this.update.TabIndex = 0;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // Label_LastUpdate
            // 
            this.Label_LastUpdate.AutoSize = true;
            this.Label_LastUpdate.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LastUpdate.Location = new System.Drawing.Point(12, 8);
            this.Label_LastUpdate.Name = "Label_LastUpdate";
            this.Label_LastUpdate.Size = new System.Drawing.Size(100, 16);
            this.Label_LastUpdate.TabIndex = 2;
            this.Label_LastUpdate.Text = "Lable_LastUpdate";
            // 
            // Label_Size
            // 
            this.Label_Size.AutoSize = true;
            this.Label_Size.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Size.Location = new System.Drawing.Point(12, 25);
            this.Label_Size.Name = "Label_Size";
            this.Label_Size.Size = new System.Drawing.Size(61, 16);
            this.Label_Size.TabIndex = 2;
            this.Label_Size.Text = "Label_Size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 241);
            this.Controls.Add(this.Label_Size);
            this.Controls.Add(this.Label_LastUpdate);
            this.Controls.Add(this.update);
            this.Name = "Form1";
            this.Text = "GoHosts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label Label_LastUpdate;
        private System.Windows.Forms.Label Label_Size;
    }
}

