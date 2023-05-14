using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Helpers
{
    public static class DataGridHelper
    {
        public static object GetCellValue(SfDataGrid sfDataGrid, int recordIndex, int columnindex)
        {
            object cellValue = null;

            var record1 = sfDataGrid.View.Records.GetItemAt(recordIndex);
            var mappingName = sfDataGrid.Columns[columnindex].MappingName;
            cellValue = record1.GetType().GetProperty(mappingName).GetValue(record1, null);
            if (cellValue != null)
            {
                return cellValue;
            }
            return null;
        }

    }

}
