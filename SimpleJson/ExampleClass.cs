using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJson
{
    public class ExampleClass
    {
        private int _exampleInt;
        private string _exampleString;
        private char _exampleChar;
        public ExampleClass(int exampleInt, string exampleString, char exampleChar)
        {
            _exampleInt = exampleInt;
            _exampleString = exampleString;
            _exampleChar = exampleChar;
        }
        public ExampleClass()
        {

        }
        public int ExampleInt { get; set; }
        public string ExampleString { get; set; }
        public char ExampleChar { get; set; }

    }
}
