using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace BMSP.DataMapper
{
    public class DataReaderToEntity
    {
        public static T PopulateFromIDataReader<T>(DataRow dr)
        {
            Type type = typeof(T);
            object dynObj = Activator.CreateInstance(type);

            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                PropertyInfo p = type.GetProperty(dr.Table.Columns[i].ToString());

                if (p != null)
                {
                    if (p.PropertyType.Name == "String")
                    {
                        p.SetValue(dynObj, dr.Table.Rows[0][dr.Table.Columns[i].ToString()].ToString(), null);
                    }
                    else if (p.PropertyType.Name == "Int32")
                    {
                        if (!string.IsNullOrEmpty(dr.Table.Rows[0][dr.Table.Columns[i].ToString()].ToString()))
                            p.SetValue(dynObj, Convert.ToInt32(dr.Table.Rows[0][dr.Table.Columns[i].ToString()].ToString()), null);
                    }
                    else if (p.PropertyType.Name == "DateTime")
                    {
                        if (!string.IsNullOrEmpty(dr.Table.Rows[0][dr.Table.Columns[i].ToString()].ToString()))
                            p.SetValue(dynObj, Convert.ToDateTime(dr.Table.Rows[0][dr.Table.Columns[i].ToString()].ToString()), null);
                    }
                }
            }

            return (T)dynObj;
        }
    }
}
