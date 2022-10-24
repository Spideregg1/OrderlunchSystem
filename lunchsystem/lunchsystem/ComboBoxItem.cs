using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lunchsystem
{
    internal class ComboBoxItem
    {
        // property
        public string Value { get; private set; }

        // field
        private string _valueDemo;
        public string ValueDemo
        {
            get { return _valueDemo; }  
            set 
            { 
                // TODO 防呆
                _valueDemo = value; 
            }
        }

        private string _text;
        public string Text { get { return _text; } }
        public string Text2 => _text;

        // TODO ctor 快捷鍵
        public ComboBoxItem()
        {

        }

        public ComboBoxItem(string value, string text)
        {
            Value = value;
            _text = text;

            // TODO valueDemo防呆\
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class ConstructorDemo
    {

        // TODO 建構子

        //public ConstructorDemo()
        //{

        //}

        public ConstructorDemo(string value, string text)
        {

        }
    }

}
