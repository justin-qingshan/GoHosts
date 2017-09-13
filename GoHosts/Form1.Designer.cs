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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.update = new System.Windows.Forms.Button();
            this.Label_LastUpdate = new System.Windows.Forms.Label();
            this.Label_Size = new System.Windows.Forms.Label();
            this.Label_Location = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loading = new GoHosts.ctl.LoadingCtl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(44, 157);
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
            this.Label_LastUpdate.Location = new System.Drawing.Point(96, 7);
            this.Label_LastUpdate.Name = "Label_LastUpdate";
            this.Label_LastUpdate.Size = new System.Drawing.Size(100, 16);
            this.Label_LastUpdate.TabIndex = 2;
            this.Label_LastUpdate.Text = "Lable_LastUpdate";
            // 
            // Label_Size
            // 
            this.Label_Size.AutoSize = true;
            this.Label_Size.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Size.Location = new System.Drawing.Point(96, 22);
            this.Label_Size.Name = "Label_Size";
            this.Label_Size.Size = new System.Drawing.Size(61, 16);
            this.Label_Size.TabIndex = 2;
            this.Label_Size.Text = "Label_Size";
            // 
            // Label_Location
            // 
            this.Label_Location.AutoSize = true;
            this.Label_Location.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Location.Location = new System.Drawing.Point(96, 39);
            this.Label_Location.Name = "Label_Location";
            this.Label_Location.Size = new System.Drawing.Size(80, 13);
            this.Label_Location.TabIndex = 3;
            this.Label_Location.Text = "Label_Location";
            this.Label_Location.Click += new System.EventHandler(this.Label_Location_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "上次更新时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hosts文件大小：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "hosts文件位置：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loading);
            this.panel1.Controls.Add(this.update);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Label_LastUpdate);
            this.panel1.Controls.Add(this.Label_Size);
            this.panel1.Controls.Add(this.Label_Location);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = this.Size;
            this.panel1.TabIndex = 5;
            // 
            // loading
            // 
            this.loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.loading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loading.Location = new System.Drawing.Point(0, 0);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(449, 300);
            this.loading.TabIndex = 5;
            this.loading.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 300);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "GoHosts";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label Label_LastUpdate;
        private System.Windows.Forms.Label Label_Size;
        private System.Windows.Forms.Label Label_Location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private ctl.LoadingCtl loading;
    }
}

