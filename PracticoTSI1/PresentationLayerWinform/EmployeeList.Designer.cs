namespace PresentationLayerWinform
{
    partial class EmployeeList
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
            this.ListEmp = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nuevo = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListEmp
            // 
            this.ListEmp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Nombre,
            this.Fecha});
            this.ListEmp.LabelEdit = true;
            this.ListEmp.Location = new System.Drawing.Point(76, 12);
            this.ListEmp.Name = "ListEmp";
            this.ListEmp.Size = new System.Drawing.Size(219, 301);
            this.ListEmp.TabIndex = 0;
            this.ListEmp.UseCompatibleStateImageBehavior = false;
            this.ListEmp.View = System.Windows.Forms.View.Details;
            this.ListEmp.MouseClick += ListEmp_MouseClick;
            // 
            // Id
            // 
            this.Id.Text = "ID";
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            // 
            // Nuevo
            // 
            this.Nuevo.Location = new System.Drawing.Point(83, 318);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(87, 28);
            this.Nuevo.TabIndex = 1;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // Editar
            // 
            this.Editar.Location = new System.Drawing.Point(191, 318);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(92, 27);
            this.Editar.TabIndex = 2;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            this.Editar.Click += new System.EventHandler(this.Editar_Click);
            // 
            // EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 358);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.ListEmp);
            this.Name = "EmployeeList";
            this.Text = "EmployeeList";
            this.Load += new System.EventHandler(this.EmployeeList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListEmp;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button Editar;
    }
}

