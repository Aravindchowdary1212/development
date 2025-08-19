using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections;

namespace AccuConnect.Core
{
    public class DbHelper
    {
        #region Global Declaration
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _connectionString;
        private readonly string className = "DbHelper";
        #endregion

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> ExecuteStoredProcedure<T>(string spName, Dictionary<string, object> parameters)
        {
            _log.Info("Class :" + className + "ExecuteStoredProcedure - Begin");
            var result = new List<T>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var dynamicParams = new DynamicParameters();

                    foreach (var param in parameters)
                    {
                        dynamicParams.Add(param.Key, param.Value);
                    }

                    result = connection.Query<T>(
                       spName,
                       dynamicParams,
                       commandType: CommandType.StoredProcedure
                   ).ToList();
                }
            }
            catch (Exception ex)
            {
                _log.Error("Class :" + className + "ExecuteStoredProcedure - Exception ::: ", ex);
            }
            _log.Info("Class :" + className + "ExecuteStoredProcedure - End");
            return result;
        }

        public T? ExecuteStoredProcedureForSingleObject<T>(string spName, Dictionary<string, object> parameters)
        {
            _log.Info("Class :" + className + "ExecuteStoredProcedure - Begin");
            T result = default; // no need to use `new T()`
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var dynamicParams = new DynamicParameters();

                    foreach (var param in parameters)
                    {
                        dynamicParams.Add(param.Key, param.Value);
                    }

                    result = connection.Query<T>(
                       spName,
                       dynamicParams,
                       commandType: CommandType.StoredProcedure
                   ).FirstOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                _log.Error("Class :" + className + "ExecuteStoredProcedure - Exception ::: ", ex);
            }
            _log.Info("Class :" + className + "ExecuteStoredProcedure - End");
            return result;
        }

        public object ExecuteScalarStoredProcedure(string spName, Dictionary<string, object> parameters)
        {
            _log.Info("Class :" + className + " ExecuteScalarStoredProcedure - Begin");
            object result = null;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var dynamicParams = new DynamicParameters();

                    foreach (var param in parameters)
                    {
                        dynamicParams.Add(param.Key, param.Value);
                    }

                    result = connection.ExecuteScalar(
                        spName,
                        dynamicParams,
                        commandType: CommandType.StoredProcedure
                    )!;
                }
            }
            catch (Exception ex)
            {
                _log.Error("Class :" + className + " ExecuteScalarStoredProcedure - Exception ::: ", ex);
            }

            _log.Info("Class :" + className + " ExecuteScalarStoredProcedure - End");
            return result;
        }

        public int ExecuteNonQuery(string spName, Dictionary<string, object> parameters)
        {
            _log.Info("Class :" + className + " ExecuteNonQuery - Begin");
            int result = 0;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var dynamicParams = new DynamicParameters();
                    foreach (var param in parameters)
                    {
                        dynamicParams.Add(param.Key, param.Value);
                    }

                    result = connection.Execute(spName, dynamicParams, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Class :" + className + " ExecuteNonQuery - Exception ::: ", ex);
            }
            _log.Info("Class :" + className + " ExecuteNonQuery - End");
            return result;
        }

        public List<T> ExecuteStoredProcedureWithOutput<T>(string spName, Dictionary<string, object> parameters, out int totalCount)
        {
            _log.Info("Class :" + className + " ExecuteStoredProcedureWithOutput - Begin");
            var result = new List<T>();
            totalCount = 0;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var dynamicParams = new DynamicParameters();

                    foreach (var param in parameters)
                    {
                        dynamicParams.Add(param.Key, param.Value);
                    }

                    dynamicParams.Add("totalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    result = connection.Query<T>(
                        spName,
                        dynamicParams,
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    totalCount = dynamicParams.Get<int>("totalCount");
                }
            }
            catch (Exception ex)
            {
                _log.Error("Class :" + className + " ExecuteStoredProcedureWithOutput - Exception ::: ", ex);
            }
            _log.Info("Class :" + className + " ExecuteStoredProcedureWithOutput - End");
            return result;
        }

        public IEnumerable<T> ExecuteStoredProcedureStream<T>(string spName, Dictionary<string, object> parameters)
        {
            _log.Info("Class :" + className + " ExecuteStoredProcedureStream - Begin");
            var connection = new SqlConnection(_connectionString);
            try
            {
                var dynamicParams = new DynamicParameters();
                foreach (var param in parameters)
                    dynamicParams.Add(param.Key, param.Value);

                connection.Open();

                // Use buffered: false for streaming!
                foreach (var item in connection.Query<T>(
                    spName,
                    dynamicParams,
                    commandType: CommandType.StoredProcedure,
                    buffered: false))
                {
                    yield return item;
                }
            }
            finally
            {
                // Do not dispose connection here! Let the caller (controller) handle disposal after streaming is done
            }
        }

        public (List<T1> Result1, List<T2> Result2) ExecuteStoredProcedureMultiple<T1, T2>(string storedProcedure, IDictionary<string, object> parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var dynamicParams = new DynamicParameters();
                if (parameters != null)
                {
                    foreach (var kvp in parameters)
                        dynamicParams.Add(kvp.Key, kvp.Value);
                }

                using (var multi = conn.QueryMultiple(storedProcedure, dynamicParams, commandType: CommandType.StoredProcedure))
                {
                    var result1 = multi.Read<T1>().ToList();
                    var result2 = multi.Read<T2>().ToList();
                    return (result1, result2);
                }
            }
        }

        public (List<T1> Result1, List<T2> Result2, object Result3) ExecuteStoredProcedureDynamic<T1, T2, T3>(string storedProcedure, IDictionary<string, object> parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var dynamicParams = new DynamicParameters();

                if (parameters != null)
                {
                    foreach (var kvp in parameters)
                        dynamicParams.Add(kvp.Key, kvp.Value);
                }

                using (var multi = conn.QueryMultiple(storedProcedure, dynamicParams, commandType: CommandType.StoredProcedure))
                {
                    var result1 = multi.Read<T1>().ToList();
                    var result2 = multi.Read<T2>().ToList();

                    if (typeof(T3) == typeof(Dictionary<string, string>) || (typeof(T3) == typeof(Hashtable)))
                    {
                        var rawRows = multi.Read().ToList(); // Read raw objects
                        object resultDict = null!;

                        if (typeof(T3) == typeof(Dictionary<string, string>))
                            resultDict = new Dictionary<string, string>();

                        if (typeof(T3) == typeof(Hashtable))
                            resultDict = new Hashtable();


                        foreach (var row in rawRows)
                        {
                            var dictRow = (IDictionary<string, object>)row;
                            if (dictRow.Count == 2)
                            {
                                var enumerator = dictRow.GetEnumerator();
                                enumerator.MoveNext();
                                string key = enumerator.Current.Value?.ToString() ?? "";

                                enumerator.MoveNext();
                                string value = enumerator.Current.Value?.ToString() ?? "";

                                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                                {
                                    if (resultDict is Dictionary<string, string> dict && !dict.ContainsKey(key))
                                        dict[key] = value;

                                    else if (resultDict is Hashtable hash && !hash.ContainsKey(key))
                                        hash[key] = value;
                                }
                            }
                        }

                        return (result1, result2, resultDict); // Return as object
                    }
                    else
                    {
                        var result3 = multi.Read<T3>().ToList();
                        return (result1, result2, result3);
                    }
                }
            }
        }


    }
}
