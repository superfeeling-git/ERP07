using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ERP.Common
{
    public static class StringHelper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt(this string password)
        {
            MD5 mD5 = MD5.Create();

            byte[] data = mD5.ComputeHash(Encoding.UTF8.GetBytes(password));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


        /// <summary>
        /// 生成编号
        /// </summary>
        /// <param name="Prefix">前缀</param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static string GeneratorCode(this string Prefix, string Code)
        {
            char FirstLetter = Code[0];

            if (char.IsLetter(FirstLetter))
            {
                string DistStr = Code.TrimStart(FirstLetter);

                //字母增位
                if ((Convert.ToInt32(DistStr) + 1).ToString().Length > DistStr.Length)
                {
                    return $"{Prefix}{(char)((int)FirstLetter + 1)}{"1".PadLeft(DistStr.Length, '0')}";
                }
                else
                {
                    int Add = Convert.ToInt32(DistStr) + 1;

                    //补位
                    DistStr = Add.ToString().PadLeft(DistStr.Length, '0');

                    return $"{Prefix}{FirstLetter}{DistStr}";
                }
            }
            else
            {
                int Add = Convert.ToInt32(Code) + 1;

                //补位
                Code = Add.ToString().PadLeft(Code.Length, '0');

                return $"{Prefix}{Code}";
            }
        }
    }
}
