using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lunchsystem
{
    internal class ComboBoxItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
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
