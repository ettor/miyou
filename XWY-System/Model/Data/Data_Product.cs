using System;
using System.Collections.Generic;
using BMSP.DBAccesser.DBScript;

namespace Model.Data
{
    public class Data_Product : DBScript<Data_Product>
    {
        public Data_Product()
        {
            PrimaryKey = "ProductId";
        }

        #region 属性
        private int _ProductId;
        [EntityMapping(RealNumber = true, PrimaryKey = true)]
        public int ProductId
        {
            get { return _ProductId; }
            set
            {
                if (this.hash.ContainsKey("ProductId"))
                {
                    this.hash["ProductId"] = value.ToString();
                }
                else
                {
                    this.hash.Add("ProductId", value.ToString());
                }
                _ProductId = value;
            }
        }
        private string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                if (this.hash.ContainsKey("ProductName"))
                {
                    this.hash["ProductName"] = value.ToString();
                }
                else
                {
                    this.hash.Add("ProductName", value.ToString());
                }
                _ProductName = value;
            }
        }
        private string _SupplierName;
        public string SupplierName
        {
            get { return _SupplierName; }
            set
            {
                if (this.hash.ContainsKey("SupplierName"))
                {
                    this.hash["SupplierName"] = value.ToString();
                }
                else
                {
                    this.hash.Add("SupplierName", value.ToString());
                }
                _SupplierName = value;
            }
        }
        private string _SupplierTel;
        public string SupplierTel
        {
            get { return _SupplierTel; }
            set
            {
                if (this.hash.ContainsKey("SupplierTel"))
                {
                    this.hash["SupplierTel"] = value.ToString();
                }
                else
                {
                    this.hash.Add("SupplierTel", value.ToString());
                }
                _SupplierTel = value;
            }
        }
        private string _Spec;
        public string Spec
        {
            get { return _Spec; }
            set
            {
                if (this.hash.ContainsKey("Spec"))
                {
                    this.hash["Spec"] = value.ToString();
                }
                else
                {
                    this.hash.Add("Spec", value.ToString());
                }
                _Spec = value;
            }
        }
        private string _BuyPrice;
        public string BuyPrice
        {
            get { return _BuyPrice; }
            set
            {
                if (this.hash.ContainsKey("BuyPrice"))
                {
                    this.hash["BuyPrice"] = value.ToString();
                }
                else
                {
                    this.hash.Add("BuyPrice", value.ToString());
                }
                _BuyPrice = value;
            }
        }
        private string _AgentPrice;
        public string AgentPrice
        {
            get { return _AgentPrice; }
            set
            {
                if (this.hash.ContainsKey("AgentPrice"))
                {
                    this.hash["AgentPrice"] = value.ToString();
                }
                else
                {
                    this.hash.Add("AgentPrice", value.ToString());
                }
                _AgentPrice = value;
            }
        }
        private string _SalePrice;
        public string SalePrice
        {
            get { return _SalePrice; }
            set
            {
                if (this.hash.ContainsKey("SalePrice"))
                {
                    this.hash["SalePrice"] = value.ToString();
                }
                else
                {
                    this.hash.Add("SalePrice", value.ToString());
                }
                _SalePrice = value;
            }
        }
        private string _ProductMemo;
        public string ProductMemo
        {
            get { return _ProductMemo; }
            set
            {
                if (this.hash.ContainsKey("ProductMemo"))
                {
                    this.hash["ProductMemo"] = value.ToString();
                }
                else
                {
                    this.hash.Add("ProductMemo", value.ToString());
                }
                _ProductMemo = value;
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
        private string _IsHot;
        public string IsHot
        {
            get { return _IsHot; }
            set
            {
                if (this.hash.ContainsKey("IsHot"))
                {
                    this.hash["IsHot"] = value.ToString();
                }
                else
                {
                    this.hash.Add("IsHot", value.ToString());
                }
                _IsHot = value;
            }
        }

        private string _SortNo;
        public string SortNo
        {
            get { return _SortNo; }
            set
            {
                if (this.hash.ContainsKey("SortNo"))
                {
                    this.hash["SortNo"] = value.ToString();
                }
                else
                {
                    this.hash.Add("SortNo", value.ToString());
                }
                _SortNo = value;
            }
        }

        private string _IsAgent;
        public string IsAgent
        {
            get { return _IsAgent; }
            set
            {
                if (this.hash.ContainsKey("IsAgent"))
                {
                    this.hash["IsAgent"] = value.ToString();
                }
                else
                {
                    this.hash.Add("IsAgent", value.ToString());
                }
                _IsAgent = value;
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

