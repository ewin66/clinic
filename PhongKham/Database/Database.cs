using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Clinic.Helpers;

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
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (tTransaction != default(TTransaction))
                    cmd.Transaction = tTransaction;
                else
                    cmd.Connection = tConnection;

                if (Params != null && Params.Count > 0)
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

        protected  TDataReader ExecuteReader2(string StoreProcName, List<TParameter> Params,ref bool hasRows)
        {
            bool internalOpen = false;
            TCommand cmd;


            try
            {

                cmd = new TCommand();
               // cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (tTransaction != default(TTransaction))
                    cmd.Transaction = tTransaction;
                else
                    cmd.Connection = tConnection;

                if (Params != null && Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }

                if (tConnection.State == ConnectionState.Closed)
                {
                    tConnection.Open();
                    internalOpen = true;
                }

                TDataReader temp = (TDataReader)cmd.ExecuteReader();
               
                temp.Read();
                hasRows = temp.HasRows;
                return temp;

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


        protected void CreateDatabase(string password)
        {

            ExecuteNonQuery("CREATE DATABASE IF NOT EXISTS clinic;", null);
            tConnection.ConnectionString += ";database=clinic;";
            tConnection.ConnectionString += ";password="+password;     
            ExecuteNonQuery("CREATE Table IF NOT EXISTS clinicuser(Username varchar(50),Password1  varchar(50),Authority  smallint(6), Password2  varchar(50));",null);

            ExecuteNonQuery("CREATE Table IF NOT EXISTS history(Id varchar(10),Symptom Longtext,Diagnose Longtext,Medicines Longtext,Day Datetime);", null);

            ExecuteNonQuery("CREATE Table IF NOT EXISTS medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10));", null);

            ExecuteNonQuery("CREATE Table IF NOT EXISTS patient(Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11),Id varchar(10));", null);

        }


        public void Dispose()
        {
           
            throw new NotImplementedException();
        }



        public IDataReader ExecuteReader(string StoreProcName, List<IDataParameter> Params, ref bool hasrow)
        {

            return ExecuteReader2(StoreProcName, null,ref hasrow);
        }


        void IDatabase.CreateDatabase(string password)
        {
             CreateDatabase(password);
        }


        public void InsertRowToTable(string nameOfTable, List<string> nameOfColumns, List<string> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                values[i] =Helper.ConvertToSqlString(values[i]);
            }

            string columns = "Insert Into " + nameOfTable + " (";
            foreach (string name in nameOfColumns)
            {
                columns += name + ",";
            }
            columns = columns.Remove(columns.Length - 1);
            columns += ")";
            string vals = " VALUES (";
            foreach (string value in values)
            {
                vals += value + ",";
            }
            vals = vals.Remove(vals.Length - 1);
            vals += ")";

            string strCommand = columns + vals;
            ExecuteNonQuery(strCommand,null);
        }
    }
}
