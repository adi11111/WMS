using GwDealerPortal.DataAccess.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GwDealerPortal.Service.Common
{
    public static class Utilities
    {
        public static string GetHeader(this HttpRequestMessage request, string key)
        {
            IEnumerable<string> keys = null;
            if (!request.Headers.TryGetValues(key, out keys))
                return null;

            return keys.First();
        }
        

            public static string RemoveAllWhiteSpaces(this string str)
            {
                return Regex.Replace(str, @"\s+", "");
            }

            //public static T GetConfigByKey<T>(this string key)
            //{
            //    if (!string.IsNullOrEmpty(key.Trim()))
            //    {
            //        return (T)Convert.ChangeType(System.Configuration.ConfigurationManager.AppSettings[key], typeof(T));
            //    }
            //    return default(T);
            //}

            public static DataTable ToDataTable<T>(this List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name, type);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        public static string SerializeObject(object table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static JArray ToJson(this System.Data.DataTable source)
        {
            JArray result = new JArray();
            JObject row;
            foreach (System.Data.DataRow dr in source.Rows)
            {
                row = new JObject();
                foreach (System.Data.DataColumn col in source.Columns)
                {
                    if(!DBNull.Value.Equals(dr[col]))
                    row.Add(col.ColumnName.Trim(), JToken.FromObject(dr[col]));
                    else
                        row.Add(col.ColumnName.Trim(), null);
                }
                result.Add(row);
            }
            return result;
        }

        public static List<Filter> Filters { get; set; }
        public static List<EventAccess> EventAccess { get; set; }

        public static void SendEmail(string subject, string body, string senderEmail, string senderPassword, string recieverEmail, string fileName = "")
        {
            using (MailMessage mm = new MailMessage(senderEmail, recieverEmail))
            {
                mm.Subject = subject;
                mm.Body = body;
               
                mm.IsBodyHtml = true;
                if (fileName != "")
                {
                    mm.Attachments.Add(new Attachment(fileName));
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                credentials.UserName = senderEmail;
                credentials.Password = senderPassword;
                smtp.UseDefaultCredentials = true;

                smtp.Credentials = credentials;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }



        //public static Image LoadImage(string BitString)
        //{
        //    //data:image/gif;base64,
        //    //this image is a single pixel (black)
        //    byte[] bytes = Convert.FromBase64String(BitString);

        //    Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = Image.FromStream(ms);
        //    }
        //    Image newImage = new Bitmap(image);
        //    image.Dispose();
        //    return newImage;
        //}
        //public static List<DateTime> GetNumberOfWeekendDays(DateTime start, DateTime stop)
        //{
        //    List<DateTime> days = new List<DateTime>();
        //    while (start <= stop)
        //    {
        //        if (start.DayOfWeek == DayOfWeek.Friday || start.DayOfWeek == DayOfWeek.Saturday)
        //        {
        //            days.Add(start);
        //        }
        //        start = start.AddDays(1);
        //    }
        //    return days;
        //}

        //public static void SendEmail(string subject, string body, string senderEmail, string senderPassword, string recieverEmail, string fileName = "")
        //{
        //    using (MailMessage mm = new MailMessage(senderEmail, recieverEmail))
        //    {
        //        mm.Subject = subject;
        //        mm.Body = body;
        //        mm.IsBodyHtml = true;
        //        if (fileName != "")
        //        {
        //            mm.Attachments.Add(new Attachment(fileName));
        //        }
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.EnableSsl = true;
        //        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
        //        credentials.UserName = senderEmail;
        //        credentials.Password = senderPassword;
        //        smtp.UseDefaultCredentials = true;

        //        smtp.Credentials = credentials;
        //        smtp.Port = 587;
        //        smtp.Send(mm);
        //    }
        //}



    }

    //public class CustomMultipartFileStreamProvider : MultipartMemoryStreamProvider
    //{
    //    public List<MyCustomData> CustomData { get; set; }

    //    public CustomMultipartFileStreamProvider()
    //    {
    //        CustomData = new List<MyCustomData>();
    //    }

    //    public override Task ExecutePostProcessingAsync()
    //    {
    //        foreach (var file in Contents)
    //        {
    //            var parameters = file.Headers.ContentDisposition.Parameters;
    //            var data = new MyCustomData
    //            {
    //                Foo = int.Parse(GetNameHeaderValue(parameters, "Foo")),
    //                Bar = GetNameHeaderValue(parameters, "Bar"),
    //            };

    //            CustomData.Add(data);
    //        }

    //        return base.ExecutePostProcessingAsync();
    //    }

    //    private static string GetNameHeaderValue(ICollection<NameValueHeaderValue> headerValues, string name)
    //    {
    //        var nameValueHeader = headerValues.FirstOrDefault(
    //            x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    //        return nameValueHeader != null ? nameValueHeader.Value : null;
    //    }
    //}
    //public class MyCustomData
    //{
    //    public int Foo { get; set; }
    //    public string Bar { get; set; }
    //}
}
