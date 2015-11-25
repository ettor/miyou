using System;
using System.Collections.Generic;
using BMSP.DBAccesser.DBScript;

namespace Model.Data
{
    public class Sys_Memo
    {
        #region 属性
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (this.hash.ContainsKey("Id"))
                {
                    this.hash["Id"] = value.ToString();
                }
                else
                {
                    this.hash.Add("Id", value.ToString());
                }
                _Id = value;
            }
        }
        private string _Memo;
        public string Memo
        {
            get { return _Memo; }
            set
            {
                if (this.hash.ContainsKey("Memo"))
                {
                    this.hash["Memo"] = value.ToString();
                }
                else
                {
                    this.hash.Add("Memo", value.ToString());
                }
                _Memo = value;
            }
        }
        private string _InsertP;
        public string InsertP
        {
            get { return _InsertP; }
            set
            {
                if (this.hash.ContainsKey("InsertP"))
                {
                    this.hash["InsertP"] = value.ToString();
                }
                else
                {
                    this.hash.Add("InsertP", value.ToString());
                }
                _InsertP = value;
            }
        }
        private DateTime _InsertT;
        public DateTime InsertT
        {
            get { return _InsertT; }
            set
            {
                if (this.hash.ContainsKey("InsertT"))
                {
                    this.hash["InsertT"] = value.ToString();
                }
                else
                {
                    this.hash.Add("InsertT", value.ToString());
                }
                _InsertT = value;
            }
        }
        private Dictionary<string, string> _hash = new Dictionary<string, string>();
        public Dictionary<string, string> hash
        {
            get
            {
                return _hash;
            }
            set
            {
                _hash = value;
            }
        }
        #endregion
    }
}

