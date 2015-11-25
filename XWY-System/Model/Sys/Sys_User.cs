using System;
using System.Collections.Generic;
using BMSP.DBAccesser.DBScript;

namespace Model.Sys
{
    public class Sys_User : DBScript<Sys_User>
    {
        public Sys_User()
        {
            PrimaryKey = "UserId";
        }

        #region 属性
        private int _UserId;
        [EntityMapping(RealNumber = true, PrimaryKey = true)]
        public int UserId
        {
            get { return _UserId; }
            set
            {
                if (this.hash.ContainsKey("UserId"))
                {
                    this.hash["UserId"] = value.ToString();
                }
                else
                {
                    this.hash.Add("UserId", value.ToString());
                }
                _UserId = value;
            }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (this.hash.ContainsKey("UserName"))
                {
                    this.hash["UserName"] = value.ToString();
                }
                else
                {
                    this.hash.Add("UserName", value.ToString());
                }
                _UserName = value;
            }
        }
        private string _UserPassword;
        public string UserPassword
        {
            get { return _UserPassword; }
            set
            {
                if (this.hash.ContainsKey("UserPassword"))
                {
                    this.hash["UserPassword"] = value.ToString();
                }
                else
                {
                    this.hash.Add("UserPassword", value.ToString());
                }
                _UserPassword = value;
            }
        }
        private DateTime _LogininDate;
        [EntityMapping(DateTime = true)]
        public DateTime LogininDate
        {
            get { return _LogininDate; }
            set
            {
                if (this.hash.ContainsKey("LogininDate"))
                {
                    this.hash["LogininDate"] = value.ToString();
                }
                else
                {
                    this.hash.Add("LogininDate", value.ToString());
                }
                _LogininDate = value;
            }
        }
        private DateTime _LoginoutDate;
        [EntityMapping(DateTime = true)]
        public DateTime LoginoutDate
        {
            get { return _LoginoutDate; }
            set
            {
                if (this.hash.ContainsKey("LoginoutDate"))
                {
                    this.hash["LoginoutDate"] = value.ToString();
                }
                else
                {
                    this.hash.Add("LoginoutDate", value.ToString());
                }
                _LoginoutDate = value;
            }
        }
        private int _LoginCount;
        [EntityMapping(RealNumber = true)]
        public int LoginCount
        {
            get { return _LoginCount; }
            set
            {
                if (this.hash.ContainsKey("LoginCount"))
                {
                    this.hash["LoginCount"] = value.ToString();
                }
                else
                {
                    this.hash.Add("LoginCount", value.ToString());
                }
                _LoginCount = value;
            }
        }
        private string _LoginIp;
        public string LoginIp
        {
            get { return _LoginIp; }
            set
            {
                if (this.hash.ContainsKey("LoginIp"))
                {
                    this.hash["LoginIp"] = value.ToString();
                }
                else
                {
                    this.hash.Add("LoginIp", value.ToString());
                }
                _LoginIp = value;
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

