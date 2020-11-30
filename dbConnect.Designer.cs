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
            this.cbox_CharSet = new System.Windows.Forms.ComboBox();
            this.cbox_connect = new System.Windows.Forms.ComboBox();
            this.btn_view = new System.Windows.Forms.Button();
            this.rTextBox_unConnectString = new System.Windows.Forms.RichTextBox();
            this.rTextBox_connectString = new System.Windows.Forms.RichTextBox();
            this.textBox_DB = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.button_Gen = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox_CharSet
            // 
            this.cbox_CharSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_CharSet.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbox_CharSet.FormattingEnabled = true;
            this.cbox_CharSet.Items.AddRange(new object[] {
            "utf8",
            "latin1"});
            this.cbox_CharSet.Location = new System.Drawing.Point(324, 61);
            this.cbox_CharSet.Name = "cbox_CharSet";
            this.cbox_CharSet.Size = new System.Drawing.Size(170, 22);
            this.cbox_CharSet.TabIndex = 5;
            // 
            // cbox_connect
            // 
            this.cbox_connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_connect.FormattingEnabled = true;
            this.cbox_connect.ItemHeight = 12;
            this.cbox_connect.Items.AddRange(new object[] {
            "remote",
            "localhost"});
            this.cbox_connect.Location = new System.Drawing.Point(77, 3);
            this.cbox_connect.Name = "cbox_connect";
            this.cbox_connect.Size = new System.Drawing.Size(167, 20);
            this.cbox_connect.TabIndex = 0;
            // 
            // btn_view
            // 
            this.btn_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_view.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_view.Location = new System.Drawing.Point(345, 3);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(143, 31);
            this.btn_view.TabIndex = 2;
            this.btn_view.Text = "View";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Visible = false;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // rTextBox_unConnectString
            // 
            this.rTextBox_unConnectString.BackColor = System.Drawing.Color.White;
            this.rTextBox_unConnectString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.rTextBox_unConnectString, 4);
            this.rTextBox_unConnectString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTextBox_unConnectString.Font = new System.Drawing.Font("楷体", 10.5F);
            this.rTextBox_unConnectString.Location = new System.Drawing.Point(3, 227);
            this.rTextBox_unConnectString.Name = "rTextBox_unConnectString";
            this.rTextBox_unConnectString.Size = new System.Drawing.Size(491, 63);
            this.rTextBox_unConnectString.TabIndex = 8;
            this.rTextBox_unConnectString.Text = "";
            this.rTextBox_unConnectString.Visible = false;
            // 
            // rTextBox_connectString
            // 
            this.rTextBox_connectString.BackColor = System.Drawing.Color.White;
            this.rTextBox_connectString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.rTextBox_connectString, 4);
            this.rTextBox_connectString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTextBox_connectString.Font = new System.Drawing.Font("楷体", 10.5F);
            this.rTextBox_connectString.Location = new System.Drawing.Point(3, 162);
            this.rTextBox_connectString.Name = "rTextBox_connectString";
            this.rTextBox_connectString.Size = new System.Drawing.Size(491, 59);
            this.rTextBox_connectString.TabIndex = 7;
            this.rTextBox_connectString.Text = "";
            // 
            // textBox_DB
            // 
            this.textBox_DB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DB.Font = new System.Drawing.Font("楷体", 10.5F);
            this.textBox_DB.Location = new System.Drawing.Point(77, 90);
            this.textBox_DB.Name = "textBox_DB";
            this.textBox_DB.Size = new System.Drawing.Size(167, 23);
            this.textBox_DB.TabIndex = 6;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Port.Font = new System.Drawing.Font("楷体", 10.5F);
            this.textBox_Port.Location = new System.Drawing.Point(77, 61);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(167, 23);
            this.textBox_Port.TabIndex = 4;
            this.textBox_Port.Text = "3306";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Pwd.Font = new System.Drawing.Font("楷体", 10.5F);
            this.textBox_Pwd.Location = new System.Drawing.Point(324, 32);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.PasswordChar = '*';
            this.textBox_Pwd.Size = new System.Drawing.Size(170, 23);
            this.textBox_Pwd.TabIndex = 3;
            // 
            // textBox_User
            // 
            this.textBox_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_User.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_User.Location = new System.Drawing.Point(77, 32);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(167, 23);
            this.textBox_User.TabIndex = 2;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_IP.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_IP.Location = new System.Drawing.Point(324, 3);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(170, 23);
            this.textBox_IP.TabIndex = 1;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Cancel.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(174, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(165, 31);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // button_Gen
            // 
            this.button_Gen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Gen.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Gen.Location = new System.Drawing.Point(3, 3);
            this.button_Gen.Name = "button_Gen";
            this.button_Gen.Size = new System.Drawing.Size(165, 31);
            this.button_Gen.TabIndex = 0;
            this.button_Gen.Text = "Generate";
            this.button_Gen.UseVisualStyleBackColor = true;
            this.button_Gen.Click += new System.EventHandler(this.button_Gen_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rTextBox_connectString, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbox_CharSet, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbox_connect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_DB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Port, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Pwd, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_IP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_User, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.rTextBox_unConnectString, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 293);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 29);
            this.label8.TabIndex = 17;
            this.label8.Text = "Conn:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(250, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 29);
            this.label9.TabIndex = 18;
            this.label9.Text = "IP:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(3, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 29);
            this.label10.TabIndex = 19;
            this.label10.Text = "User：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(250, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 29);
            this.label11.TabIndex = 20;
            this.label11.Text = "Pwd:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(3, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 29);
            this.label12.TabIndex = 21;
            this.label12.Text = "Port：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(250, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 29);
            this.label13.TabIndex = 22;
            this.label13.Text = "Code:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(3, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 29);
            this.label14.TabIndex = 23;
            this.label14.Text = "DB：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.button_Gen, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Cancel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_view, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 119);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(491, 37);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // dbConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "dbConnect";
            this.Size = new System.Drawing.Size(497, 293);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbox_CharSet;
        private System.Windows.Forms.ComboBox cbox_connect;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.RichTextBox rTextBox_unConnectString;
        private System.Windows.Forms.RichTextBox rTextBox_connectString;
        private System.Windows.Forms.TextBox textBox_DB;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button button_Gen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
