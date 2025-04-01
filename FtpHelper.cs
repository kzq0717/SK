using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;

namespace SK {
    public class FtpHelper {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private string privateKey = "<RSAKeyValue><Modulus>wOH5WW+6DeraSJJbBkf0sS2fdHA6tDDlqkJrlh94v4lrr4DKBfLaGKI5/DQDiU08GVpX0xcmAgdxtS4stO8/fwTWQsffUlV2PWC5EZDQizn128+oYnX2ozCYq7QMmPlMNEdXb8/UzfneWlWQr9c2oDZ4YLn5NLA5/XXr5EyYSeU=</Modulus><Exponent>AQAB</Exponent><P>6VLpPHwZDMdupSPuwLLT/kbHSULAGUUu/CkhXHPLwVEns22DnRD39hU/IJn4fvllEzt8xb42gXE7u3DONRqkRw==</P><Q>06DjcDvaaS+kwMFqRQl4Q47227SnlKeHRnpWqHqdi+nxCYwB+IlE2E1edgX1pM+2uf9LFhSlteEhLlLAaJCScw==</Q><DP>kqluOHndGR5HG4Dxs6j0/pGo9REDRR8qwJBuCvoyqqqDpRKCt3kSFFoYmzqNa+sCMMuky3ucMVNm85Sd2d2MQw==</DP><DQ>XBXlAYA50I1Xrjw7JqExQIxj5EQeq3OeTE+Nh7Aa/7ejF5lhfikU2N4JnWeIdNehVhu9K3V+ib7Vdlexu440+w==</DQ><InverseQ>ATP4ly/A9AH9eZ08yXk4jz7cI43ebyHuLky8uShrTMwCAkfveZpJwgoE+FG0IyJwJjWwRJaO8DH0J+5cuwNFEQ==</InverseQ><D>rAQby35PsH/FYjlcAlMDz0t/zGkWgYKmH9ySdFTm6/KTXfZ+tSVrCdML4XdFvBpsQbQHZRNc6yxWZR2j80z3EzSbq3b1+q9ZikfOr+MhEDNa+Po0UcM6ztk893XydtN+glA5B14cw0DDXoXu0uDBB/iPXZipG/ffope8lQWnGpU=</D></RSAKeyValue>";

        /// <summary>
        /// 缓冲区:4K
        /// </summary>
        private int bufferSize = 4096;

        /// <summary>构造函数
        /// </summary>
        /// <param name="hostIP">地址</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>、
        public FtpHelper(string hostIP, string userName, string password) {
            host = hostIP;
            user = userName;
            pass = password;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="url"></param>
        public FtpHelper(string url) {
            //string ip = "", userName = "", userPassword = "";
            string _key = SK.SecurityHelper.RSADecrypt(privateKey, url);
            string[] _connect = _key.Split(new char[] { '@', '=' });
            for (int i = 0; i < _connect.Length; i++) {
                if (_connect[i].Equals("IP")) {
                    host = "ftp://" + _connect[i + 1];
                }

                if (_connect[i].Equals("UserName")) {
                    user = _connect[i + 1];
                }

                if (_connect[i].Equals("Passwd")) {
                    pass = _connect[i + 1];
                }
            }

        }

        /// <summary>下载文件
        /// </summary>
        /// <param name="remoteFile">远程文件</param>
        /// <param name="localFile">本地文件</param>
        public void download(string remoteFile, string localFile) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                ftpStream = ftpResponse.GetResponseStream();
                /* Open a File Stream to Write the Downloaded File */
                FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                /* Download the File by Writing the Buffered Data Until the Transfer is Complete */

                try {
                    while (bytesRead > 0) {
                        localFileStream.Write(byteBuffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    }
                } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }




        private string _percenage;
        /// <summary>
        /// 上传百分比信
        /// </summary>
        public string Percenage {
            get { return _percenage; }
            set {
                //如果变量值改变则调用事件触发函数
                if (value != _percenage) {
                    WhenPercenageChange();
                }
                _percenage = value;
            }
        }

        //定义委托
        public delegate void PercenageChanged(object sender, EventArgs e);

        //与委托相关联的事件
        public event PercenageChanged OnPercenageChanged;

        //事件触发函数
        private void WhenPercenageChange() {
            if (OnPercenageChanged != null) {
                OnPercenageChanged(this, null);
            }
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="remoteFile">远程存储文件名(包含路径)</param>
        /// <param name="localFile">本地文件路径(包含路径)</param>
        /// <returns>成功：true</returns>
        public bool upload(string remoteFile, string localFile) {
            try {
                //OnPercenageChanged += new PercenageChanged();

                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create($"{host}/{remoteFile}");
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(localFile, FileMode.Open);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);

                //已上传的字节数
                long offset = 0;

                //开始上传时间
                DateTime startTime = DateTime.Now;
                //文件大小
                long fileLength = localFileStream.Length;

                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try {
                    while (bytesSent != 0) {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        //计算上传大小及速度
                        offset += bytesSent;
                        TimeSpan span = DateTime.Now - startTime;
                        double second = span.TotalSeconds;
                        string msg = "";
                        //if (second >0.0001)
                        //{
                        //    msg = (offset / 1024 / second).ToString("0.00") + "KB/M";
                        //}
                        //else
                        //{
                        //    msg = "正在连接中......";
                        //}
                        msg = (offset / 1048576.0).ToString("F2") + "/" + (fileLength / 1048576.0).ToString("F2") + "M";
                        Percenage = msg;
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    throw ex;
                }

                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;

                return true;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        /// <summary>Delete File
        /// </summary>
        /// <param name="deleteFile"></param>
        public void delete(string deleteFile) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{deleteFile}");
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /// <summary>Rename File
        /// </summary>
        /// <param name="currentFileNameAndPath"></param>
        /// <param name="newFileName"></param>
        public void rename(string currentFileNameAndPath, string newFileName) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentFileNameAndPath);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                /* Rename the File */
                ftpRequest.RenameTo = newFileName;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /// <summary>Create a New Directory on the FTP Server
        /// </summary>
        /// <param name="newDirectory"></param>
        public void createDirectory(string newDirectory) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /// <summary>Get the Date/Time a File was Created
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string getFileCreatedDateTime(string fileName) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { fileInfo = ftpReader.ReadToEnd(); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Created Date Time */
                return fileInfo;
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /// <summary>Get the Size of a File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string getFileSize(string fileName) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Size */
                return fileInfo;
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /// <summary>List Directory Contents File/Folder Name Only
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public string[] directoryListSimple(string directory) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] { "" };
        }

        /// <summary>List Directory Contents in Detail (Name, Size, Created, etc.)
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public string[] directoryListDetailed(string directory) {
            try {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] { "" };
        }

    }
}
