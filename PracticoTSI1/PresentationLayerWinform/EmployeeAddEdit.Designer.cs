using System;

namespace PresentationLayerWinform
{
    partial class EmployeeAddEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Guardar = new System.Windows.Forms.Button();
            this.isPartTime = new System.Windows.Forms.CheckBox();
            this.IsFullTime = new System.Windows.Forms.CheckBox();
            this.titulo = new System.Windows.Forms.Label();
            this.Cedula = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.FechaIng = new System.Windows.Forms.DateTimePicker();
            this.Salario = new System.Windows.Forms.TextBox();
            this.CantHoras = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(104, 241);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(157, 25);
            this.Guardar.TabIndex = 0;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // isPartTime
            // 
            this.isPartTime.AutoSize = true;
            this.isPartTime.Location = new System.Drawing.Point(123, 167);
            this.isPartTime.Name = "isPartTime";
            this.isPartTime.Size = new System.Drawing.Size(71, 17);
            this.isPartTime.TabIndex = 1;
            this.isPartTime.Text = "Part-Time";
            this.isPartTime.UseVisualStyleBackColor = true;
            this.isPartTime.CheckedChanged += new System.EventHandler(this.isPartTime_CheckedChanged);
            // 
            // IsFullTime
            // 
            this.IsFullTime.AutoSize = true;
            this.IsFullTime.Location = new System.Drawing.Point(193, 167);
            this.IsFullTime.Name = "IsFullTime";
            this.IsFullTime.Size = new System.Drawing.Size(68, 17);
            this.IsFullTime.TabIndex = 2;
            this.IsFullTime.Text = "Full-Time";
            this.IsFullTime.UseVisualStyleBackColor = true;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.titulo.Location = new System.Drawing.Point(102, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(159, 24);
            this.titulo.TabIndex = 3;
            this.titulo.Text = "Alta Empleados";
            this.titulo.Click += new System.EventHandler(this.titulo_Click);
            // 
            // Cedula
            // 
            this.Cedula.Location = new System.Drawing.Point(123, 53);
            this.Cedula.Name = "Cedula";
            this.Cedula.Size = new System.Drawing.Size(100, 20);
            this.Cedula.TabIndex = 4;
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(123, 79);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 20);
            this.Nombre.TabIndex = 5;
            // 
            // FechaIng
            // 
            this.FechaIng.Location = new System.Drawing.Point(124, 109);
            this.FechaIng.Name = "FechaIng";
            this.FechaIng.Size = new System.Drawing.Size(99, 20);
            this.FechaIng.TabIndex = 6;
            // 
            // Salario
            // 
            this.Salario.Location = new System.Drawing.Point(124, 141);
            this.Salario.Name = "Salario";
            this.Salario.Size = new System.Drawing.Size(99, 20);
            this.Salario.TabIndex = 7;
            // 
            // CantHoras
            // 
            this.CantHoras.Location = new System.Drawing.Point(123, 193);
            this.CantHoras.Name = "CantHoras";
            this.CantHoras.Size = new System.Drawing.Size(99, 20);
            this.CantHoras.TabIndex = 8;
            // 
            // EmployeeAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(412, 311);
            this.Controls.Add(this.CantHoras);
            this.Controls.Add(this.Salario);
            this.Controls.Add(this.FechaIng);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Cedula);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.IsFullTime);
            this.Controls.Add(this.isPartTime);
            this.Controls.Add(this.Guardar);
            this.Name = "EmployeeAddEdit";
            this.Text = "EmployeeAddEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.CheckBox isPartTime;
        private System.Windows.Forms.CheckBox IsFullTime;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.TextBox Cedula;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.DateTimePicker FechaIng;
        private System.Windows.Forms.TextBox Salario;
        private System.Windows.Forms.TextBox CantHoras;
    }
}