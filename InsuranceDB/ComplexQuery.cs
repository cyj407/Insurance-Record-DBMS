using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsuranceDB
{
    public partial class ComplexQuery : Form
    {
        DataTransfer dataTransfer;
        private String query = "";

        public ComplexQuery(DataTransfer del)
        {
            InitializeComponent();
        }
        

        private void ComplexQuery_Load(object sender, EventArgs e)
        {

        }
        
        private void btnEnter_Click(object sender, EventArgs e)
        {
            // transfer data back to MainWindow
            if(query != "")
            {
                dataTransfer.Invoke(query);
            }
            Close();
        }

        private void rbMax_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMax.Checked == false)
            {
                return;
            }

            Console.WriteLine("MAX");
        }

        private void rbMin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMin.Checked == false)
            {
                return;
            }

            Console.WriteLine("MIN");

        }

        private void rbAvg_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAvg.Checked == false)
            {
                return;
            }

            Console.WriteLine("AVG");
        }

        private void rbSum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSum.Checked == false)
            {
                return;
            }

            Console.WriteLine("SUM");
        }

        private void rbCnt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCnt.Checked == false)
            {
                return;
            }

            Console.WriteLine("COUNT");
        }
    }
}
