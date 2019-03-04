using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Синтез__Пирамида_
{
    class KnowledgeBase
    {
        //Все элементы цилиндра
        static public Dictionary<string, string> elements; //Вычислительная модель цилиндра
        static public List<Formula> model;
        //Входные данные
        private List<string> x;
        //Выходные данные
        private List<string> y;
        //Переменные, найденные в текущий момент
        private List<string> w;
        //Синтезированный алгоритм
        private List<Formula> algorithm;
        //Листинг на паскале
        public List<string> listing;
        public KnowledgeBase(List<string> aX, List<string> aY)
        {
            x = new List<string>(aX);
            y = new List<string>(aY);
        }

        public bool AlgIsFound()
        {
            foreach (string elem in y)
            {
                if (!w.Contains(elem))
                    return false;
            }
            return true;
        }
        //Генерация листинга на Питоне
        public void genListing()
        {
            listing = new List<string>();
            listing.Add("from math import *");
            foreach (string elem in x)
            {
                listing.Add("while True:");
                listing.Add("   print(\"Введите " + elements[elem] + ": \" )");
                listing.Add("   " + elem + "=input()");
                listing.Add("   " + "try:");
                listing.Add("       " + elem + "=int(" + elem + ")");
                listing.Add("       " + "if " + elem + "<=0:");
                listing.Add("           " + "print (\"Ошибка данных\")");
                listing.Add("       " + "else:");
                listing.Add("           " + "break");
                listing.Add("   " + "except (TypeError, ValueError):");
                listing.Add("       " + "print (\"Ошибка данных\")");
            }
            foreach (Formula elem in algorithm)
            {
                listing.Add(elem.Code);
            }
            foreach (string elem in y)
            {
                listing.Add("print(\"" + elements[elem] + " = \", " + elem + ")");
            }
        }


        //Найти синтезированный алгоритм
        public void findAlgorithm()
        {
            string applicationPath = Application.StartupPath; algorithm = new List<Formula>(); w = new List<string>(x);
            Formula formula = FindFormula();
            while (!AlgIsFound() && formula != null)
            {
                algorithm.Add(formula);
                w.Add(formula.OutData);
                formula = FindFormula();
            }
            //Если решения нет
            if (!AlgIsFound())
            {
                DialogResult res = MessageBox.Show("К сожалению, получить результат невозможно. Выберите другие входные данные", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                genListing();
                System.IO.File.WriteAllLines(@"pyramid.py", listing.ToArray());
                System.Diagnostics.Process.Start("cmd.exe", applicationPath + @"\pyramid.py").WaitForExit();
            }
        }
        //Найти формулу для алгоритма
        public Formula FindFormula()
        {
            //Перебор формул вычислительной модели 
            foreach (Formula formula in model)
            {
                bool flag = true;
                //Перебор входных данных формулы с проверкой вхождения всех входных данных в множество w
                foreach (string elem in formula.InData)
                    if (!w.Contains(elem))
                        flag = false;
                //Проверка не вхождения выхода формулы в множество w
                if (!w.Contains(formula.OutData) && flag)
                    return formula;
            }
            return null;
        }
    }
}