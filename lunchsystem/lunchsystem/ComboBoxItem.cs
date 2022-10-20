using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lunchsystem
{
    internal class ComboBoxItem
    {
        // TODO 20221017：請說明為何採用建構子傳入參數，然後 Property 有要開放 set 給外部設定
        public string Value;
        public string Text;
        public ComboBoxItem(string value, string text)
        {
            Value = value;
            Text = text;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
