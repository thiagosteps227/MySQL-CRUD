using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_CRUD
{
    public partial class FormStudentInfo : Form
    {
        public FormStudentInfo()
        {
            InitializeComponent();
        }

        public void Display()
        {
            DbStudent.DisplayAndSearch("SELECT ID, Name, Reg, Class, Section FROM student_table", dataGridView1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormStudent form = new FormStudent(this);
            form.ShowDialog();

        }

        private void FormStudentInfo_Shown(object sender, EventArgs e)
        {
            Display();
        }
    }

    
}
