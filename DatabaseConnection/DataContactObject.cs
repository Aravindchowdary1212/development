using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Collections;
using System.Configuration;
using Npgsql;
using log4net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Employee.Core
{
    public static class DataContactObject
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static Hashtable hsQueryResource = null!;
        public static int intDatabaseTypeId = 0;
        private static string GetProcedureByResourceKey(string hsKeyName, ref QuerryType.QuerryTypes inputquerrytype)
        {
            string _ProcedureName = string.Empty;
            inputquerrytype = QuerryType.QuerryTypes.StoreProcedure;
            if (hsQueryResource != null && hsQueryResource.Count > 0)
            {
                string _hsKeyValue = string.Empty;
                _hsKeyValue = hsQueryResource[hsKeyName].ToString();
                if (!string.IsNullOrEmpty(_hsKeyValue))
                {
                    if (_hsKeyValue.Contains("Proc"))
                    {
                        inputquerrytype = QuerryType.QuerryTypes.StoreProcedure;
                    }
                    else if (_hsKeyValue.Contains("Tblfnc"))
                    {
                        inputquerrytype = QuerryType.QuerryTypes.TableFunction;
                    }
                    else if (_hsKeyValue.Contains("TblSclr"))
                    {
                        inputquerrytype = QuerryType.QuerryTypes.ScalarFunction;
                    }
                    else
                    {
                        inputquerrytype = QuerryType.QuerryTypes.Querry;
                    }
                    if (_hsKeyValue.Split("[").Length > 0)
                    {
                        _ProcedureName = _hsKeyValue.Split("[")[2].TrimEnd(']');
                    }
                }
            }
            return _ProcedureName;
        }
        public static DataSet FillDataset(ConnectDbContext acdbContext, string QueryKeyName, List<QuerryParamsDto> QuerryParams, string Querry = "")
        {
            _log.Info("FillDataset::" + "QueryKeyName::" + QueryKeyName + "::Begin");

            DataSet ds = new DataSet();
            string ConnectionString = String.Empty;
            string Procedure = String.Empty;
            QuerryType.QuerryTypes querryType = QuerryType.QuerryTypes.StoreProcedure;            
            if (!string.IsNullOrEmpty(QueryKeyName))
            {
                Procedure = GetProcedureByResourceKey(QueryKeyName, ref querryType);
            }
            else if (!string.IsNullOrEmpty(Querry))
            {
                querryType = QuerryType.QuerryTypes.Querry;
                Procedure = Querry;
            }
            else
            {
                _log.Info("FillDataset::" + "QueryKeyName::" + QueryKeyName + "::Query Not found");
                return ds;
            }

            if (intDatabaseTypeId == 0)
            {
                ds = SQLDataClass.FillDataset(acdbContext, querryType, Procedure, QuerryParams);

            }
            else if (intDatabaseTypeId == 1)
            {
                ds = PGSQLClass.FillDataset(acdbContext, querryType, Procedure, QuerryParams);
            }
            _log.Info("FillDataset::" + "QueryKeyName::" + QueryKeyName + "::End");
            return ds;

        }
        public static int ExecuteNonQuerry(ConnectDbContext acdbContext, string QueryKeyName, List<QuerryParamsDto> QuerryParams, string Querry = "")
        {
            _log.Info("ExecuteNonQuerry::" + "QuerryKyeName::" + QueryKeyName + "::Begin");
            int i = 0;
            string ConnectionString = String.Empty;
            string Procedure = String.Empty;
            QuerryType.QuerryTypes querryType = QuerryType.QuerryTypes.StoreProcedure;
            //ConnectionString = GetConstring();
            if (!string.IsNullOrEmpty(QueryKeyName))
            {
                Procedure = GetProcedureByResourceKey(QueryKeyName, ref querryType);
            }
            else if (!string.IsNullOrEmpty(Querry))
            {
                querryType = QuerryType.QuerryTypes.Querry;
                Procedure = Querry;
            }
            else
            {
                _log.Info("ExecuteNonQuerry::" + "QueryKeyName::" + QueryKeyName + "::Query Not found");
                return i;
            }
            if (intDatabaseTypeId == 0)
            {
                i = SQLDataClass.ExecuteNonQuerry(acdbContext, querryType, Procedure, QuerryParams);

            }
            else if (intDatabaseTypeId == 1)
            {
                i = PGSQLClass.ExecuteNonQuerry(acdbContext, querryType, Procedure, QuerryParams);
            }
            _log.Info("ExecuteNonQuerry::" + "QueryKyeName::" + QueryKeyName + "::End");
            return i;
        }
        public static object ExecuteScalar(ConnectDbContext acdbContext, string QueryKeyName, List<QuerryParamsDto> QuerryParams, string Querry = "")
        {
            _log.Info("ExecuteScalar::" + "QueryKeyName::" + QueryKeyName + "::Begin");
            object obj = null;
            string ConnectionString = String.Empty;
            string Procedure = String.Empty;
            QuerryType.QuerryTypes querryType = QuerryType.QuerryTypes.StoreProcedure;
            //ConnectionString = GetConstring();
            if (!string.IsNullOrEmpty(QueryKeyName))
            {
                Procedure = GetProcedureByResourceKey(QueryKeyName, ref querryType);
            }
            else if (!string.IsNullOrEmpty(Querry))
            {
                querryType = QuerryType.QuerryTypes.Querry;
                Procedure = Querry;
            }
            else
            {
                _log.Info("ExecuteScalar::" + "QueryKeyName::" + QueryKeyName + "::Query Not found");
                return obj;
            }

            if (intDatabaseTypeId == 0)
            {
                obj = SQLDataClass.ExecuteScalar(acdbContext, querryType, Procedure, QuerryParams);

            }
            else if (intDatabaseTypeId == 1)
            {
                obj = PGSQLClass.ExecuteScalar(acdbContext, querryType, Procedure, QuerryParams);
            }
            _log.Info("ExecuteScalar::" + "QueryKeyName::" + QueryKeyName + "::End");
            return obj;
        }
        public static IDataReader ExecuteReader(ConnectDbContext acdbContext, string QueryKeyName, List<QuerryParamsDto> QuerryParams, string Querry = "")
        {
            _log.Info("ExecuteReader::" + "QueryKeyName::" + QueryKeyName + "::Begin");
            IDataReader obj = null;
            string ConnectionString = String.Empty;
            string Procedure = String.Empty;
            QuerryType.QuerryTypes querryType = QuerryType.QuerryTypes.StoreProcedure;
            //ConnectionString = GetConstring();
            if (!string.IsNullOrEmpty(QueryKeyName))
            {
                Procedure = GetProcedureByResourceKey(QueryKeyName, ref querryType);
            }
            else if (!string.IsNullOrEmpty(Querry))
            {
                querryType = QuerryType.QuerryTypes.Querry;
                Procedure = Querry;
            }
            else
            {
                _log.Info("ExecuteReader::" + "QueryKeyName::" + QueryKeyName + "::Query Not found");
                return obj;
            }

            if (intDatabaseTypeId == 0)
            {
                obj = (IDataReader)SQLDataClass.ExecuteReader(acdbContext, querryType, Procedure, QuerryParams);

            }
            else if (intDatabaseTypeId == 1)
            {
                obj = (IDataReader)PGSQLClass.ExecuteReader(acdbContext, querryType, Procedure, QuerryParams);
            }
            _log.Info("ExecuteReader::" + "QueryKeyName::" + QueryKeyName + "::End");
            return obj;
        }
        public static void GetQuerryResource()
        {
            Hashtable _hsQueryResource = new Hashtable();
            string orgFilePath = string.Empty;
            string jsonString = string.Empty;
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json");
            jsonString = sr.ReadToEnd();
            Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
            var iDataBaseType = json["DataConnectionTypeId"].ToString();
            List<FieldInfo> fieldInfo = new List<FieldInfo>();

            if (iDataBaseType == "0")
            {
                intDatabaseTypeId = 0;               
                fieldInfo = typeof(SQLQueryConstants).GetFields().ToList();
            }
            else if (iDataBaseType == "1")
            {
                intDatabaseTypeId = 1;                
                fieldInfo = typeof(PGLGQueryConstants).GetFields().ToList();
            }
            if (fieldInfo != null && fieldInfo.Count > 0)
            {
                for (int i = 0; i < fieldInfo.Count; i++)
                {
                    _hsQueryResource.Add(fieldInfo[i].Name, fieldInfo[i].GetValue(fieldInfo[i].Name.ToString()).ToString());
                }
            }
            hsQueryResource = _hsQueryResource;
        }
    }
    public static class SQLDataClass
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string _ConnectionString = string.Empty;
        public static DataSet FillDataset(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("FillDataset::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;
            SqlConnection con;
            try
            {
                using (con = new SqlConnection(_ConnectionString))
                {
                    con.Open();
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Parameters.Clear();
                        if (QuerryParams != null && QuerryParams.Count > 0)
                        {
                            foreach (QuerryParamsDto param in QuerryParams)
                            {
                                cmd.Parameters.Add(new SqlParameter(param.Desc, param.Value));
                            }
                        }
                        if (types == QuerryType.QuerryTypes.StoreProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.TableFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * From dbo." + Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.ScalarFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select dbo." + Procedure;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = Procedure;
                        }
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("FillDataset::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("FillDataset::" + "Procedure::" + Procedure + "::End");
            return ds;
        }
        public static int ExecuteNonQuerry(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("ExecuteNonQuerry::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            int i = 0;
            SqlCommand cmd;
            SqlConnection con;
            try
            {
                using (con = new SqlConnection(_ConnectionString))
                {
                    con.Open();
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Parameters.Clear();
                        if (QuerryParams != null && QuerryParams.Count > 0)
                        {
                            foreach (QuerryParamsDto param in QuerryParams)
                            {
                                cmd.Parameters.Add(new SqlParameter(param.Desc, param.Value));
                            }
                        }
                        if (types == QuerryType.QuerryTypes.StoreProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.TableFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * from dbo." + Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.ScalarFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select dbo." + Procedure;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = Procedure;
                        }
                        i = cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("ExecuteNonQuerry::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("ExecuteNonQuerry::" + "Procedure::" + Procedure + "::End");
            return i;
        }
        public static object ExecuteScalar(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("ExecuteScalar::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            object obj = null;
            SqlCommand cmd;
            SqlConnection con;
            try
            {
                using (con = new SqlConnection(_ConnectionString))
                {
                    con.Open();
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Parameters.Clear();
                        if (QuerryParams != null && QuerryParams.Count > 0)
                        {
                            foreach (QuerryParamsDto param in QuerryParams)
                            {
                                cmd.Parameters.Add(new SqlParameter(param.Desc, param.Value));
                            }
                        }
                        if (types == QuerryType.QuerryTypes.StoreProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.TableFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * from dbo." + Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.ScalarFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select dbo." + Procedure;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = Procedure;
                        }
                        obj = cmd.ExecuteScalar();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("ExecuteScalar::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("ExecuteScalar::" + "Procedure::" + Procedure + "::End");
            return obj;
        }
        public static IDataReader ExecuteReader(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("ExecuteScalar::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            IDataReader dataReader = null!;
            SqlCommand cmd;
            SqlConnection con;

            try
            {
                con = new SqlConnection(_ConnectionString);
                con.Open();
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Parameters.Clear();
                        if (QuerryParams != null && QuerryParams.Count > 0)
                        {
                            foreach (QuerryParamsDto param in QuerryParams)
                            {
                                cmd.Parameters.Add(new SqlParameter(param.Desc, param.Value));
                            }
                        }
                        if (types == QuerryType.QuerryTypes.StoreProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.TableFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * from dbo." + Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.ScalarFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select dbo." + Procedure;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = Procedure;
                        }
                        dataReader = (IDataReader)cmd.ExecuteReader();
                    }
                
                //con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("ExecuteReader::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("ExecuteReader::" + "Procedure::" + Procedure + "::End");
            return dataReader;
        }
    }
    public static class PGSQLClass
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string _ConnectionString = string.Empty;
        public static DataSet FillDataset(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("FillDataset::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            NpgsqlCommand cmd;
            NpgsqlConnection con;
            string lstrParams = string.Empty;
            try
            {
                using (con = new NpgsqlConnection(_ConnectionString))
                {
                    using (cmd = new NpgsqlCommand())
                    {
                        cmd.Parameters.Clear();
                        lstrParams = "(";
                        if (QuerryParams != null && QuerryParams.Count > 0)
                        {
                            int i = 0;
                            foreach (QuerryParamsDto param in QuerryParams)
                            {
                                if (param.Desc.Contains('@'))
                                    param.Desc = param.Desc.Replace("@", "@p");
                                cmd.Parameters.AddWithValue(param.Desc, param.Value);
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(param.Desc))
                                    {
                                        lstrParams = lstrParams + param.Desc;
                                    }
                                }
                                if (i > 0)
                                {
                                    lstrParams = lstrParams + "," + param.Desc;
                                }
                                i = i + 1;
                            }

                        }
                        lstrParams = lstrParams + ")";
                        if (types == QuerryType.QuerryTypes.StoreProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = Procedure + lstrParams;
                        }
                        else if (types == QuerryType.QuerryTypes.TableFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * From " + Procedure + lstrParams;
                        }
                        else if (types == QuerryType.QuerryTypes.ScalarFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select " + Procedure + lstrParams;
                        }
                        else 
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = Procedure;
                        }
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("FillDataset::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("FillDataset::" + "Procedure::" + Procedure + "::End");
            return ds;
        }
        public static int ExecuteNonQuerry(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("ExecuteNonQuerry::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            int i = 0;
            NpgsqlCommand cmd;
            NpgsqlConnection con;
            string lstrParams = string.Empty;
            try
            {
                using (con = new NpgsqlConnection(_ConnectionString))
                {
                    using (cmd = new NpgsqlCommand())
                    {
                        cmd.Parameters.Clear();
                        lstrParams = "(";
                        if (QuerryParams != null && QuerryParams.Count > 0)
                        {
                            int j = 0;
                            foreach (QuerryParamsDto param in QuerryParams)
                            {
                                if (param.Desc.Contains('@'))
                                    param.Desc = param.Desc.Replace("@", "@p");
                                cmd.Parameters.AddWithValue(param.Desc, param.Value);
                                if (j == 0)
                                {
                                    if (!string.IsNullOrEmpty(param.Desc))
                                    {
                                        lstrParams = lstrParams + param.Desc;
                                    }
                                }
                                if (j > 0)
                                {
                                    lstrParams = lstrParams + "," + param.Desc;
                                }
                                j = j + 1;
                            }
                        }
                        lstrParams = lstrParams + ")";
                        if (types == QuerryType.QuerryTypes.StoreProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Call " + Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.TableFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * from " + Procedure + lstrParams;
                        }
                        else if (types == QuerryType.QuerryTypes.ScalarFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select from " + Procedure + lstrParams;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = Procedure;
                        }

                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.Connection = con;
                        i = cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("ExecuteNonQuerry::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("ExecuteNonQuerry::" + "Procedure::" + Procedure + "::End");
            return i;
        }
        public static object ExecuteScalar(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("ExecuteScalar::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            object obj = null;
            NpgsqlCommand cmd;
            NpgsqlConnection con;
            string lstrParams = string.Empty;
            try
            {
                using (con = new NpgsqlConnection(_ConnectionString))
                {
                    using (cmd = new NpgsqlCommand())
                    {
                        cmd.Parameters.Clear(); 
                        lstrParams = "(";
                        if (QuerryParams != null && QuerryParams.Count > 0)
                        {
                            int i = 0;
                            foreach (QuerryParamsDto param in QuerryParams)
                            {
                                if (param.Desc.Contains('@'))
                                    param.Desc = param.Desc.Replace("@", "@p");

                                cmd.Parameters.AddWithValue(param.Desc, param.Value);
                                if (i == 0)
                                {
                                    if (!string.IsNullOrEmpty(param.Desc))
                                    {
                                        lstrParams = lstrParams + param.Desc;
                                    }
                                }
                                if (i > 0)
                                {
                                    lstrParams = lstrParams + "," + param.Desc;
                                }
                                i = i + 1;
                            }
                        }
                        lstrParams = lstrParams + ")";
                        if (types == QuerryType.QuerryTypes.StoreProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Call " + Procedure;
                        }
                        else if (types == QuerryType.QuerryTypes.TableFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * from " + Procedure + lstrParams;
                        }
                        else if (types == QuerryType.QuerryTypes.ScalarFunction)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select from " + Procedure + lstrParams;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = Procedure;
                        }
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.Connection = con;
                        obj = cmd.ExecuteScalar();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("ExecuteScalar::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("ExecuteScalar::" + "Procedure::" + Procedure + "::End");
            return obj;
        }
        public static IDataReader ExecuteReader(ConnectDbContext acdbContext, QuerryType.QuerryTypes types, string Procedure, List<QuerryParamsDto> QuerryParams)
        {
            _log.Info("ExecuteScalar::" + "Procedure::" + Procedure + "::Begin");
            _ConnectionString = acdbContext.Database.GetConnectionString().ToString();
            IDataReader dataReader = null;
            NpgsqlCommand cmd;
            NpgsqlConnection con;
            string lstrParams = string.Empty;
            try
            {
                con = new NpgsqlConnection(_ConnectionString);
                using (cmd = new NpgsqlCommand())
                {
                    cmd.Parameters.Clear();
                    lstrParams = "(";
                    if (QuerryParams != null && QuerryParams.Count > 0)
                    {
                        
                        int i = 0;
                        foreach (QuerryParamsDto param in QuerryParams)
                        {
                            if (param.Desc.Contains('@'))
                                param.Desc = param.Desc.Replace("@", "@p");
                            cmd.Parameters.AddWithValue(param.Desc, param.Value);
                            if (i == 0)
                            {
                                if (!string.IsNullOrEmpty(param.Desc))
                                {
                                    lstrParams = lstrParams + param.Desc;
                                }
                            }
                            if (i > 0)
                            {
                                lstrParams = lstrParams + "," + param.Desc;
                            }
                            i = i + 1;
                        }
                    }
                    lstrParams = lstrParams + ")";
                    if (types == QuerryType.QuerryTypes.StoreProcedure)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Call " + Procedure;
                    }
                    else if (types == QuerryType.QuerryTypes.TableFunction)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from " + Procedure + lstrParams;
                    }
                    else if (types == QuerryType.QuerryTypes.ScalarFunction)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select from " + Procedure + lstrParams;
                    }
                    else
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = Procedure;
                    }
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.Connection = con;
                    dataReader = (IDataReader)cmd.ExecuteReader();
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                _log.Error("ExecuteScalar::" + "Procedure::" + Procedure + "::" + ex);
            }
            _log.Info("ExecuteScalar::" + "Procedure::" + Procedure + "::End");
            return dataReader;
        }
    }


    public static class QuerryType
    {
        public enum QuerryTypes
        {
            StoreProcedure = 0,
            TableFunction = 1,
            ScalarFunction = 2,
            Querry = 3

        }
    }
    public static class DBType
    {
        public enum DBTypes
        {
            MSSQL = 0,
            Postgresql = 1,
            MySql = 2 //Not implemented yet

        }
    }
    public class QuerryParamsDto
    {
        public string Desc { get; set; }
        public object Value { get; set; }
    }

}
