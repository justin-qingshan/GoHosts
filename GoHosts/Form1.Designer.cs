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
            this.Label_Location = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(55, 163);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 0;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // Label_LastUpdate
            // 
            this.Label_LastUpdate.AutoSize = true;
            this.Label_LastUpdate.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LastUpdate.Location = new System.Drawing.Point(102, 8);
            this.Label_LastUpdate.Name = "Label_LastUpdate";
            this.Label_LastUpdate.Size = new System.Drawing.Size(100, 16);
            this.Label_LastUpdate.TabIndex = 2;
            this.Label_LastUpdate.Text = "Lable_LastUpdate";
            // 
            // Label_Size
            // 
            this.Label_Size.AutoSize = true;
            this.Label_Size.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Size.Location = new System.Drawing.Point(102, 23);
            this.Label_Size.Name = "Label_Size";
            this.Label_Size.Size = new System.Drawing.Size(61, 16);
            this.Label_Size.TabIndex = 2;
            this.Label_Size.Text = "Label_Size";
            // 
            // Label_Location
            // 
            this.Label_Location.AutoSize = true;
            this.Label_Location.Location = new System.Drawing.Point(102, 40);
            this.Label_Location.Name = "Label_Location";
            this.Label_Location.Size = new System.Drawing.Size(80, 13);
            this.Label_Location.TabIndex = 3;
            this.Label_Location.Text = "Label_Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "上次更新时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hosts文件大小：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "hosts文件位置：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label_Location);
            this.Controls.Add(this.Label_Size);
            this.Controls.Add(this.Label_LastUpdate);
            this.Controls.Add(this.update);
            this.Name = "Form1";
            this.Text = "GoHosts";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label Label_LastUpdate;
        private System.Windows.Forms.Label Label_Size;
        private System.Windows.Forms.Label Label_Location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

