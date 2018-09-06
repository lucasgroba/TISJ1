
using BusinessLogicLayer;
using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayerWinform
{
    public partial class EmployeeList : Form
    {
        private IBLEmployees _IBL;
        //ServiceEmployee.ServiceEmployeesClient servEmp;
        private int id;
        public EmployeeList()
        {
            InitializeComponent();
            //servEmp = new ServiceEmployee.ServiceEmployeesClient();
            _IBL = new BLEmployees(new DALEmployeesEF());
            this.id = 0;
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
                
                List<Employee> listaEmp = _IBL.GetAllEmployees();
                foreach (Employee emp in listaEmp) {
                    ListViewItem item = new ListViewItem();
                    item.Text = emp.Id.ToString();
                    item.SubItems.Add(emp.Name);
                    item.SubItems.Add(emp.StartDate.ToString());
                    this.ListEmp.Items.Add(item);
                }
        }

        

        

        private void Nuevo_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit nuevo = new EmployeeAddEdit();
            this.Visible = false;
            nuevo.Visible = true;

        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if(this.id != 0)
            {
                EmployeeAddEdit nuevo = new EmployeeAddEdit(_IBL.GetEmployee(this.id));
                this.Visible = false;
                nuevo.Visible = true;
            }
            
        }

        private void ListEmp_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = ListEmp.GetItemAt(0,e.Y);

            if (item != null)
            {
                id = int.Parse(item.Text);
            }
        }
    }
}
