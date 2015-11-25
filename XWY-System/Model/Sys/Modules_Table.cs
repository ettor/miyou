using System;
using System.Collections.Generic;
using BMSP.DBAccesser.DBScript;

namespace Model.Sys
{
    public class Modules_Table : DBScript<Modules_Table>
    {
        public Modules_Table()
        {
            PrimaryKey = "M_ID";
        }

        #region 属性
        private int _M_ID;
        [EntityMapping(RealNumber = true,PrimaryKey = true)]
        public int M_ID
        {
            get { return _M_ID; }
            set
            {
                if (this.hash.ContainsKey("M_ID"))
                {
                    this.hash["M_ID"] = value.ToString();
                }
                else
                {
                    this.hash.Add("M_ID", value.ToString());
                }
                _M_ID = value;
            }
        }
        private string _M_NAME;
        public string M_NAME
        {
            get { return _M_NAME; }
            set
            {
                if (this.hash.ContainsKey("M_NAME"))
                {
                    this.hash["M_NAME"] = value.ToString();
                }
                else
                {
                    this.hash.Add("M_NAME", value.ToString());
                }
                _M_NAME = value;
            }
        }
        private string _M_LINK;
        public string M_LINK
        {
            get { return _M_LINK; }
            set
            {
                if (this.hash.ContainsKey("M_LINK"))
                {
                    this.hash["M_LINK"] = value.ToString();
                }
                else
                {
                    this.hash.Add("M_LINK", value.ToString());
                }
                _M_LINK = value;
            }
        }
        private string _M_ICON;
        public string M_ICON
        {
            get { return _M_ICON; }
            set
            {
                if (this.hash.ContainsKey("M_ICON"))
                {
                    this.hash["M_ICON"] = value.ToString();
                }
                else
                {
                    this.hash.Add("M_ICON", value.ToString());
                }
                _M_ICON = value;
            }
        }
        private int _M_PID;
        [EntityMapping(RealNumber = true)]
        public int M_PID
        {
            get { return _M_PID; }
            set
            {
                if (this.hash.ContainsKey("M_PID"))
                {
                    this.hash["M_PID"] = value.ToString();
                }
                else
                {
                    this.hash.Add("M_PID", value.ToString());
                }
                _M_PID = value;
            }
        }
        private int _M_PX;
        [EntityMapping(RealNumber = true)]
        public int M_PX
        {
            get { return _M_PX; }
            set
            {
                if (this.hash.ContainsKey("M_PX"))
                {
                    this.hash["M_PX"] = value.ToString();
                }
                else
                {
                    this.hash.Add("M_PX", value.ToString());
                }
                _M_PX = value;
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

