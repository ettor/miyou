using System;
using System.Collections.Generic;
using System.Text;
using BMSP.DBAccesser;

namespace BMSP.DBAccesser.DBScript
{
    public class DBManager:DbHelperSQL
    {
        public DBManager():base()
        {

        }

        public void ConnectionOpen()
        {
           dbHelper.ConnectionOpen();
        }

        public void ConnectionClose()
        {
            dbHelper.ConnectionClose();
        }

        public void BeginTransaction()
        {
            dbHelper.BeginTransaction();
        }

        public void CommitTransaction()
        {
            dbHelper.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            dbHelper.RollBackTransaction();
        }
    }
      
}
