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

        protected  TDataReader ExecuteReader(string StoreProcName, List<TParameter> Params)
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
               // reader need connection still open for read() , and note : close connection

                //if (internalOpen)
                //    tConnection.Close();
            }
        }


        protected void CreateDatabase(string password)
        {
            try
            {
                string strCommand = "grant all privileges on *.* to 'root'@'%' identified by " + Helper.ConvertToSqlString(password);
                ExecuteNonQuery(strCommand, null);
                ExecuteNonQuery("CREATE DATABASE IF NOT EXISTS clinic;", null);
                tConnection.ConnectionString += ";database=clinic;";
                tConnection.ConnectionString += ";password=" + password;
                ExecuteNonQuery("CREATE Table IF NOT EXISTS clinicuser(Username varchar(50),Password1  varchar(50),Authority  smallint(6), Password2  varchar(50));", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS history(Id varchar(10),Symptom Longtext,Diagnose Longtext,Medicines Longtext,Day Datetime);", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10));", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS patient(Idpatient INT NOT NULL AUTO_INCREMENT,Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11),PRIMARY KEY (Idpatient));", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS calendar(IdCalendar INT NOT NULL,Username varchar(50),StartTime datetime,EndTime datetime,Text Longtext,Color int, PRIMARY KEY (IdCalendar));", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS listpatienttoday(Id varchar(10) NOT NULL,Name TEXT NULL,State VARCHAR(45) NULL, PRIMARY KEY (Id));", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS doanhthu(Iddoanhthu INT NOT NULL AUTO_INCREMENT,Namedoctor TEXT NULL,Money int NULL,time datetime, PRIMARY KEY (Iddoanhthu));", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS lichhen(Idlichhen INT NOT NULL AUTO_INCREMENT,Idpatient varchar(10),Namedoctor TEXT NULL,Namepatient TEXT NULL,time datetime,benh TEXT NULL,phone VARCHAR(45), PRIMARY KEY (Idlichhen));", null);

                UpdateDatabase(password);
            }
            catch (Exception e)
            { }
            
        }

        private void Guard(Func<int> action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            { }
        }


        private void UpdateDatabase(string password)
        {
           
            
            Func<int> fun = () => ExecuteNonQuery("ALTER TABLE medicine CHARACTER SET = utf16 , COLLATE = utf16_unicode_ci", null);
            fun=()=> ExecuteNonQuery("ALTER TABLE clinicuser ADD PRIMARY KEY(Username);", null);
            Guard(fun);;

            fun = () => ExecuteNonQuery("ALTER TABLE medicine ADD COLUMN Hdsd TEXT NULL AFTER Id", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE listpatienttoday ADD COLUMN time datetime NULL AFTER Id", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE patient ADD COLUMN phone VARCHAR(45) NULL AFTER Name;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery(" ALTER TABLE patient CHANGE COLUMN height height TEXT NULL DEFAULT NULL , CHANGE COLUMN weight weight TEXT NULL DEFAULT NULL ;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE clinicuser ADD COLUMN namedoctor TEXT NULL AFTER Password2;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE history ADD COLUMN temperature TEXT NULL AFTER Symptom;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE history ADD COLUMN huyetap TEXT NULL AFTER temperature;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("CREATE event delete on schedule every 1 day starts at timestamp '2007-03-25 23:59:00' do delete from listpatienttoday", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE doanhthu  ADD COLUMN Idpatient TEXT NULL , ADD COLUMN Namepatient TEXT NULL;", null);
            Guard(fun);

        }

        //protected void CreateDatabase(string password)
        //{

        //    ExecuteNonQuery("CREATE DATABASE IF NOT EXISTS ClinicDb;", null);
        //    tConnection.ConnectionString += ";database=ClinicDb;";
        //    tConnection.ConnectionString += ";password=" + password;
        //    ExecuteNonQuery("CREATE Table IF NOT EXISTS clinicuser(Username varchar(50),Password1  varchar(50),Authority  smallint(6), Password2  varchar(50),PRIMARY KEY (Username) );", null);

        //    ExecuteNonQuery("CREATE Table IF NOT EXISTS history(Id varchar(10),Symptom Longtext,Diagnose Longtext,Medicines Longtext,Day Datetime);", null);

        //    ExecuteNonQuery("CREATE Table IF NOT EXISTS medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,IdMedicine varchar(10), PRIMARY KEY (IdMedicine,Name) );", null);

        //    ExecuteNonQuery("CREATE Table IF NOT EXISTS patient(Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11),IdPatient varchar(10),PRIMARY KEY (IdPatient,Name));", null);

        //}





        #region implement Interface IDatabase

        IDataReader IDatabase.ExecuteReader(string StoreProcName, List<IDataParameter> Params)
        {

            return ExecuteReader(StoreProcName, Params as List<TParameter>);
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
            ExecuteNonQuery(strCommand, null);
        }


         int IDatabase.ExecuteNonQuery(string StoreProcName, List<IDataParameter> Params)
        {
            return ExecuteNonQuery(StoreProcName, Params as List<TParameter>);
        }
        #endregion


         public void CloseCurrentConnection()
         {
             tConnection.Close();
         }
    }
}
