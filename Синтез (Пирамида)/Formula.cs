using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Синтез__Пирамида_
{
    class Formula
    {
        //Входные данные формулы
        private List<string> inData;
        //Выход формулы
        private string outData;
        //Код формулы на Питоне
        private string code;

        public string OutData
        {
            get { return outData; }
            set { outData = value; }
        }
        public List<string> InData
        {
            get { return inData; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public Formula(string formula, string aCode)
        {
            string[] arrayOfElem = formula.Split(' ');
            OutData = arrayOfElem[0];
            inData = new List<string>();
            for (int i = 0; i < int.Parse(arrayOfElem[1]); i++)
            {
                inData.Add(arrayOfElem[i + 2]);
            }
            code = aCode;
        }
    }
}