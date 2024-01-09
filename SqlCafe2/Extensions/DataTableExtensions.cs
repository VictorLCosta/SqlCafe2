using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace SqlCafe2.Extensions
{
    public static class DataTableExtensions
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> list = new();

            return list;
        }

        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new();
            for(int i = 0 ; i < props.Count ; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];

            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static DataTable DistinctBy(this DataTable sourceTable, string fieldName)
        {
            return DistinctBy(sourceTable, fieldName, string.Empty);
        }

        public static DataTable DistinctBy(this DataTable sourceTable, string fieldNames, string filter)
        {
            DataTable dt = new();
            string[] arrFieldNames = fieldNames.Replace(" ", "").Split(',');
            foreach (string s in arrFieldNames)
            {
                if (sourceTable.Columns.Contains(s))
                    dt.Columns.Add(s, sourceTable.Columns[s].DataType);
                else
                    throw new Exception(string.Format("The column {0} does not exist.", s));
            }

            object[]? lastValues = null;
            foreach (DataRow dr in sourceTable.Select(filter, fieldNames))
            {
                object[] newValues = GetRowFields(dr, arrFieldNames);
                if (lastValues == null || !ObjectComparison(lastValues, newValues))
                {
                    lastValues = newValues;
                    dt.Rows.Add(lastValues);
                }
            }

            return dt;
        }

        public static void RenameColumn(this DataTable dt, string oldName, string newName)
        {
            if (dt != null && !string.IsNullOrEmpty(oldName) && !string.IsNullOrEmpty(newName) && oldName != newName)
            {
                int idx = dt.Columns.IndexOf(oldName);
                dt.Columns[idx].ColumnName = newName;
                dt.AcceptChanges();
            }
        }

        public static void RemoveColumn(this DataTable dt, string columnName)
        {
            if (dt != null && !string.IsNullOrEmpty(columnName) && dt.Columns.IndexOf(columnName) >= 0)
            {
                int idx = dt.Columns.IndexOf(columnName);
                dt.Columns.RemoveAt(idx);
                dt.AcceptChanges();
            }
        }


        #region Private Methods

        private static object[] GetRowFields(DataRow dr, string[] arrFieldNames)
        {
            if (arrFieldNames.Length == 1)
                return new object[] { dr[arrFieldNames[0]] };
            else
            {
                ArrayList itemArray = new();
                foreach (string field in arrFieldNames)
                    itemArray.Add(dr[field]);

                return itemArray.ToArray();
            }
        }

        /// <summary>
        /// Compares two values to see if they are equal. Also compares DBNULL.Value.
        /// </summary>
        /// <param name="A">Object A</param>
        /// <param name="B">Object B</param>
        /// <returns></returns>
        private static bool ObjectComparison(object a, object b)
        {
            if (a == DBNull.Value && b == DBNull.Value) //  both are DBNull.Value
                return true;
            if (a == DBNull.Value || b == DBNull.Value) //  only one is DBNull.Value
                return false;
            return a.Equals(b);  // value type standard comparison
        }

        /// <summary>
        /// Compares two value arrays to see if they are equal. Also compares DBNULL.Value.
        /// </summary>
        /// <param name="A">Object Array A</param>
        /// <param name="B">Object Array B</param>
        /// <returns></returns>
        private static bool ObjectComparison(object[] a, object[] b)
        {
            bool retValue = true;
            if (a.Length == b.Length)
                for (int i = 0; i < a.Length; i++)
                {
                    bool singleCheck;
                    if (!(singleCheck = ObjectComparison(a[i], b[i])))
                    {
                        retValue = false;
                        break;
                    }
                    retValue = retValue && singleCheck;
                }

            return retValue;
        }
        
        #endregion

    }
}