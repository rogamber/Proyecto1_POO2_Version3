using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_POO2_UNED_RonnyGamboa
{
    public partial class FrmPrincipal : Form
    {
        private int n = 0;
        public static string info;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Se agregran filas al DataGridView y se asigana a la variable row el valor de la fila selecionada actual
            int row = dtgAgenda.Rows.Add();
            //se asigna a la varable n el valor de la fila seleccionada actual
            n = row;

            //Se agrega cada valor ingresado al DataGridView
            dtgAgenda.Rows[row].Cells[0].Value = txtNombre.Text;
            dtgAgenda.Rows[row].Cells[1].Value = txtTel.Text;
            dtgAgenda.Rows[row].Cells[2].Value = txtCel.Text;
            dtgAgenda.Rows[row].Cells[3].Value = txtEmail.Text;

            //Se limpian los textbox
            txtCel.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            {
                try
                {
                   //se crea formulario para consultar si desea borrar el contacto                 
                   DialogResult result;
                   result = MessageBox.Show("Realmente desea eliminar este contacto?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                   // dtgAgenda.Rows.RemoveAt(n);    
                
                }
                catch (Exception) //bloque catch para captura de error
                {
                    string mensaje = "Se produjo un error , no se pudo borrar la fila";
                    MessageBox.Show(mensaje);
                }

            }
        }

        private void dtgAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int fila = e.RowIndex;
            int columna = e.ColumnIndex;
            n = fila;

            //muestra la informacion de la celda seleccionada 
            if (n != -1)
            {
                lblinfo.Text = "Info CellClick: " + (string)dtgAgenda.Rows[fila].Cells[columna].Value;
            }

            //se verifica si se dio click sobre algun numer de telefono Fijo
            if (e.ColumnIndex == this.dtgAgenda.Columns[1].Index)

            {
                string mensaje = "Se llamara al telefono fijo";
                MessageBox.Show(mensaje);

            }

            //se verifica si se dio click sobre algun numer de telefono celular
            if (e.ColumnIndex == this.dtgAgenda.Columns[2].Index)

            {
                info = (string)dtgAgenda.Rows[fila].Cells[columna].Value;
                string mensaje = "Se llamara al telefono Celular";
                //MessageBox.Show(mensaje+" "+info);
                Frmllamada Frmllamar = new Frmllamada();
                //Formulario2.MdiParent = this;
                //this.dtgAgenda.Visible = false;
                Frmllamar.Show();
                //this.dtgAgenda.Visible = true;
            }

            //se verifica si se dio click sobre una direccion de email
            if (e.ColumnIndex == this.dtgAgenda.Columns[3].Index)
            {
                string mensaje = "Se enviara un Email";
                MessageBox.Show(mensaje);

            }
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //se establecen los anchos de las columnas
            dtgAgenda.Columns[0].Width = 300;
            dtgAgenda.Columns[1].Width = 100;
            dtgAgenda.Columns[2].Width = 100;
            dtgAgenda.Columns[3].Width = 200;
        }

       

    }
}
