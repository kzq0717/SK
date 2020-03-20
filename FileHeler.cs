using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK
{
    /// <summary>文件操作类
    /// </summary>
    class FileHeler
    {

        public static string getJavaScriptValue(string strName)
        {

            try
            {
                if (string.IsNullOrEmpty(strName)) {

                }

                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("获取JavaStript中变量的值失败。",ex);
            }

        }
    }
}
