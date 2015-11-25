using System;
using System.Collections.Generic;
using BMSP.DBAccesser.DBScript;

namespace Model.Bill
{
    public class Bill : DBScript<Bill>
    {
        public Bill()
        {
            PrimaryKey = "BillId";
        }

        #region 属性
        private int _BillId;
        [EntityMapping(RealNumber = true, PrimaryKey = true)]
        public int BillId
        {
            get { return _BillId; }
            set
            {
                if (this.hash.ContainsKey("BillId"))
                {
                    this.hash["BillId"] = value.ToString();
                }
                else
                {
                    this.hash.Add("BillId", value.ToString());
                }
                _BillId = value;
            }
        }
        private string _CustomerName;
        public string CustomerName
        {
            get { return _CustomerName; }
            set
            {
                if (this.hash.ContainsKey("CustomerName"))
                {
                    this.hash["CustomerName"] = value.ToString();
                }
                else
                {
                    this.hash.Add("CustomerName", value.ToString());
                }
                _CustomerName = value;
            }
        }
        private string _CustomerTel;
        public string CustomerTel
        {
            get { return _CustomerTel; }
            set
            {
                if (this.hash.ContainsKey("CustomerTel"))
                {
                    this.hash["CustomerTel"] = value.ToString();
                }
                else
                {
                    this.hash.Add("CustomerTel", value.ToString());
                }
                _CustomerTel = value;
            }
        }
        private string _CustomerAddress;
        public string CustomerAddress
        {
            get { return _CustomerAddress; }
            set
            {
                if (this.hash.ContainsKey("CustomerAddress"))
                {
                    this.hash["CustomerAddress"] = value.ToString();
                }
                else
                {
                    this.hash.Add("CustomerAddress", value.ToString());
                }
                _CustomerAddress = value;
            }
        }
        private string _ProductId;
        public string ProductId
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
        private string _Quantity;
        public string Quantity
        {
            get { return _Quantity; }
            set
            {
                if (this.hash.ContainsKey("Quantity"))
                {
                    this.hash["Quantity"] = value.ToString();
                }
                else
                {
                    this.hash.Add("Quantity", value.ToString());
                }
                _Quantity = value;
            }
        }
        private string _TotalPrice;
        public string TotalPrice
        {
            get { return _TotalPrice; }
            set
            {
                if (this.hash.ContainsKey("TotalPrice"))
                {
                    this.hash["TotalPrice"] = value.ToString();
                }
                else
                {
                    this.hash.Add("TotalPrice", value.ToString());
                }
                _TotalPrice = value;
            }
        }
        private string _AgentId;
        public string AgentId
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
        private string _ExpressNo;
        public string ExpressNo
        {
            get { return _ExpressNo; }
            set
            {
                if (this.hash.ContainsKey("ExpressNo"))
                {
                    this.hash["ExpressNo"] = value.ToString();
                }
                else
                {
                    this.hash.Add("ExpressNo", value.ToString());
                }
                _ExpressNo = value;
            }
        }
        private string _BillDate;
        public string BillDate
        {
            get { return _BillDate; }
            set
            {
                if (this.hash.ContainsKey("BillDate"))
                {
                    this.hash["BillDate"] = value.ToString();
                }
                else
                {
                    this.hash.Add("BillDate", value.ToString());
                }
                _BillDate = value;
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

        private string _Source;
        public string Source
        {
            get { return _Source; }
            set
            {
                if (this.hash.ContainsKey("Source"))
                {
                    this.hash["Source"] = value.ToString();
                }
                else
                {
                    this.hash.Add("Source", value.ToString());
                }
                _Source = value;
            }
        }

        private string _OrderedStatus;
        public string OrderedStatus
        {
            get { return _OrderedStatus; }
            set
            {
                if (this.hash.ContainsKey("OrderedStatus"))
                {
                    this.hash["OrderedStatus"] = value.ToString();
                }
                else
                {
                    this.hash.Add("OrderedStatus", value.ToString());
                }
                _OrderedStatus = value;
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

