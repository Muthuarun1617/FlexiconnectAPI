using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Common
{
    public static class ConvertToDataTable
    {
        public static DataTable ToStringListTable(List<string> items)
        {
            var table = new DataTable();
            table.Columns.Add("Value", typeof(string));

            foreach (var item in items ?? new List<string>())
            {
                table.Rows.Add(item);
            }

            return table;
        }
    }
}
