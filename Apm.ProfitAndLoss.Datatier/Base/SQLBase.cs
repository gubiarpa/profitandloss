using Apm.ProfitAndLoss.Datatier.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Apm.ProfitAndLoss.Datatier.Base
{
    public abstract class SQLBase
    {
        protected string _connectionString { get; set; }

        public SQLBase(OriginType originType)
        {
            SetOrigin(originType);
        }

        private Dictionary<string, object> _inParameters = new Dictionary<string, object>();
        private Dictionary<string, object> _outParameters = new Dictionary<string, object>();
        private Dictionary<string, object> _outResultParameters = new Dictionary<string, object>();

        protected void SetOrigin(OriginType originType)
        {
            try
            {
                switch (originType)
                {
                    case OriginType.APM:
                        _connectionString = ConfigBase.GetValueInConnectionString("APM");
                        break;
                    case OriginType.APM_Tableau:
                        _connectionString = ConfigBase.GetValueInConnectionString("APM_Tableau");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddInParameter(string name, object value)
        {
            try
            {
                _inParameters.Add(name, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddOutParameter(string name, object value)
        {
            _outParameters.Add(name, value);
        }

        protected object GetOutParameter(string name)
        {
            return _outResultParameters[name];
        }

        protected DataTable ExecuteSPWithResults(string SPName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    cmd.CommandText = SPName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 0;

                    foreach (string key in _inParameters.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(key, _inParameters[key]) { Direction = ParameterDirection.Input });
                    }

                    foreach (string key in _outParameters.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(key, _outParameters[key]) { Direction = ParameterDirection.Output });
                    }

                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (string key in _outParameters.Keys)
                    {
                        _outResultParameters[key] = cmd.Parameters[key].Value;
                    }
                    _inParameters.Clear();
                    _outParameters.Clear();
                    return dt;
                }
                catch (Exception ex)
                {
                    _inParameters.Clear();
                    _outParameters.Clear();
                    throw ex;
                }
            }
        }

        protected void ExecuteSPWithoutResults(string SPName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this._connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SPName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 0;
                    foreach (string key in _inParameters.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(key, _inParameters[key]) { Direction = ParameterDirection.Input });
                    }
                    cmd.ExecuteNonQuery();
                    _inParameters.Clear();
                    _outParameters.Clear();
                }
            }
            catch (Exception ex)
            {
                _inParameters.Clear();
                _outParameters.Clear();
                throw ex;
            }
        }

        protected DataTable ExecuteQueryWithResults(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 0;
                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ExecuteQueryWithoutResults(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();                    
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
