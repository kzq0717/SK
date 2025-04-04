﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SK {
    /// <summary>安全方式
    /// </summary>
    public class SecurityHelper {
        #region  变量
        /// <summary>私有密钥
        /// </summary>
        //public static string privatekey = @"<RSAKeyValue><Modulus>sb1zuR5gPeESE/0Cwikah1g5B6ooIfI99mHXQfSkljhWGZvuxGZPX8/lMOo/TKfyvcrR5SsXg7uZA9fQY5+oVBRrUU+mMvTpowcHC3sHYkA4HsNlYmFEm/qoWyIebDpdQYRhpIj3EaV4ZiOAZNZc1NoCIMXJMN8WL2QRwPpSlsE=</Modulus><Exponent>AQAB</Exponent><P>7txPLX7MRJgxS0j+T2GN0uFwwsEE4SjHOXR052bWgm0dDOCnHnTP7Apu8Ln6tcY/1pUnKO3r/Z7OH38Kd3GPrQ==</P><Q>vn5nc3kqChWNHMNVQloyhDCYIptX7FGu33AAap2JW3rDa0Rz8Beaq+DNlB4BlQHmHiiubi147OdBaIXMTb915Q==</Q><DP>GUAQ3q5YyaeNDnhY6etWIsTSNsRQz7yP0vMMqKmmY4NFXucgw4d1s24m7Cu85RpgBT8fNKRyHg17nLjBUn8ewQ==</DP><DQ>PJbd9reKLIzwRj7G5oTj3nHKYe+BBrRwZ7crGr4iy0r/zyWFrs8DLjohiUQGAswI0nzkBj1GYiun/UPZWL1WFQ==</DQ><InverseQ>l5QRa00ciNAD/GZPZwSI3vdqP38SVLOLx6btUd4naDrCCEMOzVy+N+DqgHRAm3f/1pmFtYLb2TBlSjElxwAetg==</InverseQ><D>T7OwzPY+GgFvZd8y+XYNG1wIVtOKo45JEs7VBBJ8K5Cfq2QtMYzfUwuartCcCffV9h2Y+bbVGJFrEDoajFHv3OOyompqX2/7s41GyGmpLLWsCmpCiWm4YDxY6BjlVV2wlRAzpUJryPVes6cdxaOxzKuqcDxCWw8UAfVfJTcmEkE=</D></RSAKeyValue>";
        public static string privatekey = @"<RSAKeyValue><Modulus>wOH5WW+6DeraSJJbBkf0sS2fdHA6tDDlqkJrlh94v4lrr4DKBfLaGKI5/DQDiU08GVpX0xcmAgdxtS4stO8/fwTWQsffUlV2PWC5EZDQizn128+oYnX2ozCYq7QMmPlMNEdXb8/UzfneWlWQr9c2oDZ4YLn5NLA5/XXr5EyYSeU=</Modulus><Exponent>AQAB</Exponent><P>6VLpPHwZDMdupSPuwLLT/kbHSULAGUUu/CkhXHPLwVEns22DnRD39hU/IJn4fvllEzt8xb42gXE7u3DONRqkRw==</P><Q>06DjcDvaaS+kwMFqRQl4Q47227SnlKeHRnpWqHqdi+nxCYwB+IlE2E1edgX1pM+2uf9LFhSlteEhLlLAaJCScw==</Q><DP>kqluOHndGR5HG4Dxs6j0/pGo9REDRR8qwJBuCvoyqqqDpRKCt3kSFFoYmzqNa+sCMMuky3ucMVNm85Sd2d2MQw==</DP><DQ>XBXlAYA50I1Xrjw7JqExQIxj5EQeq3OeTE+Nh7Aa/7ejF5lhfikU2N4JnWeIdNehVhu9K3V+ib7Vdlexu440+w==</DQ><InverseQ>ATP4ly/A9AH9eZ08yXk4jz7cI43ebyHuLky8uShrTMwCAkfveZpJwgoE+FG0IyJwJjWwRJaO8DH0J+5cuwNFEQ==</InverseQ><D>rAQby35PsH/FYjlcAlMDz0t/zGkWgYKmH9ySdFTm6/KTXfZ+tSVrCdML4XdFvBpsQbQHZRNc6yxWZR2j80z3EzSbq3b1+q9ZikfOr+MhEDNa+Po0UcM6ztk893XydtN+glA5B14cw0DDXoXu0uDBB/iPXZipG/ffope8lQWnGpU=</D></RSAKeyValue>";


        #endregion
        private static readonly byte[] IvBytes = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF };

        #region 通用加密算法
        /// <summary>哈希加密算法
        /// </summary>
        /// <param name="hashAlgorithm">所有加密哈希算法实现均必须从中派生基类</param>
        /// <param name="input">待加密的字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        private static string HashEncrypt(HashAlgorithm hashAlgorithm, string input, Encoding encoding) {
            var data = hashAlgorithm.ComputeHash(encoding.GetBytes(input));

            return BitConverter.ToString(data).Replace("-", "");
        }


        /// <summary>验证哈希值
        /// </summary>
        /// <param name="hashAlgorithm"> 所有加密哈希算法实现均必须从中派生的基类 </param>
        /// <param name="unhashedText"> 未加密的字符串 </param>
        /// <param name="hashedText"> 经过加密的哈希值 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        private static bool VerifyHashValue(HashAlgorithm hashAlgorithm, string unhashedText, string hashedText,
            Encoding encoding) {
            return string.Equals(HashEncrypt(hashAlgorithm, unhashedText, encoding), hashedText,
                StringComparison.OrdinalIgnoreCase);
        }

        #endregion

        #region 哈希加密算法

        #region MD5 算法

        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="input"> 待加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string MD5Encrypt(string input, Encoding encoding) {
            return HashEncrypt(MD5.Create(), input, encoding);
        }

        /// <summary>
        /// 验证 MD5 值
        /// </summary>
        /// <param name="input"> 未加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static bool VerifyMD5Value(string input, Encoding encoding) {
            return VerifyHashValue(MD5.Create(), input, MD5Encrypt(input, encoding), encoding);
        }

        #endregion MD5 算法

        #region SHA1 算法

        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string SHA1Encrypt(string input, Encoding encoding) {
            return HashEncrypt(SHA1.Create(), input, encoding);
        }

        /// <summary>
        /// 验证 SHA1 值
        /// </summary>
        /// <param name="input"> 未加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static bool VerifySHA1Value(string input, Encoding encoding) {
            return VerifyHashValue(SHA1.Create(), input, SHA1Encrypt(input, encoding), encoding);
        }

        #endregion SHA1 算法

        #region SHA256 算法

        /// <summary>
        /// SHA256 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string SHA256Encrypt(string input, Encoding encoding) {
            return HashEncrypt(SHA256.Create(), input, encoding);
        }

        /// <summary>
        /// 验证 SHA256 值
        /// </summary>
        /// <param name="input"> 未加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static bool VerifySHA256Value(string input, Encoding encoding) {
            return VerifyHashValue(SHA256.Create(), input, SHA256Encrypt(input, encoding), encoding);
        }

        #endregion SHA256 算法

        #region SHA384 算法

        /// <summary>
        /// SHA384 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string SHA384Encrypt(string input, Encoding encoding) {
            return HashEncrypt(SHA384.Create(), input, encoding);
        }

        /// <summary>
        /// 验证 SHA384 值
        /// </summary>
        /// <param name="input"> 未加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static bool VerifySHA384Value(string input, Encoding encoding) {
            return VerifyHashValue(SHA256.Create(), input, SHA384Encrypt(input, encoding), encoding);
        }

        #endregion SHA384 算法

        #region SHA512 算法

        /// <summary>
        /// SHA512 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string SHA512Encrypt(string input, Encoding encoding) {
            return HashEncrypt(SHA512.Create(), input, encoding);
        }

        /// <summary>
        /// 验证 SHA512 值
        /// </summary>
        /// <param name="input"> 未加密的字符串 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static bool VerifySHA512Value(string input, Encoding encoding) {
            return VerifyHashValue(SHA512.Create(), input, SHA512Encrypt(input, encoding), encoding);
        }

        #endregion SHA512 算法

        #region HMAC-MD5 加密

        /// <summary>
        /// HMAC-MD5 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="key"> 密钥 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string HMACSMD5Encrypt(string input, string key, Encoding encoding) {
            return HashEncrypt(new HMACMD5(encoding.GetBytes(key)), input, encoding);
        }

        #endregion HMAC-MD5 加密

        #region HMAC-SHA1 加密

        /// <summary>
        /// HMAC-SHA1 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="key"> 密钥 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string HMACSHA1Encrypt(string input, string key, Encoding encoding) {
            return HashEncrypt(new HMACSHA1(encoding.GetBytes(key)), input, encoding);
        }

        #endregion HMAC-SHA1 加密

        #region HMAC-SHA256 加密

        /// <summary>
        /// HMAC-SHA256 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="key"> 密钥 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string HMACSHA256Encrypt(string input, string key, Encoding encoding) {
            return HashEncrypt(new HMACSHA256(encoding.GetBytes(key)), input, encoding);
        }

        #endregion HMAC-SHA256 加密

        #region HMAC-SHA384 加密

        /// <summary>
        /// HMAC-SHA384 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="key"> 密钥 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string HMACSHA384Encrypt(string input, string key, Encoding encoding) {
            return HashEncrypt(new HMACSHA384(encoding.GetBytes(key)), input, encoding);
        }

        #endregion HMAC-SHA384 加密

        #region HMAC-SHA512 加密

        /// <summary>
        /// HMAC-SHA512 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="key"> 密钥 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string HMACSHA512Encrypt(string input, string key, Encoding encoding) {
            return HashEncrypt(new HMACSHA512(encoding.GetBytes(key)), input, encoding);
        }

        #endregion HMAC-SHA512 加密

        #endregion 哈希加密算法

        #region 对称加密算法

        #region Des 加解密

        /// <summary>DES 加密
        /// </summary>
        /// <param name="input"> 待加密的字符串 </param>
        /// <param name="key"> 密钥（8位） </param>
        /// <returns></returns>
        public static string DESEncrypt(string input, string key) {
            try {
                var keyBytes = Encoding.UTF8.GetBytes(key);
                //var ivBytes = Encoding.UTF8.GetBytes(iv);

                var des = DES.Create();
                des.Mode = CipherMode.ECB; //兼容其他语言的 Des 加密算法
                des.Padding = PaddingMode.Zeros; //自动补 0

                using (var ms = new MemoryStream()) {
                    var data = Encoding.UTF8.GetBytes(input);

                    using (var cs = new CryptoStream(ms, des.CreateEncryptor(keyBytes, IvBytes), CryptoStreamMode.Write)
                        ) {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            } catch {
                return input;
            }
        }

        /// <summary>DES 解密
        /// </summary>
        /// <param name="input"> 待解密的字符串 </param>
        /// <param name="key"> 密钥（8位） </param>
        /// <returns></returns>
        public static string DESDecrypt(string input, string key) {
            try {
                var keyBytes = Encoding.UTF8.GetBytes(key);
                //var ivBytes = Encoding.UTF8.GetBytes(iv);

                var des = DES.Create();
                des.Mode = CipherMode.ECB; //兼容其他语言的Des加密算法
                des.Padding = PaddingMode.Zeros; //自动补0

                using (var ms = new MemoryStream()) {
                    var data = Convert.FromBase64String(input);
                    using (var cs = new CryptoStream(ms, des.CreateDecryptor(keyBytes, IvBytes), CryptoStreamMode.Write)) {
                        cs.Write(data, 0, data.Length);

                        cs.FlushFinalBlock();
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            } catch {
                return input;
            }
        }

        #endregion Des 加解密

        #endregion 对称加密算法

        #region 非对称加密算法

        /// <summary> 生成 RSA 公钥和私钥
        /// </summary>
        /// <param name="publicKey"> 公钥 </param>
        /// <param name="privateKey"> 私钥 </param>
        public static void GenerateRSAKeys(out string publicKey, out string privateKey) {
            using (var rsa = new RSACryptoServiceProvider()) {
                publicKey = rsa.ToXmlString(false);
                privateKey = rsa.ToXmlString(true);
            }
        }

        /// <summary>
        /// RSA 加密
        /// </summary>
        /// <param name="publickey"> 公钥 </param>
        /// <param name="content"> 待加密的内容 </param>
        /// <returns> 经过加密的字符串 </returns>
        public static string RSAEncrypt(string publickey, string content) {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publickey);
            var cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// RSA 解密
        /// </summary>
        /// <param name="privatekey"> 私钥 </param>
        /// <param name="content"> 待解密的内容 </param>
        /// <returns> 解密后的字符串 </returns>
        public static string RSADecrypt(string privatekey, string content) {
            if (string.IsNullOrEmpty(content)) {
                return null;
            }
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privatekey);
            var cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

        #endregion 非对称加密算法

        #region  生成字符串类型的ID（16位）
        /// <summary>
        /// 生成字符串类型的ID（16位）
        /// </summary>
        /// <returns></returns>
        public static string GenerateStringID() {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray()) {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        #endregion

        #region 生成10位数字序列
        /// <summary>
        /// 19位数字序列
        /// </summary>
        /// <returns></returns>
        public static long GenerateIntID() {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToUInt32(buffer, 0);
        }
        #endregion
    }
}
