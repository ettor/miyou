using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    public class EntityMappingAttribute : Attribute
    {

        private string _tableName = string.Empty;
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        private bool _primaryKey = false;
        public bool PrimaryKey
        {
            get
            {
                return _primaryKey;
            }
            set
            {
                _primaryKey = value;
            }
        }

        private bool _realNumber = false;
        public bool RealNumber
        {
            get
            {
                return _realNumber;
            }
            set
            {
                _realNumber = value;
            }
        }
        private bool _SysString = false;
        public bool SysString
        {
            get
            {
                return _SysString;
            }
            set
            {
                _SysString = value;
            }
        }


        private bool _isField = true;
        public bool IsField
        {
            get
            {
                return _isField;
            }
            set
            {
                _isField = value;
            }
        }

        private string _fieldName = string.Empty;
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }

        private Type _fieldType = typeof(object);
        public Type FieldType
        {
            get
            {
                return _fieldType;
            }
            set
            {
                _fieldType = value;
            }
        }

        private string _defaultValue = string.Empty;
        public string DefaultValue
        {
            get
            {
                return _defaultValue;
            }
            set
            {
                _defaultValue = value;
            }
        }

        private bool _dateTime = false;
        public bool DateTime
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
            }
        }
    }
}
