using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    public class SqlParameters
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _limit;
        public int limit
        {
            get{ return _limit;}
            set{ _limit=value;}
        }

        private string _select = "*";
        public string select
        {
            get { return _select; }
            set { _select = value; }
        }
        private string _joins;
        public string joins
        {
            get { return _joins; }
            set { _joins = value; }
        }
        private string _conditions;
        public string conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }
        private string _order;
        public string order
        {
            get { return _order; }
            set { _order = value; }
        }
        private string _pk;
        public string pk
        {
            get { return _pk; }
            set { _pk = value; }
        }

        private string _sql;
        public string sql
        {
            get { return _pk; }
            set { _pk = value; }
        }
      
    }
}
