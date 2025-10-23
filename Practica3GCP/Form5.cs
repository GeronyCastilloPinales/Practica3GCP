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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProveedorID.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(txtNombreProveedor.Text))
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

            string connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = PracticaGCP; Data Source = GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryInsertarProveedores = @"INSERT INTO Proveedores (ProveedorID, NombreProveedor, Telefono, CorreoElectronico)
                                           VALUES ('" + txtProveedorID.Text + "', '" + txtNombreProveedor.Text + "', '" + txtTelefono.Text + "', '" + txtCorreoElectronico.Text + "')";

                using (SqlCommand cmd = new SqlCommand(queryInsertarProveedores, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha insertado un Proveedor en la base de datos.");
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

                string queryEliminarProveedores = @"DELETE FROM Proveedores WHERE ProveedorID = '" + txtID.Text + "'";

                using (SqlCommand cmd = new SqlCommand(queryEliminarProveedores, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha eliminado un Proveedor en la base de datos.");
                    }
                }

                connection.Close();
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ActualizarProveedorID.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }


            if (string.IsNullOrEmpty(ActualizarNombreProveedor.Text))
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

            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PracticaGCP;Data Source=GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryActualizarProveedores = @"UPDATE Proveedores 
                                                    SET 
                                                        NombreProveedor = '" + ActualizarNombreProveedor.Text + "', " +
                                                        "Telefono = '" + ActualizarTelefono.Text + "', " +
                                                        "CorreoElectronico = '" + ActualizarCorreoElectronico.Text + "' " +
                                                    "WHERE ProveedorID = '" + ActualizarProveedorID.Text + "'";


                using (SqlCommand cmd = new SqlCommand(queryActualizarProveedores, connection))
                {


                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha actualizado un Proveedor en la base de datos.");
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

                string queryProveedores = "SELECT * FROM Proveedores";

                using (SqlCommand cmd = new SqlCommand(queryProveedores, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgProveedores.DataSource = dt;
                    }
                }

                connection.Close();
            }
        }
    }
}
