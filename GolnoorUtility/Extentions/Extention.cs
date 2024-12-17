using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.IO;
using GolnoorUtility.Consts;

namespace GolnoorUtility.Extentions
{
    public static class Extention
    {
        public static string GetSha256Hash(this string text)
        {
            using (var hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                var byteValue = Encoding.UTF8.GetBytes(text);
                var byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
        }
        public static string FixString(this string str)
        {
            return str.Trim().ToLower();
        }

        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        public static string EncodePasswordMd5(this string pass) //Encrypt using MD5   
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string   
            return BitConverter.ToString(encodedBytes);
        }
        public static string ToPersianDate(this DateTime dateTime, char seprator = '/', bool isReverce = false)
        {
            PersianCalendar pc = new PersianCalendar();
            if (isReverce)
            {
                return $"{pc.GetDayOfMonth(dateTime).ToString("00")}{seprator}{pc.GetMonth(dateTime).ToString("00")}{seprator}{pc.GetYear(dateTime)}";
            }
            else
            {
                return $"{pc.GetYear(dateTime)}{seprator}{pc.GetMonth(dateTime).ToString("00")}{seprator}{pc.GetDayOfMonth(dateTime).ToString("00")}";
            }

        }
        public static string ToPersianDateTime(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();

            return $"{pc.GetYear(dateTime)}-{pc.GetMonth(dateTime).ToString("00")}-{pc.GetDayOfMonth(dateTime).ToString("00")} {pc.GetHour(dateTime).ToString("00")}:{pc.GetMinute(dateTime).ToString("00")}:{pc.GetSecond(dateTime).ToString("00")}";

        }
        public static DateTime ToMiladiDateTime(this string PersianDateTime)
        {

            PersianCalendar pc = new PersianCalendar();
            var SplitDateAndTime = PersianDateTime.Trim().Split(' ');

            var PersainDateSplits = SplitDateAndTime[0].Split('-');
            PersainDateSplits = PersainDateSplits.Length < 3 ? SplitDateAndTime[0].Split('/') : PersainDateSplits;
            var Persianyear = int.Parse(PersainDateSplits[0]);
            var PersianMonth = int.Parse(PersainDateSplits[1]);
            var PersianDay = int.Parse(PersainDateSplits[2]);

            var PersianHour = 0;
            var PersianMinute = 0;
            var PersianSecond = 0;
            if (SplitDateAndTime.Length > 1)
            {
                var PersainTimeSplits = SplitDateAndTime[1].Split(':');
                PersianHour = int.Parse(PersainTimeSplits[0]);
                PersianMinute = int.Parse(PersainTimeSplits[1]);
                PersianSecond = int.Parse(PersainTimeSplits[2]);
            }


            return pc.ToDateTime(Persianyear, PersianMonth, PersianDay, PersianHour, PersianMinute, PersianSecond, 0);


        }
        public static DateTime PersianToDateTime(this string date)
        {
            if (date.Length != 10)
            {
                throw new ArgumentException(nameof(date));
            }
            PersianCalendar persian = new PersianCalendar();
            int year = Convert.ToInt32(date.Substring(0, 4));
            var convertDate = persian.ToDateTime(year, Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(8, 2)), 0, 0, 0, 0); ;

            return convertDate;
        }
        public static string YeksanSazieYeVaKe(this string value)
        {
            return value == null ? null : $"%{(value).Replace("ي", "ی").Replace("ك", "ک")}%";
        }


        public static string EncryptString(string plainText, string key)
        {


            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string cipherText, string key)
        {

            try
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }
    }
}
