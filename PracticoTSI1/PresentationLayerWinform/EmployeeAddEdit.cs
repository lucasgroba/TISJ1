
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
    public partial class EmployeeAddEdit : Form
    {
        //ServiceEmployee.ServiceEmployeesClient servEmp;
        private IBLEmployees _IBL;
        private FullTimeEmployee full;
        private PartTimeEmployee part;
        private Boolean edit;

        public EmployeeAddEdit(Employee emp)
        {
            InitializeComponent();
            //servEmp = new ServiceEmployee.ServiceEmployeesClient();
            this.CantHoras.Visible = false;
            this.edit = true;

            if (emp != null)
            {
                if (emp is PartTimeEmployee)
                {
                    part = (PartTimeEmployee)emp;
                    this.LoadTextPart(part);
                    this.CantHoras.Visible = true;
                }
                else
                {
                    full= (FullTimeEmployee)emp;
                    this.LoadTextFull(full);
                    this.CantHoras.Visible = false;
                }
            }
            _IBL = new BLEmployees(new DALEmployeesEF());
        }
        public EmployeeAddEdit()
        {
            InitializeComponent();
            //servEmp = new ServiceEmployee.ServiceEmployeesClient();
            this.CantHoras.Visible = false;

            _IBL = new BLEmployees(new DALEmployeesEF());
        }


        private void LoadTextFull(FullTimeEmployee full)
        {
            IsFullTime.Checked = true;
            Cedula.Text = full.Id.ToString();
            Nombre.Text = full.Name;
            FechaIng.Value = full.StartDate;
            Salario.Text = full.Salary.ToString();

        }

        private void LoadTextPart(PartTimeEmployee full)
        {
            isPartTime.Checked = true;
            Cedula.Text = full.Id.ToString();
            Nombre.Text = full.Name;
            FechaIng.Value = full.StartDate;
            this.CantHoras.Text = full.HourlyRate.ToString();

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }

        private void isPartTime_CheckedChanged(object sender, EventArgs e)
        {
            if (isPartTime.Checked == true)
            {
                this.CantHoras.Visible = true;
            }
            else {
                this.CantHoras.Visible = false;
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (this.Cedula != null && this.Nombre != null && FechaIng != null) {
                if (this.isPartTime.Checked = true && this.IsFullTime.Checked != true) {
                    PartTimeEmployee nuevo = new PartTimeEmployee();
                    nuevo.Id = int.Parse(this.Cedula.Text);
                    nuevo.Name = this.Nombre.Text;
                    nuevo.StartDate = this.FechaIng.Value;
                    nuevo.HourlyRate = int.Parse(CantHoras.Text);
                    if (edit) {
                        _IBL.UpdateEmployee(nuevo);
                        //servEmp.UpdateEmployee(nuevo);
                        EmployeeList ventana = new EmployeeList();
                        ventana.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        //servEmp.AddEmployee(nuevo);
                        _IBL.AddEmployee(nuevo);
                        EmployeeList ventana = new EmployeeList();
                        ventana.Visible = true;
                        this.Visible = false;
                    }
                    this.Cedula.Text = "";
                    this.Nombre.Text = "";
                    this.Salario.Text = "";
                    this.CantHoras.Text = "";
                    this.isPartTime.Checked = false;

                }
                else
                {
                    if (this.isPartTime.Checked != true && this.IsFullTime.Checked == true) {
                        FullTimeEmployee nuevo = new FullTimeEmployee();
                        nuevo.Id = int.Parse(this.Cedula.Text);
                        nuevo.Name = this.Nombre.Text;
                        nuevo.StartDate = this.FechaIng.Value;
                        nuevo.Salary = int.Parse(Salario.Text);
                        if (edit)
                        {
                            //servEmp.UpdateEmployee(nuevo);
                            _IBL.UpdateEmployee(nuevo);
                            EmployeeList ventana = new EmployeeList();
                            ventana.Visible = true;
                            this.Visible = false;
                        }
                        else
                        {
                            //servEmp.AddEmployee(nuevo);
                            _IBL.AddEmployee(nuevo);
                            EmployeeList ventana = new EmployeeList();
                            ventana.Visible = true;
                            this.Visible = false;
                        }
                        this.Cedula.Text = "";
                        this.Nombre.Text = "";
                        this.Salario.Text = "";
                        this.CantHoras.Text = "";
                        this.IsFullTime.Checked = false;
                    }
                }
            }
        }

        
    }
}
