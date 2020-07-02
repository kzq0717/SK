namespace SK
{
    partial class dbConnect
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbox_CharSet = new System.Windows.Forms.ComboBox();
            this.cbox_connect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_view = new System.Windows.Forms.Button();
            this.rTextBox_unConnectString = new System.Windows.Forms.RichTextBox();
            this.rTextBox_connectString = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_DB = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.button_Gen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cbox_CharSet);
            this.panel1.Controls.Add(this.cbox_connect);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_view);
            this.panel1.Controls.Add(this.rTextBox_unConnectString);
            this.panel1.Controls.Add(this.rTextBox_connectString);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_DB);
            this.panel1.Controls.Add(this.textBox_Port);
            this.panel1.Controls.Add(this.textBox_Pwd);
            this.panel1.Controls.Add(this.textBox_User);
            this.panel1.Controls.Add(this.textBox_IP);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.button_Gen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 285);
            this.panel1.TabIndex = 1;
            // 
            // cbox_CharSet
            // 
            this.cbox_CharSet.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbox_CharSet.FormattingEnabled = true;
            this.cbox_CharSet.Items.AddRange(new object[] {
            "utf8",
            "latin1"});
            this.cbox_CharSet.Location = new System.Drawing.Point(233, 90);
            this.cbox_CharSet.Name = "cbox_CharSet";
            this.cbox_CharSet.Size = new System.Drawing.Size(113, 22);
            this.cbox_CharSet.TabIndex = 18;
            // 
            // cbox_connect
            // 
            this.cbox_connect.FormattingEnabled = true;
            this.cbox_connect.Items.AddRange(new object[] {
            "remote",
            "localhost"});
            this.cbox_connect.Location = new System.Drawing.Point(65, 25);
            this.cbox_connect.Name = "cbox_connect";
            this.cbox_connect.Size = new System.Drawing.Size(113, 20);
            this.cbox_connect.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(13, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Conn:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_view
            // 
            this.btn_view.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_view.Location = new System.Drawing.Point(235, 157);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(73, 31);
            this.btn_view.TabIndex = 15;
            this.btn_view.Text = "View";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Visible = false;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // rTextBox_unConnectString
            // 
            this.rTextBox_unConnectString.BackColor = System.Drawing.Color.White;
            this.rTextBox_unConnectString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTextBox_unConnectString.Font = new System.Drawing.Font("楷体", 10.5F);
            this.rTextBox_unConnectString.Location = new System.Drawing.Point(12, 288);
            this.rTextBox_unConnectString.Name = "rTextBox_unConnectString";
            this.rTextBox_unConnectString.Size = new System.Drawing.Size(334, 82);
            this.rTextBox_unConnectString.TabIndex = 14;
            this.rTextBox_unConnectString.Text = "";
            this.rTextBox_unConnectString.Visible = false;
            // 
            // rTextBox_connectString
            // 
            this.rTextBox_connectString.BackColor = System.Drawing.Color.White;
            this.rTextBox_connectString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTextBox_connectString.Font = new System.Drawing.Font("楷体", 10.5F);
            this.rTextBox_connectString.Location = new System.Drawing.Point(12, 199);
            this.rTextBox_connectString.Name = "rTextBox_connectString";
            this.rTextBox_connectString.Size = new System.Drawing.Size(334, 75);
            this.rTextBox_connectString.TabIndex = 13;
            this.rTextBox_connectString.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(188, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Code:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_DB
            // 
            this.textBox_DB.Font = new System.Drawing.Font("楷体", 10.5F);
            this.textBox_DB.Location = new System.Drawing.Point(65, 120);
            this.textBox_DB.Name = "textBox_DB";
            this.textBox_DB.Size = new System.Drawing.Size(113, 23);
            this.textBox_DB.TabIndex = 5;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Font = new System.Drawing.Font("楷体", 10.5F);
            this.textBox_Port.Location = new System.Drawing.Point(65, 88);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(113, 23);
            this.textBox_Port.TabIndex = 3;
            this.textBox_Port.Text = "3306";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Font = new System.Drawing.Font("楷体", 10.5F);
            this.textBox_Pwd.Location = new System.Drawing.Point(233, 54);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.PasswordChar = '*';
            this.textBox_Pwd.Size = new System.Drawing.Size(113, 23);
            this.textBox_Pwd.TabIndex = 2;
            // 
            // textBox_User
            // 
            this.textBox_User.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_User.Location = new System.Drawing.Point(65, 54);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(113, 23);
            this.textBox_User.TabIndex = 1;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_IP.Location = new System.Drawing.Point(233, 22);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(113, 23);
            this.textBox_IP.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(147, 157);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 31);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // button_Gen
            // 
            this.button_Gen.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Gen.Location = new System.Drawing.Point(59, 157);
            this.button_Gen.Name = "button_Gen";
            this.button_Gen.Size = new System.Drawing.Size(73, 31);
            this.button_Gen.TabIndex = 6;
            this.button_Gen.Text = "Generate";
            this.button_Gen.UseVisualStyleBackColor = true;
            this.button_Gen.Click += new System.EventHandler(this.button_Gen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "DB：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(192, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pwd:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "User：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(192, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dbConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "dbConnect";
            this.Size = new System.Drawing.Size(360, 285);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbox_CharSet;
        private System.Windows.Forms.ComboBox cbox_connect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.RichTextBox rTextBox_unConnectString;
        private System.Windows.Forms.RichTextBox rTextBox_connectString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DB;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button button_Gen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
