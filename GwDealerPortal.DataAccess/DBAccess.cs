using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace GwDealerPortal.DataAccess
{
    public class DbAccess
    {
        private static IHostingEnvironment _env;
        public DbAccess(IHostingEnvironment env)
        {
            _env = env;
        }
        public static string DbWems = "PR_WEMS";
        public static string DBPortal = "PR_WEMSPORTAL";
        public static DataSet ExecuteSP(string dbName, string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection cn = GetConnection(dbName))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = storedProcName;
                        // assign parameters passed in to the command
                        foreach (var procParameter in procParameters)
                        {
                            cmd.Parameters.Add(procParameter.Value);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ds;
        }
        public static DataSet ExecuteQuery(string dbName, string query, Dictionary<string, SqlParameter> procParameters)
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection cn = GetConnection(dbName))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        // assign parameters passed in to the command
                        foreach (var procParameter in procParameters)
                        {
                            cmd.Parameters.Add(procParameter.Value);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ds;
        }
        public static int ExecuteQuery(string dbName, string query)
        {
            int _result = -1;
            try
            {

                using (SqlConnection cn = GetConnection(dbName))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        _result = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return _result;
        }
        public static int ExecuteCommand(string dbName, string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            int rc;
            using (SqlConnection cn = GetConnection(dbName))
            {
                // create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    // assign parameters passed in to the command
                    foreach (var procParameter in procParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }
                    rc = cmd.ExecuteNonQuery();
                }
            }
            return rc;
        }
        public static SqlConnection GetConnection(string dbName = "PR_WEMS")
        {
            string cnstr = "";
            if (Environment.UserDomainName.ToLower().Contains("adil") == false)
            {
              cnstr =  @"Data Source = GWSQLSERVER\GWSQLSERVER; Initial Catalog = " + dbName + "; Persist Security Info = True; User ID = sa; Password = gw5209; MultipleActiveResultSets = true";
            }
            else
            {
                cnstr = GetConfig("WMSDBConnection");
            }
            //if(Environment.UserDomainName.ToLower().Contains("adil"))
            //{
            //    cnstr = GetConfig("WMSDBConnection");
            //}
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }
        public static string  GetConfig(string key)
        {
            string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase) + @"\GwDealerPortal.DataAccess.dll.config";

            XDocument doc = XDocument.Load(path);
            var query = doc.Descendants("appsettings").Nodes().Cast<XElement>().Where(x => x.Attribute("key").Value.ToString() == key).FirstOrDefault();
            if (query != null)
            {
                return query.Attribute("value").Value.ToString();
            }
            return "";
        }
    }
}
