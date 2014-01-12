using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Drawing;

namespace GDAL
{
    public class DB
    {
        string DBConnctionString = @"Server=NofoosDB.db.11898733.hostedresource.com;Database=NofoosDB;User Id=NofoosDB;Password=Delta@Code2013;";
         //string DBConnctionString = @"workstation id=192.168.0.1\mssql;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1\mssql;persist security info=False;initial catalog=FDB";
        //string DBConnctionString = @"Integrated Security=SSPI;Initial Catalog=NofoosDB;Data Source=.\SQLEXPRESS;";
        //string DBConnctionString = @"Integrated Security=true;Initial Catalog=NofoosDB;Data Source=.;";
        SqlDataReader Reader;
        SqlConnection Connction;
        SqlCommand Command;
        public DB()
        {
            Connction = new SqlConnection(DBConnctionString);
            Command = new SqlCommand();
            Command.Connection = Connction;
        }
        public DB(string _ConnectionString)
        {
            DBConnctionString = _ConnectionString;
            Connction = new SqlConnection(DBConnctionString);
           
            Command = new SqlCommand();
            Command.Connection = Connction;
        }
        public void PrepareConnection()
        {
            Connction.Close();
            if (Reader != null)
            {
                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();
            }
            if (Connction.State != ConnectionState.Open)
                Connction.Open();
            Command.Parameters.Clear();
        }
        public int Insert(object _Obj)
        {
            PrepareConnection();
            string ObjName= _Obj.GetType().Name;
            foreach (PropertyInfo Prop in _Obj.GetType().GetProperties().Where(p=>!p.Name.StartsWith("V_")))
            {
                if (!Prop.CanWrite)
                    continue;
                if (Prop.Name != "ID")
                Command.Parameters.AddWithValue(Prop.Name, Prop.GetValue(_Obj, null));
            }
            Command.CommandText = _Obj.ToString().Replace("GDAL." , "") + "Insert";
            Command.CommandType = CommandType.StoredProcedure;
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader.Read())
                    return int.Parse(Reader[0].ToString());
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }
        public int Update(object _Obj)
        {
            PrepareConnection();
            foreach (PropertyInfo Prop in _Obj.GetType().GetProperties().Where(p => !p.Name.StartsWith("V_")))
            {
                if (!Prop.CanWrite)
                    continue;
                Command.Parameters.AddWithValue(Prop.Name, Prop.GetValue(_Obj, null));
            }
            Command.CommandText = _Obj.ToString().Replace("GDAL.", "") + "Update";
            Command.CommandType = CommandType.StoredProcedure;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
                return int.Parse(Reader[0].ToString());
            else
                return -1;
        }
        public int Delete(object _Obj)
        {
            PrepareConnection();
            Command.Parameters.AddWithValue("ID", _Obj.GetType().GetProperty("ID").GetValue(_Obj,null));
            Command.CommandText = _Obj.ToString().Replace("GDAL.", "") + "Delete";
            Command.CommandType = CommandType.StoredProcedure;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
                return int.Parse(Reader[0].ToString());
            else
                return -1;
        }
        public int Delete(int _ID,string _TypeName)
        {
            PrepareConnection();
            Command.Parameters.AddWithValue("ID", _ID);
            Command.CommandText = _TypeName.Replace("GDAL.", "") + "Delete";
            Command.CommandType = CommandType.StoredProcedure;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
                return int.Parse(Reader[0].ToString());
            else
                return -1;
        }
        public object GetByID(int _ID, Type _Type)
        {
            PrepareConnection();
            Command.CommandText = _Type.Name.Replace("GDAL.", "") + "Select";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("ID", _ID);
            Reader = Command.ExecuteReader();
            object Obj = (object)Activator.CreateInstance(_Type);
            if (Reader.Read())
            {
                foreach (PropertyInfo Prop in _Type.GetProperties().Where(p=>!p.Name.StartsWith("V_")))
                {
                    if (!Prop.CanWrite)
                        continue;
                    switch (Prop.PropertyType.Name)
                    {
                        case "Int32":
                            Prop.SetValue(Obj, int.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "String":
                            Prop.SetValue(Obj, Reader[Prop.Name].ToString(), null);
                            break;
                        case "DateTime":
                            Prop.SetValue(Obj, DateTime.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "TimeSpan":
                            Prop.SetValue(Obj, TimeSpan.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Double":
                            Prop.SetValue(Obj, double.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Byte[]":
                            Prop.SetValue(Obj, (byte[])(Reader[Prop.Name]), null);
                            break;
                        case "Image":
                            Prop.SetValue(Obj, (Image)Reader[Prop.Name], null);
                            break;
                        case "Float":
                            Prop.SetValue(Obj, float.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Boolean":
                            Prop.SetValue(Obj, (bool)(Reader[Prop.Name]), null);
                            break;
                    }
                }
            }
            return Obj;
        }
        public List<object> Search(Type _Type, Dictionary<string, object> pars)
        {
            List<object> LstResult = new List<object>();
            PrepareConnection();
            object temp = (object)Activator.CreateInstance(_Type);
            Command.CommandText = temp.ToString().Replace("GDAL.", "") + "Search";
            temp = null;
            GC.Collect();
            Command.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string,object> pair in pars) {
             Command.Parameters.AddWithValue(pair.Key,pair.Value);
            }
            
            
            Reader = Command.ExecuteReader();
            while (Reader!=null&&Reader.Read())
            {
                object Obj = (object)Activator.CreateInstance(_Type);
                foreach (PropertyInfo Prop in _Type.GetProperties().Where(p => !p.Name.StartsWith("V_")))
                {
                    if (!Prop.CanWrite)
                        continue;
                    switch (Prop.PropertyType.Name)
                    {
                        case "Int32":
                            Prop.SetValue(Obj, int.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "String":
                            Prop.SetValue(Obj, Reader[Prop.Name].ToString(), null);
                            break;
                        case "TimeSpan":
                            Prop.SetValue(Obj, TimeSpan.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "DateTime":
                            Prop.SetValue(Obj, DateTime.SpecifyKind(DateTime.Parse(Reader[Prop.Name].ToString()), DateTimeKind.Utc), null);
                           
                            break;
                        case "Double":
                            Prop.SetValue(Obj, double.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Byte[]":
                            Prop.SetValue(Obj, (byte[])(Reader[Prop.Name]), null);
                            break;
                        case "Image":
                            Prop.SetValue(Obj, (Image)Reader[Prop.Name], null);
                            break;
                        case "Float":
                            Prop.SetValue(Obj, float.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Boolean":
                            Prop.SetValue(Obj, (bool)(Reader[Prop.Name]), null);
                            break;
                    }
                }
                LstResult.Add(Obj);
            }
            return LstResult;
        }
        public List<object> ExecuteList(string SPName, Type _Type, Dictionary<string, object> pars)
        {
            List<object> LstResult = new List<object>();
            PrepareConnection();
            Command.CommandText = SPName;
            Command.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> pair in pars)
            {
                Command.Parameters.AddWithValue(pair.Key, pair.Value);
            }

            Reader = Command.ExecuteReader();
            while (Reader != null && Reader.Read())
            {
                object Obj = (object)Activator.CreateInstance(_Type);
                foreach (PropertyInfo Prop in _Type.GetProperties())
                {
                    if (!Prop.CanWrite)
                        continue;
                    switch (Prop.PropertyType.Name)
                    {
                        case "Int32":
                            Prop.SetValue(Obj, int.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "String":
                            Prop.SetValue(Obj, Reader[Prop.Name].ToString(), null);
                            break;
                        case "TimeSpan":
                            Prop.SetValue(Obj, TimeSpan.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "DateTime":
                            Prop.SetValue(Obj, DateTime.SpecifyKind(DateTime.Parse(Reader[Prop.Name].ToString()), DateTimeKind.Utc), null);
                            break;
                        case "Double":
                            Prop.SetValue(Obj, double.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Byte[]":
                            Prop.SetValue(Obj, (byte[])(Reader[Prop.Name]), null);
                            break;
                        case "Image":
                            Prop.SetValue(Obj, (Image)Reader[Prop.Name], null);
                            break;
                        case "Float":
                            Prop.SetValue(Obj, float.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Boolean":
                            Prop.SetValue(Obj, (bool)(Reader[Prop.Name]), null);
                            break;
                    }
                }
                LstResult.Add(Obj);
            }
            return LstResult;
        }
        public object ExecuteObject(string SPName, int _ID, Type _Type)
        {
            PrepareConnection();
            Command.CommandText = SPName;
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("ID", _ID);
            Reader = Command.ExecuteReader();
            object Obj = (object)Activator.CreateInstance(_Type);
            if (Reader.Read())
            {
                foreach (PropertyInfo Prop in _Type.GetProperties())
                {
                    if (!Prop.CanWrite)
                        continue;
                    switch (Prop.PropertyType.Name)
                    {
                        case "Int32":
                            Prop.SetValue(Obj, int.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "String":
                            Prop.SetValue(Obj, Reader[Prop.Name].ToString(), null);
                            break;
                        case "DateTime":
                            Prop.SetValue(Obj, DateTime.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "TimeSpan":
                            Prop.SetValue(Obj, TimeSpan.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Double":
                            Prop.SetValue(Obj, double.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Byte[]":
                            Prop.SetValue(Obj, (byte[])(Reader[Prop.Name]), null);
                            break;
                        case "Image":
                            Prop.SetValue(Obj, (Image)Reader[Prop.Name], null);
                            break;
                        case "Float":
                            Prop.SetValue(Obj, float.Parse(Reader[Prop.Name].ToString()), null);
                            break;
                        case "Boolean":
                            Prop.SetValue(Obj, (bool)(Reader[Prop.Name]), null);
                            break;
                    }
                }
            }
            return Obj;
        }
    }
}
