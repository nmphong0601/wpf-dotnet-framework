using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTinLanh.Data
{
    public class DataService : DataTable
    {
        #region -- Fields --
        private static SqlConnection m_Connection;
        //public static String m_ConnectString = "";
        private SqlCommand m_Command;
        private SqlDataAdapter m_DataAdapter;
        //private SqlDataReader m_DataReader;
        #endregion

        #region -- Constructor --

        //Mỗi khi khai báo sử dụng 
        //DataService data= new DataService(Control_Connect.ConnectionString())
        public DataService(string ConnectionString)
        {
            m_Connection = new SqlConnection(ConnectionString);
        }

        public DataService(bool emptyData)
        {
            if (emptyData == true)
            {
                m_Connection = null;
                m_Command = null;
                m_DataAdapter = null;
            }
        }
        #endregion

        

        #region -- Load --
        public void Load(SqlCommand m_Sql)
        {
            m_Command = m_Sql;
            try
            {
                m_Command.Connection = m_Connection;

                m_DataAdapter = new SqlDataAdapter();
                m_DataAdapter.SelectCommand = m_Command;
                this.Clear();
                m_DataAdapter.Fill(this);
            }
            catch (Exception e)
            {
                MessageBox.Show("Không thể thực thi câu lệnh SQL này!\nLỗi: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public SqlDataReader ExecuteReader(string m_connection, SqlCommand m_Sql)
        {
            m_Command = m_Sql;
            try
            {
                OpenConnection(m_connection);
                m_Command.Connection = m_Connection;
                var result = m_Command.ExecuteReader();
                CloseConnection();
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show("Không thể thực thi câu lệnh SQL này!\nLỗi: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseConnection();
                return null;
            }
            
        }
        public bool LoadSystemCommand(SqlCommand m_Sql)
        {
            m_Command = m_Sql;
            try
            {
                m_Command.Connection = m_Connection;

                m_DataAdapter = new SqlDataAdapter();
                m_DataAdapter.SelectCommand = m_Command;

                this.Clear();
                m_DataAdapter.Fill(this);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Không thể thực thi câu lệnh SQL này!\nLỗi: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region -- OpenConnection --
        public static bool OpenConnection(string m_ConnectString)
        {
            try
            {
                if (m_Connection == null)
                    m_Connection = new SqlConnection(m_ConnectString);
                if (m_Connection.State == ConnectionState.Closed)
                    m_Connection.Open();
                return true;
            }
            catch
            {
                m_Connection.Close();
                return false;
            }
        }        
        #endregion

        #region -- CloseConnection --
        public void CloseConnection()
        {
            m_Connection.Close();
        }
        #endregion

        #region -- ExecuteNoneQuery --
        public int ExecuteNoneQuery()
        {
            int result = 0;
            SqlTransaction m_SqlTran = null;
            try
            {
                m_SqlTran = m_Connection.BeginTransaction();

                m_Command.Connection = m_Connection;
                m_Command.Transaction = m_SqlTran;

                m_DataAdapter = new SqlDataAdapter();
                m_DataAdapter.SelectCommand = m_Command;

                SqlCommandBuilder builder = new SqlCommandBuilder(m_DataAdapter);

                result = m_DataAdapter.Update(this);
                m_SqlTran.Commit();
            }
            catch (Exception e)
            {
                if (m_SqlTran != null)
                    m_SqlTran.Rollback();
                MessageBox.Show("Không thể thực thi câu lệnh SQL này!\nLỗi: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region -- ExecuteNoneQuery --
        public int ExecuteNoneQuery(SqlCommand m_Sql)
        {
            int result = 0;
            SqlTransaction m_SqlTran = null;
            try
            {
                m_SqlTran = m_Connection.BeginTransaction();

                m_Sql.Connection = m_Connection;
                m_Sql.Transaction = m_SqlTran;
                result = m_Sql.ExecuteNonQuery();

                this.AcceptChanges();
                m_SqlTran.Commit();
            }
            catch (Exception e)
            {
                if (m_SqlTran != null)
                    m_SqlTran.Rollback();
                MessageBox.Show("Không thể thực thi câu lệnh SQL này!\nLỗi: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public int ExecuteNoneQuery_v2(SqlCommand m_Sql)
        {
            int result = 0;
            SqlTransaction m_SqlTran = null;
            try
            {
                m_SqlTran = m_Connection.BeginTransaction();

                m_Sql.Connection = m_Connection;
                m_Sql.Transaction = m_SqlTran;
                result = m_Sql.ExecuteNonQuery();

                this.AcceptChanges();
                m_SqlTran.Commit();
            }
            catch
            {
                if (m_SqlTran != null)
                    m_SqlTran.Rollback();
            }
            return result;
        }
        #endregion

        #region -- ExecuteScalar --
        public object ExecuteScalar(SqlCommand m_Sql)
        {
            object result = null;
            SqlTransaction m_SqlTran = null;
            try
            {
                m_SqlTran = m_Connection.BeginTransaction();
                m_Sql.Connection = m_Connection;
                m_Sql.Transaction = m_SqlTran;
                result = m_Sql.ExecuteScalar();

                this.AcceptChanges();
                m_SqlTran.Commit();
                if (result == DBNull.Value)
                {
                    result = null;
                }
            }
            catch
            {
                if (m_SqlTran != null)
                    m_SqlTran.Rollback();
                throw;
            }
            return result;
        }
        #endregion
    }
}
