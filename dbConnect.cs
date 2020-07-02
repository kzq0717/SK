using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SK
{
    public partial class dbConnect : UserControl
    {

        private string publicKey =@"<RSAKeyValue><Modulus>wOH5WW+6DeraSJJbBkf0sS2fdHA6tDDlqkJrlh94v4lrr4DKBfLaGKI5/DQDiU08GVpX0xcmAgdxtS4stO8/fwTWQsffUlV2PWC5EZDQizn128+oYnX2ozCYq7QMmPlMNEdXb8/UzfneWlWQr9c2oDZ4YLn5NLA5/XXr5EyYSeU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        public dbConnect()
        {
            InitializeComponent();
        }

        private void button_Gen_Click(object sender, EventArgs e)
        {
            try
            {
                string _strConnect = this.cbox_connect.Text.Trim();
                string _strIp = this.textBox_IP.Text.Trim();
                string _strUser = this.textBox_User.Text.Trim();
                string _strPwd = this.textBox_Pwd.Text.Trim();
                string _strDB = this.textBox_DB.Text.Trim();
                string _strCharSet = this.cbox_CharSet.Text.Trim();
                string _strPort = this.textBox_Port.Text.Trim();


                if (string.IsNullOrEmpty(_strConnect))
                {
                    MessageBox.Show("Conn cannot be empty. ", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrEmpty(_strIp))
                {
                    MessageBox.Show("IP cannot be empty.", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrEmpty(_strUser))
                {
                    MessageBox.Show("User cannot be empty.", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrEmpty(_strPwd))
                {
                    MessageBox.Show("Pwd cannot be empty.", "提示", MessageBoxButtons.OK);
                    return;
                }


                if (string.IsNullOrEmpty(_strPort))
                {
                    MessageBox.Show("Port cannot be empty.", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrEmpty(_strCharSet))
                {
                    MessageBox.Show("Code cannot be empty.", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrEmpty(_strDB))
                {
                    MessageBox.Show("DB cannot be empty.", "提示", MessageBoxButtons.OK);
                    return;
                }

                string str = "server=" + _strIp + ";user id=" + _strUser + ";password=" + _strPwd + ";database=" + _strDB + ";port=" + _strPort + ";Charset=" + _strCharSet + ";";

                string _encryptStr = SecurityHelper.RSAEncrypt(publicKey, str);
                this.rTextBox_connectString.Text = _encryptStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

    
        private void btn_view_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.rTextBox_connectString.Text.ToString()))
            {
                this.rTextBox_unConnectString.Text = SecurityHelper.RSADecrypt(SecurityHelper.privatekey, this.rTextBox_connectString.Text.ToString());

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

         //捕捉快捷键
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.V))
            {
                int _width = 360;
                int _height = 390;
                this.Size = new Size(_width, _height);
                this.btn_view.Visible = true;
                this.rTextBox_unConnectString.Visible = true;
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
