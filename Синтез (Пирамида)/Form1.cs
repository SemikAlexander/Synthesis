using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Синтез__Пирамида_
{
    public partial class Form1 : Form
    {
        KnowledgeBase knowledgeBase;
        List<string> x = new List<string>();
        List<string> y = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = System.IO.Path.GetFullPath("Pictures/Прямоугольная пирамида.png");
            pictureBox1.Image = new Bitmap(filePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] fileLines = System.IO.File.ReadAllLines("knowledgeBase.txt");
            KnowledgeBase.elements = new Dictionary<string, string>(); int i = 1;
            for (i = 0; i < int.Parse(fileLines[0]) + 1; i++)
            {
                string[] names = fileLines[i].Split(' ');
                KnowledgeBase.elements.Add(names[0], fileLines[i].Substring(fileLines[i].IndexOf(' ') + 1));
            }
            i++;
            KnowledgeBase.model = new List<Formula>(); for (; i < fileLines.Length; i = i + 3)
            {
                KnowledgeBase.model.Add(new Formula(fileLines[i], fileLines[i + 1]));
            }
            knowledgeBase = new KnowledgeBase(x, y); knowledgeBase.findAlgorithm();
        }

        private void HInput_CheckedChanged(object sender, EventArgs e)
        {
            if (HInput.Checked) 
                x.Add("H");
            else
                x.Remove("H");
        }

        private void RibInput_CheckedChanged(object sender, EventArgs e)
        {
            if (RibInput.Checked)
                x.Add("B");
            else
                x.Remove("B");
        }

        private void FaceInput_CheckedChanged(object sender, EventArgs e)
        {
            if (FaceInput.Checked)
                x.Add("A");
            else
                x.Remove("A");
        }

        private void ApofemaInput_CheckedChanged(object sender, EventArgs e)
        {
            if (ApofemaInput.Checked)
                x.Add("C");
            else
                x.Remove("C");
        }

        private void SsideInput_CheckedChanged(object sender, EventArgs e)
        {
            if (SsideInput.Checked)
                x.Add("Ss");
            else
                x.Remove("Ss");
        }

        private void BaseAreaInput_CheckedChanged(object sender, EventArgs e)
        {
            if (BaseAreaInput.Checked)
                x.Add("Sb");
            else
                x.Remove("Sb");
        }

        private void VInput_CheckedChanged(object sender, EventArgs e)
        {
            if (VInput.Checked)
                x.Add("V");
            else
                x.Remove("V");
        }

        private void HOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (HOutput.Checked)
                y.Add("H");
            else
                y.Remove("H");
        }

        private void RibOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (RibOutput.Checked)
                y.Add("B");
            else
                y.Remove("B");
        }

        private void FaceOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (FaceOutput.Checked)
                y.Add("A");
            else
                y.Remove("A");
        }

        private void ApofemaOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (ApofemaOutput.Checked)
                y.Add("C");
            else
                y.Remove("C");
        }

        private void SsideOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (SsideOutput.Checked)
                y.Add("Ss");
            else
                y.Remove("Ss");
        }

        private void BaseAreaOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (BaseAreaOutput.Checked)
                y.Add("Sb");
            else
                y.Remove("Sb");
        }

        private void VOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (VOutput.Checked)
                y.Add("V");
            else
                y.Remove("V");
        }
    }
}