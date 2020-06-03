using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using ICSharpCode.SharpZipLib.GZip;
using System.Net;
using System.Text;

namespace SK
{
    /// <summary>
    /// 基于HttpClient封装的请求类
    /// </summary>
    public class HttpHelper
    {

        public static void FileUpload(string url, string filepath)
        {
            DateTime dateTime = DateTime.Now;
            //要上传的文件
            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            //根据url创建HttpWebRequest对象
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpWebRequest.Method = "POST";

            //对发送的数据不使用缓存
            httpWebRequest.AllowWriteStreamBuffering = false;

            //设置获得响应的超时时间（半个小时）
            httpWebRequest.Timeout = 300000;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.ProtocolVersion = HttpVersion.Version11;

            httpWebRequest.ContentType = "application/json";

            long filelength = fileStream.Length;
            httpWebRequest.SendChunked = true;

            //每次上传10k
            int bufferLength = 10 * 1024;
            byte[] buffer = new byte[bufferLength];

            //已上传的字节数
            long offset = 0;


            //开始上传时间
            DateTime startTime = DateTime.Now;
            int size = fileStream.Read(buffer, 0, bufferLength);
            Stream postStream = httpWebRequest.GetRequestStream();
            while (size > 0)
            {
                postStream.Write(buffer,0,size);
                offset += size;
                size = fileStream.Read(buffer, 0, bufferLength);
            }

            postStream.Flush();
            postStream.Close();


            //获取服务端的响应
            WebResponse webResponse = httpWebRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            DateTime endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - startTime;

            //读取服务器端返回信息
            String result = streamReader.ReadLine();
            Console.WriteLine("retcode=" + result + " 花费时间=" + timeSpan.TotalSeconds.ToString());

            stream.Close();
            streamReader.Close();
        }

        /// <summary>
        /// 使用POST方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="json">发送的参数字符串，只能用json</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> PostAsyncJson(string url, string json)
        {
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }


        /// <summary>
        /// 使用POST方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数字符串</param>
        /// <param name="header">自定义文件头</param>
        /// <param name="Gzip">是否进行GZip压缩</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> PostAsync(string url, string data, Dictionary<string, string> header = null, bool Gzip = false)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpContent content = new StringContent(data);
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = "";
            if (Gzip)
            {
                GZipInputStream inputStream = new GZipInputStream(await response.Content.ReadAsStreamAsync());
                responseBody = new StreamReader(inputStream).ReadToEnd();
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();

            }
            return responseBody;
        }

        /// <summary>
        /// 使用get方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> GetAsync(string url, Dictionary<string, string> header = null, bool Gzip = false)
        {

            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();//用来抛异常的
            string responseBody = "";
            if (Gzip)
            {
                GZipInputStream inputStream = new GZipInputStream(await response.Content.ReadAsStreamAsync());
                responseBody = new StreamReader(inputStream).ReadToEnd();
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();

            }
            return responseBody;
        }

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <typeparam name="T2">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="obj">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<T> PostObjectAsync<T, T2>(string url, T2 obj)
        {
            String json = JsonConvert.SerializeObject(obj);
            string responseBody = await PostAsyncJson(url, json); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }

        /// <summary>
        /// 使用Get返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <returns>返回请求的对象</returns>
        public static async Task<T> GetObjectAsync<T>(string url)
        {
            string responseBody = await GetAsync(url); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }


        private static readonly Encoding encoding = Encoding.UTF8;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="postUrl">This must be the url to which you want to post the form.</param>
        /// <param name="userAgent">This is up to your requirement; if needed, then pass the value as required.</param>
        /// <param name="postParameters">This is of type Dictionary. You can pass the parameter name and value as “key-value”</param>
        /// <param name="headerkey">This must be the name of the header that needs to be passed. In this example, I have used it as a string which can be used to pass a single header. If the header is not required, you can ignore this parameter.</param>
        /// <param name="headervalue">This must be the value of the header to be passed.</param>
        /// <returns></returns>
        public static HttpWebResponse MultipartFormPost(string postUrl, string userAgent, Dictionary<string, object> postParameters, string headerkey, string headervalue)
        {
            string formDataBoundary = string.Format("------{0:N}", Guid.NewGuid());
            string contentType = "Multipart/form-data;boundary=" + formDataBoundary;
            byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

            return PostForm(postUrl, userAgent, contentType, formData, headerkey, headervalue);
        }


        /// <summary>
        /// This is a private method and will be called within the public method, 
        /// MultipartFormPost. This method has two other parameters, contentType and formData. 
        /// We have added static content type while we got formData from GetMultipartFormData. 
        /// I have also created a class named FileParameter with some class members and constructor
        /// to use directly while passing a file as a parameter to my post method.
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="userAgent"></param>
        /// <param name="contentType"></param>
        /// <param name="formData"></param>
        /// <param name="headerkey"></param>
        /// <param name="headervalue"></param>
        /// <returns></returns>
        private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData, string headerkey, string headervalue)
        {
            HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
            if(request == null)
            {
                throw new NullReferenceException("request is not a http request");
            }


            //Set up the request properties
            request.Method = "POST";
            request.ContentType = contentType;
            request.UserAgent = userAgent;
            request.CookieContainer = new CookieContainer();
            request.ContentLength = formData.Length;


            // You could add authentication here as well if needed:  
            // request.PreAuthenticate = true;  
            // request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;  
            //Add header if needed 
            request.Headers.Add(headerkey, headervalue);

            //Send the form data to the request
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(formData, 0, formData.Length);
                requestStream.Close();
            }

            return request.GetResponse() as HttpWebResponse;
        }


        /// <summary>
        /// This method will give you form data in byte form to post.
        /// </summary>
        /// <param name="postParameters"></param>
        /// <param name="boundary"></param>
        /// <returns></returns>
        private static byte[] GetMultipartFormData(Dictionary<string,object>postParameters,string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;
            foreach (var param in postParameters)
            {
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"),0,encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                if(param.Value is FileParameter)  // to check if parameter if of file type   
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;
                    // Add just the first part of this param, since we will write the file data directly to the Stream  
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? param.Key,
                        fileToUpload.ContentType ?? "application/octet-stream");

                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                    // Write the file data directly to the Stream, rather than serializing it to a string.  
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                      boundary,
                      param.Key,
                      param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));

                }

            }

            // Add the end of the request.  Start with a newline  
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]  
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }

        /// <summary>
        /// 
        /// </summary>
        public class FileParameter
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public FileParameter(byte[] file) : this(file, null) { }
            public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }

    }
}
