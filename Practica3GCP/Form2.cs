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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoriaID.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(txtNombreCategoria.Text))
            {
                MessageBox.Show("El apellido está incorrecto o vacio.");
                return;
            }
            
            string connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = PracticaGCP; Data Source = GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryInsertarCategoria = @"INSERT INTO Categorias (CategoriaID, NombreCategoria)
                                           VALUES ('" + txtCategoriaID.Text + "','" + txtNombreCategoria.Text + "')";

                using (SqlCommand cmd = new SqlCommand(queryInsertarCategoria, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha insertado una Categoria en la base de datos.");
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

                string queryEliminarCategoria = @"DELETE FROM Categorias WHERE CategoriaID = '" + txtID.Text + "'";

                using (SqlCommand cmd = new SqlCommand(queryEliminarCategoria, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha eliminado una Categoria en la base de datos.");
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

                string queryCategorias = "SELECT * FROM Categorias;";

                using (SqlCommand cmd = new SqlCommand(queryCategorias, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgCategoria.DataSource = dt;
                    }
                }

                connection.Close();
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ActualizarCategoriaID.Text))
            {
                MessageBox.Show("Debe introducir un ID válido.");
                return;
            }

            if (string.IsNullOrEmpty(ActualizarNombreCategoria.Text))
            {
                MessageBox.Show("El nombre de Categoria está incorrecto o vacio.");
                return;
            }
            
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PracticaGCP;Data Source=GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryActualizarCategoria = @"UPDATE Categorias 
                                                    SET 
                                                        NombreCategoria = '" + ActualizarNombreCategoria.Text + "'" +
                                                    "WHERE CategoriaID = '" + ActualizarCategoriaID.Text + "'";


                using (SqlCommand cmd = new SqlCommand(queryActualizarCategoria, connection))
                {
                   

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha actualizado la Categoria en la base de datos.");
                    }
                    
                 
                }

                connection.Close();
            }
        }
    }
}
