using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    ///功能说明:   DBScript构造方法类 
    ///创建人:     Bano
    ///最后更新:   2009/09/17 
    ///创建时间:   2009/09/17     
    /// </summary>
    public class DBScript<T>
    {
        private QueryBase _QueryBuilder = null;
        /// <summary>
        /// 查询器
        /// </summary>
        public QueryBase QueryBuilder
        {
            get { return _QueryBuilder; }
            set { _QueryBuilder = value; }
        }


        private string _PrimaryKey = "";
        private string _TableName = "";
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            get { return _PrimaryKey; }
            set { _PrimaryKey = value; }
        }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
                if (string.IsNullOrEmpty(_TableName))
                {
                    return this.GetType().Name;
                }
                return _TableName;
            }
            set { _TableName = value; }
        }

        public DBScript()
        {
            //Type type = typeof(T);

            //object[] os = type.GetCustomAttributes(typeof(EntityMappingAttribute), false);

            //foreach (object o in os)
            //{
            //    if (o.GetType() == typeof(EntityMappingAttribute))
            //    {
            //        EntityMappingAttribute em = o as EntityMappingAttribute;
            //        TableName = em.TableName;

            //        break;
            //    }
            //}

            //if (string.IsNullOrEmpty(TableName))
            //    TableName = type.Name.ToString();
        }

        public bool save(T t, DBManager pDbManager)
        {
            Type type = typeof(T);

            string fields = string.Empty;
            string values = string.Empty;

            PropertyInfo p = type.GetProperty("hash");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict = (Dictionary<string, string>)p.GetValue(t, null);

            int i = 0;
            foreach (string field in dict.Keys)
            {
                i++;

                PropertyInfo pinfo = type.GetProperty(field);

                EntityMappingAttribute qa = (EntityMappingAttribute)Attribute.GetCustomAttribute(pinfo, typeof(EntityMappingAttribute));

                fields += field;

                if (qa == null)
                {
                    values += "'" + SqlHelper.GetStringValue(dict[field]) + "'";
                }
                else
                {
                    if (qa.RealNumber)
                        values += "" + SqlHelper.GetNumberValue(dict[field].Trim()) + "";
                    else if (qa.DateTime)
                        values += "to_date('" + SqlHelper.GetDateTimeValueQuote(dict[field]) + "','yyyy/MM/dd HH24:mi:ss')";
                    else
                        values += "'" + SqlHelper.GetStringValue(dict[field]) + "'";

                }

                if (dict.Keys.Count > i)
                {
                    fields += ",";
                    values += ",";
                }
            }

            string sql = "insert into " + TableName + "(" + fields + ")values(" + values + ")";
            return pDbManager.ExecuteSqlBool(sql);
        }

        public bool update(T t, DBManager pDbManager)
        {
            Type type = typeof(T);

            PropertyInfo p = type.GetProperty("hash");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict = (Dictionary<string, string>)p.GetValue(t, null);

            string kv = string.Empty;

            string idWhere = " where 1=1";
            StringBuilder sql = new StringBuilder();
            foreach (string field in dict.Keys)
            {
                PropertyInfo pinfo = type.GetProperty(field);

                EntityMappingAttribute qa = (EntityMappingAttribute)Attribute.GetCustomAttribute(pinfo, typeof(EntityMappingAttribute));

                if (qa != null)
                {
                    if (qa.PrimaryKey)
                    {
                        if (qa.RealNumber)
                            idWhere += " and " + field + "=" + dict[field] + "";
                        else
                            idWhere += " and " + field + "='" + dict[field] + "'";
                    }
                    else
                    {
                        if (kv.Length > 0)
                        {
                            kv += ",";
                        }
                        if (!qa.RealNumber)
                        {
                            if (qa.DateTime)
                                kv += field + "=to_date('" + SqlHelper.GetDateTimeValueQuote(dict[field]) + "','yyyy/MM/dd HH24:mi:ss')";
                            else
                                kv += field + "='" + SqlHelper.GetStringValue(dict[field]) + "'";
                        }
                        else
                        {
                            kv += field + "=" + dict[field] + "";
                        }
                    }
                }
                else
                {
                    if (kv.Length > 0)
                    {
                        kv += ",";
                    }
                    kv += field + "='" + SqlHelper.GetStringValue(dict[field]) + "'";
                }
            }
            sql.Append("update ");
            sql.Append(TableName);
            sql.Append(" set ");
            sql.Append(kv);
            sql.Append(idWhere);
            return pDbManager.ExecuteSqlBool(sql.ToString());
        }

        public bool update(T t, string pList, DBManager pDbManager)
        {
            Type type = typeof(T);

            PropertyInfo p = type.GetProperty("hash");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict = (Dictionary<string, string>)p.GetValue(t, null);

            //string pk = DBTableHelper.GetTablePkByAccess(TableName);
            //string items = StringHelper.GetArrayValue(pk, ':', 0);
            string kv = string.Empty;
            string idWhere = string.Empty;
            StringBuilder sql = new StringBuilder();
            foreach (string field in dict.Keys)
            {
                PropertyInfo pinfo = type.GetProperty(field);

                EntityMappingAttribute qa = (EntityMappingAttribute)Attribute.GetCustomAttribute(pinfo, typeof(EntityMappingAttribute));

                if (qa != null)
                {
                    if (qa.PrimaryKey)
                    {
                        idWhere = " where " + field + " in (" + pList + ")";
                    }
                    else
                    {
                        if (kv.Length > 0)
                        {
                            kv += ",";
                        }
                        if (!qa.RealNumber)
                        {
                            if (qa.DateTime)
                                kv += field + "=to_date('" + SqlHelper.GetDateTimeValueQuote(dict[field]) + "','yyyy/MM/dd HH24:mi:ss')";
                            else
                                kv += field + "='" + SqlHelper.GetStringValue(dict[field]) + "'";
                        }
                        else
                        {
                            kv += field + "=" + dict[field] + "";
                        }
                    }
                }
                else
                {
                    if (kv.Length > 0)
                    {
                        kv += ",";
                    }
                    kv += field + "=N'" + SqlHelper.GetStringValue(dict[field]) + "'";
                }
            }
            sql.Append("update ");
            sql.Append(TableName);
            sql.Append(" set ");
            sql.Append(kv);
            sql.Append(idWhere);
            return pDbManager.ExecuteSqlBool(sql.ToString());
        }

        public bool delete(T t, DBManager pDbManager)
        {
            Type type = typeof(T);

            PropertyInfo p = type.GetProperty("hash");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict = (Dictionary<string, string>)p.GetValue(t, null);
            string idWhere = " where 1=1";
            foreach (string field in dict.Keys)
            {
                PropertyInfo pinfo = type.GetProperty(field);
                EntityMappingAttribute qa = (EntityMappingAttribute)Attribute.GetCustomAttribute(pinfo, typeof(EntityMappingAttribute));

                if (qa.PrimaryKey)
                {
                    if (qa.RealNumber)
                        idWhere += " and " + field + "=" + dict[field] + "";
                    else
                        idWhere += " and " + field + "='" + dict[field] + "'";
                }
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("delete ");
            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(idWhere);
            return pDbManager.ExecuteSqlBool(sql.ToString());
        }

        public bool delete(string id, DBManager pDbManager)
        {
            string idWhere = " where " + PrimaryKey + "='" + id + "'";

            StringBuilder sql = new StringBuilder();
            sql.Append("delete ");
            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(idWhere);
            return pDbManager.ExecuteSqlBool(sql.ToString());
        }

        public bool delete(SqlParameters sqlparams, DBManager pDbManager)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete ");
            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(" where ");
            sql.Append(sqlparams.conditions);
            return pDbManager.ExecuteSqlBool(sql.ToString());
        }

        public T find(T o, DBManager pDbManager)
        {
            Type type = typeof(T);
            object dynObj = Activator.CreateInstance(type);

            PropertyInfo p = type.GetProperty("hash");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict = (Dictionary<string, string>)p.GetValue(o, null);
            string idWhere = " where 1=1";
            foreach (string field in dict.Keys)
            {
                PropertyInfo pinfo = type.GetProperty(field);
                EntityMappingAttribute qa = (EntityMappingAttribute)Attribute.GetCustomAttribute(pinfo, typeof(EntityMappingAttribute));
                if (qa != null)
                {
                    if (qa.PrimaryKey)
                    {
                        if (qa.RealNumber)
                            idWhere += " and " + field + "=" + dict[field] + "";
                        else
                            idWhere += " and " + field + "='" + dict[field] + "'";
                    }
                }
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append("*");
            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(idWhere);
            return pDbManager.Entity<T>(sql.ToString(), dynObj);
        }

        public T find(string id, DBManager pDbManager)
        {
            Type type = typeof(T);
            object dynObj = Activator.CreateInstance(type);
            string idWhere = " where " + PrimaryKey + "='" + id + "'";

            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append("*");
            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(idWhere);
            return pDbManager.Entity<T>(sql.ToString(), dynObj);
        }

        public string find(string fields, string column, string values, bool isNumber, DBManager pDbManager)
        {
            Type type = typeof(T);
            object dynObj = Activator.CreateInstance(type);

            StringBuilder vWhere = new StringBuilder();

            vWhere.Append(column + "=");
            if (isNumber)
                vWhere.Append(values);
            else
                vWhere.Append("'" + values + "'");
            return pDbManager.GetDs(fields, TableName, vWhere.ToString());
        }

        public T findModel(string values, string fields, string column, bool isNumber, DBManager pDbManager)
        {
            Type type = typeof(T);
            object dynObj = Activator.CreateInstance(type);

            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append(fields);
            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(" where " + column + "=");
            if (isNumber)
                sql.Append(values);
            else
                sql.Append("'" + values.ToString() + "'");
            return pDbManager.Entity<T>(sql.ToString(), dynObj);
        }
        public T find(SqlParameters sqlparams, DBManager pDbManager)
        {
            Type type = typeof(T);
            object dynObj = Activator.CreateInstance(type);

            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append(sqlparams.select);
            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(" where ");
            sql.Append(sqlparams.conditions);
            return pDbManager.Entity<T>(sql.ToString(), dynObj);
        }

        public DataTable objects(DBManager pDbManager)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append(" from ");
            sql.Append(TableName);
            return pDbManager.Query(sql.ToString()).Tables[0];
        }

        public DataTable objects(SqlParameters sqlparams, DBManager pDbManager)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            if (sqlparams.limit > 0)
            {
                sql.Append("top ");
                sql.Append(sqlparams.limit.ToString());
                sql.Append(" ");
            }
            if (!string.IsNullOrEmpty(sqlparams.select))
                sql.Append(sqlparams.select);

            sql.Append(" from ");
            sql.Append(TableName);
            sql.Append(" ");
            sql.Append(sqlparams.joins);
            if (sqlparams.conditions != null && sqlparams.conditions.Length > 0)
            {
                sql.Append(" where ");
                sql.Append(sqlparams.conditions);
                sql.Append(" ");
            }
            if (sqlparams.order != null && sqlparams.order.Length > 0)
            {
                sql.Append(" order by  ");
                sql.Append(sqlparams.order);
            }
            return pDbManager.Query(sql.ToString()).Tables[0];
        }

        public DataTable objects(SqlParameters sqlparams, Pagination pager, DBManager pDbManager)
        {
            StringBuilder strSql = new StringBuilder();
            switch (DBHelperFactory.dbType)
            {
                case DataBaseType.SqlServer:
                    strSql.Append(" select ");
                    strSql.Append(sqlparams.select);
                    strSql.Append(" from ");
                    strSql.Append(" (select ROW_NUMBER() OVER ");
                    strSql.Append(" (ORDER BY " + sqlparams.pk + " desc) AS RowNumber,* from " + TableName + "");
                    if (sqlparams.conditions != null && sqlparams.conditions.Length > 0)
                    {
                        strSql.Append(" where ");
                        strSql.Append(sqlparams.conditions);
                    }
                    strSql.Append(" ) as _TempTable");
                    strSql.Append(" WHERE RowNumber between ("
                        + pager.PageNumber + "-1)*"
                        + pager.PageSize + "+1 and ("
                        + pager.PageNumber + "-1+1)*"
                        + pager.PageSize + "");
                    break;
                case DataBaseType.Oracle:
                    strSql.Append("SELECT *");
                    strSql.Append(" FROM (SELECT wA.*, ROWNUM RN");
                    strSql.Append(" FROM (" + sqlparams.sql + ") wA");
                    strSql.Append("  WHERE ROWNUM <=(" + pager.PageNumber + "-1+1)*" + pager.PageSize);
                    strSql.Append(" WHERE RN >= (" + pager.PageNumber + "-1)*" + pager.PageSize + "+1");
                    break;
            }

            return pDbManager.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得数据集
        /// </summary>
        /// <returns></returns>
        public List<T> GetList<T>(DBManager pDbManage) where T : DBScript<T>, new()
        {
            //if (!_IsRunProc)
            //{
            T t = new T();
            //if (string.IsNullOrEmpty(QueryBuilder.Table))
            //{
            //    QueryBuilder.Table = t.TableName;
            //    QueryBuilder.PrimaryKey = t.PrimaryKey;
            //}
            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append(" from ");
            sql.Append(TableName);
            return GetList<T>(pDbManage.GetDataRead(sql.ToString()));
            //}
            //else //执行存储过程返回列表数据 Add by Snail
            //{
            //    DataTable dt = GetDataTable();
            //    return GetList<T>(dt);
            //}
        }

        /// <summary>
        /// 获得数据集
        /// </summary>
        /// <returns></returns>
        public List<T> GetList<T>(SqlParameters sqlparams, DBManager pDbManage) where T : DBScript<T>, new()
        {
            //if (!_IsRunProc)
            //{
            T t = new T();
            //if (string.IsNullOrEmpty(QueryBuilder.Table))
            //{
            //    QueryBuilder.Table = t.TableName;
            //    QueryBuilder.PrimaryKey = t.PrimaryKey;
            //}
            StringBuilder sql = new StringBuilder();
            if (!string.IsNullOrEmpty(sqlparams.sql))
                sql.Append(sqlparams.sql);
            else
            {
                sql.Append("select ");
                if (sqlparams.limit > 0)
                {
                    sql.Append("top ");
                    sql.Append(sqlparams.limit.ToString());
                    sql.Append(" ");
                }
                if (!string.IsNullOrEmpty(sqlparams.select))
                    sql.Append(sqlparams.select);

                sql.Append(" from ");
                sql.Append(TableName);
                sql.Append(" ");
                sql.Append(sqlparams.joins);
                if (sqlparams.conditions != null && sqlparams.conditions.Length > 0)
                {
                    sql.Append(" where ");
                    sql.Append(sqlparams.conditions);
                    sql.Append(" ");
                }
                if (sqlparams.order != null && sqlparams.order.Length > 0)
                {
                    sql.Append(" order by  ");
                    sql.Append(sqlparams.order);
                }
            }
            return GetList<T>(pDbManage.GetDataRead(sql.ToString()));
            //}
            //else //执行存储过程返回列表数据 Add by Snail
            //{
            //    DataTable dt = GetDataTable();
            //    return GetList<T>(dt);
            //}
        }

        /// <summary>
        /// 获得数据集
        /// </summary>
        /// <returns></returns>
        public ArrayList GetList<T>(SqlParameters sqlparams, Pagination pager, DBManager pDbManage) where T : DBScript<T>, new()
        {
            //if (!_IsRunProc)
            //{
            T t = new T();
            //if (string.IsNullOrEmpty(QueryBuilder.Table))
            //{
            //    QueryBuilder.Table = t.TableName;
            //    QueryBuilder.PrimaryKey = t.PrimaryKey;
            //}
            StringBuilder strSql = new StringBuilder();
            string vSql = string.Empty;

            switch (DBHelperFactory.dbType)
            {
                case DataBaseType.SqlServer:
                    if (!string.IsNullOrEmpty(sqlparams.sql))
                        vSql = sqlparams.sql;
                    else
                    {
                        if (sqlparams.conditions != null && sqlparams.conditions.Length > 0)
                        {
                            vSql += " where ";
                            vSql += sqlparams.conditions;
                        }
                    }

                    strSql.Append("select * from (select ROW_NUMBER() OVER (ORDER BY " + PrimaryKey + " desc) AS RowNumber,");
                    strSql.Append(sqlparams.select);
                    strSql.Append(" from ");
                    strSql.Append(" ( ");
                    strSql.Append(vSql);
                    strSql.Append(" ) as _TempTable) dbscripttable ");
                    strSql.Append(" WHERE RowNumber between ("
                        + pager.PageNumber + "-1)*"
                        + pager.PageSize + "+1 and ("
                        + pager.PageNumber + "-1+1)*"
                        + pager.PageSize + "");
                    break;
                case DataBaseType.Oracle:
                    if (!string.IsNullOrEmpty(sqlparams.sql))
                        vSql = sqlparams.sql;
                    else
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append("select ");
                        if (sqlparams.limit > 0)
                        {
                            sql.Append("top ");
                            sql.Append(sqlparams.limit.ToString());
                            sql.Append(" ");
                        }
                        if (!string.IsNullOrEmpty(sqlparams.select))
                            sql.Append(sqlparams.select);

                        sql.Append(" from ");
                        sql.Append(TableName);
                        sql.Append(" ");
                        sql.Append(sqlparams.joins);
                        if (sqlparams.conditions != null && sqlparams.conditions.Length > 0)
                        {
                            sql.Append(" where ");
                            sql.Append(sqlparams.conditions);
                            sql.Append(" ");
                        }
                        if (sqlparams.order != null && sqlparams.order.Length > 0)
                        {
                            sql.Append(" order by  ");
                            sql.Append(sqlparams.order);
                        }
                        vSql = sql.ToString();
                    }
                    strSql.Append("SELECT *");
                    strSql.Append(" FROM (SELECT wA.*, ROWNUM RN");
                    strSql.Append(" FROM (" + vSql + ") wA");
                    strSql.Append("  WHERE ROWNUM <=(" + pager.PageNumber + "-1+1)*" + pager.PageSize + ")");
                    strSql.Append(" WHERE RN >= (" + pager.PageNumber + "-1)*" + pager.PageSize + "+1");
                    break;
            }

            int vCount = int.Parse(pDbManage.Query("select count(*) from (" + strSql.ToString()
                                + ") as tb").Tables[0].Rows[0][0].ToString());

            ArrayList returnValue = new ArrayList();
            returnValue.Add(GetList<T>(pDbManage.GetDataRead(strSql.ToString())));
            returnValue.Add(vCount);
            return returnValue;

            //}
            //else //执行存储过程返回列表数据 Add by Snail
            //{
            //    DataTable dt = GetDataTable();
            //    return GetList<T>(dt);
            //}
        }




        /// <summary>
        /// 获得List集合
        /// </summary>
        /// <param name="dr">将DataReader里的实体转到List</param>
        public List<T> GetList<T>(IDataReader dr) where T : DBScript<T>, new()
        {
            List<T> list = new List<T>();
            if (dr == null)
            {
                return list;
            }

            while (dr.Read())
            {
                list.Add(GetModel<T>(dr));
            }
            dr.Dispose();
            return list;
        }

        /// <summary>
        /// 获得一个Model对象实例
        /// </summary>
        public T GetModel<T>(IDataReader dr) where T : DBScript<T>, new()
        {
            T model = new T();
            PropertyInfo[] pis = GetPropertyInfos<T>();
            int iIndex;
            foreach (PropertyInfo pi in pis)
            {
                DbColumnAttribute dbColumn = GetDBColumn(pi);
                if (dbColumn == null)
                {
                    continue;
                }

                try
                {
                    iIndex = dr.GetOrdinal(dbColumn.Name);
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
                try
                {
                    if (dr.IsDBNull(iIndex))
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }
                //Console.WriteLine(pi.Name + ":" + dr.GetValue(iIndex).GetType());
                pi.SetValue(model, ConvertValue(dr.GetValue(iIndex)), null);
            }
            //dr.Dispose();
            return model;
        }


        public int count(DBManager pDbManager)
        {
            return pDbManager.GetRsCount(TableName);
        }

        public int count(SqlParameters sqlparams, DBManager pDbManager)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(TableName);
            sql.Append(" where ");
            sql.Append(sqlparams.conditions);
            return pDbManager.GetRsCount(sql.ToString());
        }

        public int max(string pColumn, DBManager pDbManager)
        {
            return pDbManager.GetMaxID(pColumn, TableName);
        }

        public string max(SqlParameters sqlparams, DBManager pDbManager)
        {
            return pDbManager.GetMaxValue(sqlparams.select, TableName, sqlparams.conditions);
        }

        /// <summary>
        /// 获取类型属性集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual PropertyInfo[] GetPropertyInfos<T>() where T : DBScript<T>, new()
        {
            Type type = typeof(T);
            string key = string.Format("Class.PropertyInfos.{0}", type.FullName);
            StaticHashCache cache = new StaticHashCache();
            PropertyInfo[] pis = cache[key] as PropertyInfo[];

            if (pis == null)
            {
                pis = type.GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            }

            cache[key] = pis;
            return pis;
        }
        /// <summary>
        /// 转换值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual object ConvertValue(object obj)
        {
            return obj;
        }
        /// <summary>
        /// 根据实体属性获取数据库字段
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        protected virtual DbColumnAttribute GetDBColumn(PropertyInfo pi)
        {
            DbColumnAttribute returnValue = new DbColumnAttribute();
            object[] attrs = pi.GetCustomAttributes(typeof(ExcludeAttribute), false);
            if (attrs.Length > 0)
            {
                return null;
            }
            attrs = pi.GetCustomAttributes(typeof(DbColumnAttribute), false);
            if (attrs.Length > 0)
            {
                returnValue = attrs[0] as DbColumnAttribute;
            }
            if (string.IsNullOrEmpty(returnValue.Name))
            {
                returnValue.Name = pi.Name;
            }

            return returnValue;
        }
    }
}
