using System;
using System.Collections.Generic;
using BMSP.DBAccesser.DBScript;

namespace Model.Data
{
    public class Data_Agent : DBScript<Data_Agent>
    {
        public Data_Agent()
        {
            PrimaryKey = "AgentId";
        }

        #region 属性
        private int _AgentId;
        [EntityMapping(RealNumber = true, PrimaryKey = true)]
        public int AgentId
        {
            get { return _AgentId; }
            set
            {
                if (this.hash.ContainsKey("AgentId"))
                {
                    this.hash["AgentId"] = value.ToString();
                }
                else
                {
                    this.hash.Add("AgentId", value.ToString());
                }
                _AgentId = value;
            }
        }
        private string _AgentName;
        public string AgentName
        {
            get { return _AgentName; }
            set
            {
                if (this.hash.ContainsKey("AgentName"))
                {
                    this.hash["AgentName"] = value.ToString();
                }
                else
                {
                    this.hash.Add("AgentName", value.ToString());
                }
                _AgentName = value;
            }
        }
        private string _AgentTel;
        public string AgentTel
        {
            get { return _AgentTel; }
            set
            {
                if (this.hash.ContainsKey("AgentTel"))
                {
                    this.hash["AgentTel"] = value.ToString();
                }
                else
                {
                    this.hash.Add("AgentTel", value.ToString());
                }
                _AgentTel = value;
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
        private string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if (this.hash.ContainsKey("Status"))
                {
                    this.hash["Status"] = value.ToString();
                }
                else
                {
                    this.hash.Add("Status", value.ToString());
                }
                _Status = value;
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
        private string _InsertT;
        public string InsertT
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
        private string _UpdateP;
        public string UpdateP
        {
            get { return _UpdateP; }
            set
            {
                if (this.hash.ContainsKey("UpdateP"))
                {
                    this.hash["UpdateP"] = value.ToString();
                }
                else
                {
                    this.hash.Add("UpdateP", value.ToString());
                }
                _UpdateP = value;
            }
        }
        private string _UpdateT;
        public string UpdateT
        {
            get { return _UpdateT; }
            set
            {
                if (this.hash.ContainsKey("UpdateT"))
                {
                    this.hash["UpdateT"] = value.ToString();
                }
                else
                {
                    this.hash.Add("UpdateT", value.ToString());
                }
                _UpdateT = value;
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

