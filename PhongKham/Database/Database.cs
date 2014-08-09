using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Clinic.Database
{
    public abstract class Database<TParameter, TDataReader, TConnection,
       TTransaction, TDataAdapter, TCommand, TDbConnectionStringBuilder> : IDatabase
        where TParameter : DbParameter, IDataParameter
        where TDataReader : DbDataReader, IDataReader
        where TConnection : DbConnection, IDbConnection, new()
        where TTransaction : DbTransaction, IDbTransaction
        where TDataAdapter : DbDataAdapter, IDataAdapter, new()
        where TCommand : DbCommand, IDbCommand, new()
        where TDbConnectionStringBuilder : DbConnectionStringBuilder
    {
        protected TConnection tConnection;
        protected TTransaction tTransaction;
        public Database(string strCon)
        {
            tConnection = new TConnection();
            tConnection.ConnectionString = strCon;
        }

        protected int ExecuteNonQuery(string StoreProcName, List<TParameter> Params)
        {
            bool internalOpen = false;
            TCommand cmd;


            try
            {

                cmd = new TCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (tTransaction != default(TTransaction))
                    cmd.Transaction = tTransaction;
                else
                    cmd.Connection = tConnection;

                if (Params != null || Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }

                if (tConnection.State == ConnectionState.Closed)
                {
                    tConnection.Open();
                    internalOpen = true;
                }


                return cmd.ExecuteNonQuery();


            }
            catch (DbException DbEx)
            {
                throw DbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (internalOpen)
                    tConnection.Close();
            }
        }

        protected  TDataReader ExecuteReader(string StoreProcName, List<TParameter> Params)
        {
            bool internalOpen = false;
            TCommand cmd;


            try
            {

                cmd = new TCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (tTransaction != default(TTransaction))
                    cmd.Transaction = tTransaction;
                else
                    cmd.Connection = tConnection;

                if (Params != null || Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }

                if (tConnection.State == ConnectionState.Closed)
                {
                    tConnection.Open();
                    internalOpen = true;
                }


                return (TDataReader)cmd.ExecuteReader();

            }
            catch (DbException DbEx)
            {
                throw DbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (internalOpen)
                    tConnection.Close();
            }
        }

        protected TDataReader ExecuteReader(string StoreProcName)
        {
            return ExecuteReader(StoreProcName);
        }




        public void Dispose()
        {
            throw new NotImplementedException();
        }



        public IDataReader ExecuteReader(string StoreProcName, List<IDataParameter> Params)
        {
            return ExecuteReader(StoreProcName, Params);
        }
    }
}
