using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SK {
    public class JsonHelper {
        /// <summary>
        /// 读取Json数据
        /// </summary>
        /// <param name="jsonText"></param>
        public static void ReadJson(string jsonText) {
            try {
                JsonReader reader = new JsonTextReader(new StringReader(jsonText));
                while (reader.Read()) {
                    Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);
                }
            } catch (Exception ex) {
                Console.WriteLine($"读取Json数据异常：{ex.Message}_{ex.StackTrace}");
            }
        }


        /// <summary>
        /// 写JSON数据
        /// </summary>
        /// <returns></returns>
        public static string WriteJson() {
            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);

            writer.WriteStartObject();
            writer.WritePropertyName("input");
            writer.WriteValue("userName");
            writer.WritePropertyName("output");
            writer.WriteValue("admin");
            writer.WriteEndObject();
            writer.Flush();

            string jsonText = sw.GetStringBuilder().ToString();
            return jsonText;
        }


        /// <summary>
        /// 将Json字符换转为数组类型
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static string[] getJsonInfo(string jsonText) {
            try {
                JObject jo = JObject.Parse(jsonText);
                string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray();
                return values;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
