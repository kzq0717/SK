using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SK
{
    public class FormHelper
    {

        #region 使窗体可以移动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        #endregion

        /// <summary>获取图像数据
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Image GetImage(byte[] b)
        {
            if (b != null)
            {
                MemoryStream memStream = new MemoryStream();
                memStream.Write(b, 0, b.Length);
                memStream.Position = 0;
                memStream.Seek(0, SeekOrigin.Begin);

                Image img;
                try
                {
                    img = Image.FromStream(memStream, true);
                    memStream.Close();
                }
                catch (Exception)
                {
                    img = null;
                }
                return img;
            }
            else
            {
                return null;
            }
        }


        /// <summary>图像旋转
        /// </summary>
        /// <param name="bitmap">待旋转图像</param>
        /// <param name="angle">旋转角度</param>
        /// <returns></returns>
        public static Bitmap ImageRotate(Bitmap bitmap, int angle)
        {
            try
            {
                if (bitmap != null)
                {
                    switch (angle)
                    {
                        case 0:
                            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                            return bitmap;
                        case 90:
                            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            return bitmap;
                        case 180:
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            return bitmap;
                        case 270:
                            bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            return bitmap;
                        default:
                            return bitmap;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

       
        /// <summary>获取或设置包含有关控件的数据的对象。
        /// </summary>
        /// <param name="cons"></param>
        public static void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        /// <summary>设置控件大小
        /// </summary>
        /// <param name="newx">变化后的宽</param>
        /// <param name="newy">变化后的高</param>
        /// <param name="cons">要改变的控件集合</param>
        public static void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }


        /// <summary>窗体类型为None时，拖动鼠标窗体可移动
        /// </summary>
        /// <param name="form">要移动的窗体</param>
        public static void MoveForm(Form form)
        {
            //拖动窗体
            form.Cursor = System.Windows.Forms.Cursors.Hand;//改变鼠标样式
            ReleaseCapture();
            SendMessage(form.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            form.Cursor = System.Windows.Forms.Cursors.Default;
        }


        /// <summary>一组CheckBox实现单选，加个GroupBox(或其它容器) 把几个CheckBox 放到容器中。CheckBox_CheckedChanged事件指定下面方法：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                foreach (CheckBox check in (sender as CheckBox).Parent.Controls)
                {
                    if (check != sender)
                    {
                        check.Checked = false;
                    }
                }
            }
        }

        /// <summary>将字符串转成list(字符串采用逗号或者空格分割)
        /// 例如："1,2,3,4,5,6 7"
        /// </summary>
        /// <param name="message">带转化的字符串信息</param>
        /// <returns></returns>
        public static List<string> ConvertToList(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }
            string[] strInfo = message.Split(new char[] { ',', '，', ' ' });
            strInfo = strInfo.Where(s => !string.IsNullOrEmpty(s)).ToArray();  //使用lambda 表达式筛选过滤掉数据中的空字符串
            return strInfo.ToList();
        }


        /// <summary>递归获取所有文件
        /// </summary>
        /// <param name="info">查找找的目录</param>
        public static void ListFiles(FileSystemInfo info)
        {

            if (!info.Exists) return;
            DirectoryInfo dir = info as DirectoryInfo;
            if (dir == null) return;//不是目录

            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = files[i] as FileInfo;
                if (fileInfo != null)
                {   //是文件
                    Console.WriteLine(fileInfo.FullName + "\t" + fileInfo.Length);
                }
                else
                {
                    ListFiles(files[i]);//对于子目录，进行递归调用
                }
            }
        }


        #region 重绘treeview失去焦点后所选节点还在
        /// <summary>
        ///重绘treeview失去焦点后所选节点还在 
        ///构造函数中添加一下内容：
        /// this.treeView_kinds.HideSelection = false;
        /// this.treeView_kinds.DrawMode = TreeViewDrawMode.OwnerDrawText;
        ///this.treeView_kinds.DrawNode += new DrawTreeNodeEventHandler(SK.FormHelper.treeView_DrawNode);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;//这里采用默认颜色，只需要在TreeView失去焦点时选中节点仍然突显
            return;

            // OR 自定义颜色
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null)
                    nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }

            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }

        }
        #endregion

    }


    /// <summary>
    ///  Scroll控件类
    /// </summary>
    public static class FormHelper_Scroll
    {
        /// <summary>判断datagridView中垂直滑块是否已经到底
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="eventHandler"></param>
        public static void RegistScrollToEndEvent(this DataGridView dataGridView, EventHandler eventHandler)
        {
            dataGridView.Scroll += new ScrollEventHandler((sender, e) =>
            {
                if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                {
                    if (e.NewValue + dataGridView.DisplayedRowCount(false) == dataGridView.Rows.Count)
                    {
                        if (eventHandler != null)
                        {
                            eventHandler(dataGridView, null);
                        }
                    }
                }
            });
        }
    }


    public static class Extension
    {
        /// <summary>判断数组或者列表是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> checkNull<T>(this IEnumerable<T> list)
        {
            return list == null ? new List<T>(0) : list;
        }
    }


    /// <summary>
    /// textbox帮助类
    /// </summary>
    public static class FormHelper_TextBox
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 为TextBox设置水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="watermark">水印文字</param>
        public static void SetWatermark(this TextBox textBox, string watermark)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermark);
        }
        /// <summary>
        /// 清除水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        public static void ClearWatermark(this TextBox textBox)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, string.Empty);
        }
    }


}
