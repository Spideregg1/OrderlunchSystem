using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lunchsystem
{
    internal class ComboBoxUtil
    {
        //取得下拉式項目
        public static ComboBoxItem GetItem(ComboBox cbo)
        {
            ComboBoxItem item = new ComboBoxItem("", "");
            if (cbo.SelectedIndex > -1)
            {
                item = cbo.Items[cbo.SelectedIndex] as ComboBoxItem;
            }
            return item;
        }
        //取得索引下拉項目
        public static ComboBoxItem GetItem(ComboBox cbo, int index)
        {
            ComboBoxItem item = null;
            if (index > -1)
            {
                item = cbo.Items[index] as ComboBoxItem;
            }
            return item;
        }
    }
}
