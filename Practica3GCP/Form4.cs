using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3GCP
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtClienteID.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(txtNombreCompleto.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(txtCorreoElectronico.Text))
            {
                MessageBox.Show("El Correo está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("El Telefono está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("La Direccion está incorrecto o vacio.");
                return;
            }

            string connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = PracticaGCP; Data Source = GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryInsertarClientes = @"INSERT INTO Clientes (ClientesID, NombreCompleto, CorreoElectronico, Telefono, Direccion)
                                           VALUES ('" + txtClienteID.Text + "', '" + txtNombreCompleto.Text + "', '" + txtCorreoElectronico.Text + "', '" + txtTelefono.Text + "', '" + txtDireccion.Text + "')";

                using (SqlCommand cmd = new SqlCommand(queryInsertarClientes, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha insertado un Cliente en la base de datos.");
                    }
                }

                connection.Close();
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Debe introducir un ID válido.");
                return;
            }

            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PracticaGCP;Data Source=GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryEliminarClientes = @"DELETE FROM Clientes WHERE ClientesID = '" + txtID.Text + "'";

                using (SqlCommand cmd = new SqlCommand(queryEliminarClientes, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha eliminado un Cliente en la base de datos.");
                    }
                }

                connection.Close();
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ActualizarClienteID.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(ActualizarNombreCompleto.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(ActualizarCorreoElectronico.Text))
            {
                MessageBox.Show("El Correo está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(ActualizarTelefono.Text))
            {
                MessageBox.Show("El Telefono está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(ActualizarDireccion.Text))
            {
                MessageBox.Show("La Direccion está incorrecto o vacio.");
                return;
            }

            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PracticaGCP;Data Source=GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryActualizarClientes = @"UPDATE Clientes 
                                                    SET 
                                                        NombreCompleto = '" + ActualizarNombreCompleto.Text + "', " +
                                                        "CorreoElectronico = '" + ActualizarNombreCompleto.Text + "', " +
                                                        "Telefono = '" + ActualizarTelefono.Text + "', " +
                                                        "Direccion = '" + ActualizarDireccion.Text + "' " +
                                                    "WHERE ClientesID = '" + ActualizarClienteID.Text + "'";


                using (SqlCommand cmd = new SqlCommand(queryActualizarClientes, connection))
                {


                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha actualizado el Cliente en la base de datos.");
                    }


                }

                connection.Close();
            }
        }

        private void Cargar_Click(object sender, EventArgs e)
        {
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PracticaGCP;Data Source=GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryClientes = "SELECT * FROM Clientes;";

                using (SqlCommand cmd = new SqlCommand(queryClientes, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgClientes.DataSource = dt;
                    }
                }

                connection.Close();
            }
        }
    }
}
