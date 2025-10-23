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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void cargarDatos()
        {
            string connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = PracticaGCP; Data Source = GeronyCP";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryProductos = @"SELECT p.ProcductoID, p.NombreProducto, p.Descripcion, p.Precio, p.Stock, c.CategoriaID
	                                                FROM Productos p
		                                                INNER JOIN  Categorias c
			                                                ON p.CategoriaID = c.CategoriaID;";

                using (SqlCommand cmd = new SqlCommand(queryProductos, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgProducto.DataSource = dt;
                    }
                }

                connection.Close();
            }
        }

        private void cargarCmbCategorias()
        {
            string connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = PracticaGCP; Data Source = GeronyCP";
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

                        cmbCategoria.DataSource = dt;
                        cmbCategoria.DisplayMember = "NombreCategoria";
                        cmbCategoria.ValueMember = "CategoriaID";

                        cmbCategoriaActualizado.DataSource = dt;
                        cmbCategoriaActualizado.DisplayMember = "NombreCategoria";
                        cmbCategoriaActualizado.ValueMember = "CategoriaID";
                    }
                }
                connection.Close();
            }
        }
        private void Agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoID.Text))
            {
                MessageBox.Show("La ID del producto está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("El precio está incorrecta o vacia.");
                return;
            }

            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("El stock está incorrecta o vacia.");
                return;
            }

            if (string.IsNullOrEmpty(cmbCategoria.SelectedValue.ToString()))
            {
                MessageBox.Show("La categoria está incorrecto o vacio.");
                return;
            }

            string connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = PracticaGCP; Data Source = GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryInsertarProductos = @"INSERT INTO Productos (ProcductoID, NombreProducto, Descripcion, Precio, Stock, CategoriaID)
                                           VALUES ('" + txtProductoID.Text + "', '" + txtNombreProducto.Text + "', '" + txtDescripcion.Text + "', '" + txtPrecio.Text + "', '" + txtStock.Text + "', '"+cmbCategoria.SelectedValue+"')";

                using (SqlCommand cmd = new SqlCommand(queryInsertarProductos, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha insertado un Producto en la base de datos.");
                    }
                }

                connection.Close();
            }
            this.cargarDatos();
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

                string queryEliminarProductos = @"DELETE FROM Productos WHERE ProcductoID = '" + txtID.Text + "'";

                using (SqlCommand cmd = new SqlCommand(queryEliminarProductos, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha eliminado un Producto en la base de datos.");
                    }
                }

                connection.Close();
            }
            this.cargarDatos();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ActualizarProductoID.Text))
            {
                MessageBox.Show("La ID del producto está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(ActualizarNombreProducto.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(ActualizarDescripcion.Text))
            {
                MessageBox.Show("La descripción está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(ActualizarPrecio.Text))
            {
                MessageBox.Show("El precio está incorrecta o vacia.");
                return;
            }

            if (string.IsNullOrEmpty(ActualizarStock.Text))
            {
                MessageBox.Show("El stock está incorrecta o vacia.");
                return;
            }

            if (string.IsNullOrEmpty(cmbCategoriaActualizado.SelectedValue.ToString()))
            {
                MessageBox.Show("La categoria está incorrecto o vacio.");
                return;
            }

            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PracticaGCP;Data Source=GeronyCP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryActualizarProductos = @"UPDATE Productos 
                                            SET 
                                                NombreProducto = '" + ActualizarNombreProducto.Text + "', " +
                                               "Descripcion = '" + ActualizarDescripcion.Text + "',  " +
                                               "Precio = '" + ActualizarPrecio.Text + "', " +
                                               "Stock = '" + ActualizarStock.Text + "', " +
                                               "CategoriaID = '" + cmbCategoriaActualizado.SelectedValue + "' " + 
                                           "WHERE ProcductoID = '" + ActualizarProductoID.Text + "'"; 

                using (SqlCommand cmd = new SqlCommand(queryActualizarProductos, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se ha actualizado el producto en la base de datos.");
                    }
                }

                connection.Close();
            }
            this.cargarDatos();
        }

        private void Cargar_Click(object sender, EventArgs e)
        {
            this.cargarDatos();
        }
        private void Productos_Load(object sender, EventArgs e)
        {
            this.cargarCmbCategorias();
            this.cargarDatos();
        }
        
    }


    
}
