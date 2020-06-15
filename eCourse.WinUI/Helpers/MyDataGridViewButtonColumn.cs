using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Helpers
{
    public class MyDataGridViewButtonColumn : DataGridViewButtonColumn
    {
        public MyDataGridViewButtonColumn()
        {
            this.CellTemplate = new MyDataGridViewButtonCell();
        }
    }
}
