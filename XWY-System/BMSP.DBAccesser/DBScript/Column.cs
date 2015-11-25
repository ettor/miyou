using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    ///功能说明:   表字段属性类 
    ///创建人:     Bano
    ///最后更新:   2009/09/17 
    ///创建时间:   2009/09/17     
    /// </summary>
    public class Column
    {
        private string _Code;
        private string _DataType;
        private bool _IsID;
        private int _Length;
        private string _Name;
        private string _Primary;
        private string _EntityMapping;

        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }

        public string DataType
        {
            get
            {
                return this._DataType;
            }
            set
            {
                this._DataType = value;
            }
        }

        public bool IsID
        {
            get
            {
                return this._IsID;
            }
            set
            {
                this._IsID = value;
            }
        }

        public int Length
        {
            get
            {
                return this._Length;
            }
            set
            {
                this._Length = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public string Primary
        {
            get
            {
                return this._Primary;
            }
            set
            {
                this._Primary = value;
            }
        }

        public string EntityMapping
        {
            get { return _EntityMapping; }
            set { _EntityMapping = value; }
        }
    }
}
