using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    ///功能说明:   通用方法重构类 
    ///创建人:     Bano
    ///最后更新:   2009/09/17 
    ///创建时间:   2009/09/17     
    /// </summary>
    public class BaseService<T> where T : DBScript<T>, new()
    {
        T t;
        DBManager _dbManager;
        public BaseService(bool pDBManager)
        {
            t = new T();
        }
        public BaseService()
        {
            _dbManager = new DBManager();
            t = new T();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool Add(T o)
        {
            DBManager _dbManager=new DBManager();
            _dbManager.ConnectionOpen();
            bool i = o.save(o,_dbManager);
            _dbManager.ConnectionClose();
            return i;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool Edit(T o)
        {
            DBManager _dbManager = new DBManager();
            _dbManager.ConnectionOpen();
            bool i = o.update(o, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool Edit(T o,string pList)
        {
            DBManager _dbManager = new DBManager();
            _dbManager.ConnectionOpen();
            bool i = o.update(o, pList, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(T o)
        {
            DBManager _dbManager = new DBManager();
            _dbManager.ConnectionOpen();
            bool i = o.delete(o, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(string id)
        {
            DBManager _dbManager = new DBManager();
            T o = new T();
            _dbManager.ConnectionOpen();
            bool i = o.delete(id, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }
        /// <summary>
        /// 删除带条件
        /// </summary>
        /// <param name="sqlparams">条件</param>
        /// <returns></returns>
        public bool Delete(SqlParameters sqlparams)
        {
            DBManager _dbManager = new DBManager();
            T o = new T();
            _dbManager.ConnectionOpen();
            bool i = o.delete(sqlparams, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }
        /// <summary>
        /// 获取泛型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public static T Get(T p)
        {
            DBManager _dbManager = new DBManager();
            T o = new T();
            _dbManager.ConnectionOpen();
            T w =o.find(p,_dbManager);
            _dbManager.ConnectionClose();
            return w;
        }

        /// <summary>
        /// 获取泛型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public static T Get(string id)
        {
            DBManager _dbManager = new DBManager();
            T o = new T();
            _dbManager.ConnectionOpen();
            T w = o.find(id, _dbManager);
            _dbManager.ConnectionClose();
            return w;
        }

        /// <summary>
        /// 获取泛型 带条件
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="fields">条件</param>
        /// <returns></returns>
        public string Get(string fields, string col, string values, bool isNumber)
        {
            string vTempValue = string.Empty;
            _dbManager.ConnectionOpen();
            vTempValue = t.find(fields, col, values, isNumber, _dbManager);
            _dbManager.ConnectionClose();
            return vTempValue;
        }

        /// <summary>
        /// 获取泛型 带条件
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="fields">条件</param>
        /// <returns></returns>
        public T GetModel(string values, string fields, string col, bool isNumber)
        {
            _dbManager.ConnectionOpen();
            T o = t.findModel(values, fields, col, isNumber, _dbManager);
            _dbManager.ConnectionClose();
            return o;
        }
        /// <summary>
        /// 获取泛型 定制
        /// </summary>
        /// <param name="sqlparams">参数</param>
        /// <returns></returns>
        public T Get(SqlParameters sqlparams)
        {
            T o = new T();
            _dbManager.ConnectionOpen();
            T w = o.find(sqlparams, _dbManager);
            _dbManager.ConnectionClose();
            return w;
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DataTable List()
        {
            _dbManager.ConnectionOpen();
            DataTable dt = t.objects(_dbManager);
            _dbManager.ConnectionClose();
            return dt;
        }

        public List<T> GetList()
        {
            _dbManager.ConnectionOpen();
            var vList = t.GetList<T>(_dbManager);
            _dbManager.ConnectionClose();
            return vList;
        }

        public List<T> GetList(SqlParameters sqlparams)
        {
            _dbManager.ConnectionOpen();
            var vList = t.GetList<T>(sqlparams,_dbManager);
            _dbManager.ConnectionClose();
            return vList;
        }

        public ArrayList GetListAndCount(SqlParameters sqlparams, Pagination pager)
        {
            _dbManager.ConnectionOpen();
            var vList = t.GetList<T>(sqlparams,pager, _dbManager);
            _dbManager.ConnectionClose();
            return vList;
        }
        /// <summary>
        /// 获取数据集 定制
        /// </summary>
        /// <param name="sqlparams">参数</param>
        /// <returns></returns>
        public DataTable List(SqlParameters sqlparams)
        {
            _dbManager.ConnectionOpen();
            DataTable dt = t.objects(sqlparams, _dbManager);
            _dbManager.ConnectionClose();
            return dt;
        }
        /// <summary>
        /// 获取数据集 定制 分页
        /// </summary>
        /// <param name="sqlparams">定制参数</param>
        /// <param name="pager">分页参数</param>
        /// <returns></returns>
        public DataTable List(SqlParameters sqlparams, Pagination pager)
        {
            _dbManager.ConnectionOpen();
            DataTable dt = t.objects(sqlparams, pager, _dbManager);
            _dbManager.ConnectionClose();
            return dt;
        }
        /// <summary>
        /// 获取总数量
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            _dbManager.ConnectionOpen();
            int i = t.count(_dbManager);
            _dbManager.ConnectionClose();
            return i;
        }
        /// <summary>
        /// 获取总数量 定制
        /// </summary>
        /// <param name="sqlparams"></param>
        /// <returns></returns>
        public int Count(SqlParameters sqlparams)
        {
            _dbManager.ConnectionOpen();
            int i = t.count(sqlparams, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }

        public int Max(string pColumn)
        {
            _dbManager.ConnectionOpen();
            int i = t.max(pColumn, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }
        public string Max(SqlParameters sqlparams)
        {
            _dbManager.ConnectionOpen();
            string i = t.max(sqlparams, _dbManager);
            _dbManager.ConnectionClose();
            return i;
        }

        public void AddParameter(string pKey, object pValue)
        {
            _dbManager.AddParameter(pKey, pValue);
        }

        public void AddOutParameter(string pKey, object pValue)
        {
            _dbManager.AddOutParameter(pKey, pValue);
        }

        public DataTable RunProcedure(string pStoredProcName, string pTableName)
        {
            return _dbManager.RunProcedure(pStoredProcName, pTableName);
        }

        public DataTable RunProcedure(string pStoredProcName, string pTableName, out Dictionary<string, string> outPut)
        {
            return _dbManager.RunProcedure(pStoredProcName, pTableName, out outPut);
        }
    }
}
