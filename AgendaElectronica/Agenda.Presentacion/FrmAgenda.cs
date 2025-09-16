using Agenda.Entidad;
using Agenda.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda.Presentacion
{
    public partial class FrmAgenda : Form
    {
        private ContactoBLL contactoBLL = new ContactoBLL();

        public FrmAgenda()
        {
            InitializeComponent();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(cbGenero.Text) ||
                string.IsNullOrWhiteSpace(cbEstado.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios, excepto Teléfono y Móvil.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMovil.Text) && string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Debe ingresar al menos un número: móvil o teléfono.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar correo electrónico
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar móvil y teléfono (formato internacional)
            string patternTelefono = @"^\+?\d{7,15}$"; // Permite + y entre 7 a 15 dígitos

            if (!string.IsNullOrWhiteSpace(txtMovil.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtMovil.Text, patternTelefono))
            {
                MessageBox.Show("El número móvil no es válido. Use formato internacional (ej: +18095551234).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, patternTelefono))
            {
                MessageBox.Show("El número de teléfono no es válido. Use formato internacional.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CargarContactos()
        {
            dgvContactos.AutoGenerateColumns = true;
            dgvContactos.DataSource = contactoBLL.BuscarContacto("");
        }


        private void MostrarPanel(Panel panel)
        {
            panelNuevo.Visible = false;
            panelBuscar.Visible = false;
            panelLista.Visible = false;

            panelNuevo.SendToBack();
            panelBuscar.SendToBack();
            panelLista.SendToBack();

            panel.Visible = true;
            panel.BringToFront(); // esto lo asegura

            if (panel == panelNuevo)
                this.Size = new Size(500, 600);
            else if (panel == panelBuscar)
                this.Size = new Size(500, 600);
            else if (panel == panelLista)
                this.Size = new Size(1100, 700);
        }



        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'agendaBDDataSet.Contactos' Puede moverla o quitarla según sea necesario.
            this.contactosTableAdapter.Fill(this.agendaBDDataSet.Contactos);
            MostrarPanel(panelNuevo);
            CargarContactos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelNuevo);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelBuscar);
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            CargarContactos(); // Esto carga todos los contactos
            MostrarPanel(panelLista);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            Contacto contacto = new Contacto
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFecha.Value,
                Direccion = txtDireccion.Text,
                Genero = cbGenero.Text,
                EstadoCivil = cbEstado.Text,
                Movil = txtMovil.Text,
                Telefono = txtTelefono.Text,
                CorreoElectronico = txtEmail.Text
            };

            if (contactoBLL.InsertarContacto(contacto))
            {
                MessageBox.Show("Contacto insertado correctamente.");
                LimpiarFormulario();
                CargarContactos();
            }
            else
            {
                MessageBox.Show("Error al insertar contacto.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            Contacto contacto = new Contacto
            {
                IdContacto = int.Parse(txtIdContacto.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFecha.Value,
                Direccion = txtDireccion.Text,
                Genero = cbGenero.Text,
                EstadoCivil = cbEstado.Text,
                Movil = txtMovil.Text,
                Telefono = txtTelefono.Text,
                CorreoElectronico = txtEmail.Text
            };

            if (contactoBLL.ModificarContacto(contacto))
            {
                MessageBox.Show("Contacto modificado correctamente.");
                LimpiarFormulario();
                CargarContactos();
            }
            else
            {
                MessageBox.Show("Error al modificar contacto.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdContacto.Text))
            {
                MessageBox.Show("Seleccione un contacto primero.");
                return;
            }

            int id = int.Parse(txtIdContacto.Text);

            if (MessageBox.Show("¿Está segura de eliminar este contacto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (contactoBLL.EliminarContacto(id))
                {
                    MessageBox.Show("Contacto eliminado correctamente.");
                    LimpiarFormulario();
                    CargarContactos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar contacto.");
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtIdContacto.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFecha.Value = DateTime.Now;
            txtDireccion.Clear();
            cbGenero.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtMovil.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvContactos.Rows[e.RowIndex];

                txtIdContacto.Text = fila.Cells["IdContacto"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                cbGenero.Text = fila.Cells["Genero"].Value.ToString();
                cbEstado.Text = fila.Cells["EstadoCivil"].Value.ToString();
                txtMovil.Text = fila.Cells["Movil"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtEmail.Text = fila.Cells["CorreoElectronico"].Value.ToString();

                // Mostrar el panel de edición automáticamente (si quieres)
                MostrarPanel(panelNuevo);
            }
        }

        private void btnBuscarInfo_Click(object sender, EventArgs e)
        {
            string texto = txtInfoContacto.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Escribe algo para buscar (nombre, correo, etc.).", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí verificamos si realmente devuelve resultados
            var resultado = contactoBLL.BuscarContacto(texto);
            MessageBox.Show($"Se encontraron {resultado.Count} contactos.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvContactos.AutoGenerateColumns = true;
            // Mostrar los resultados
            dgvContactos.DataSource = resultado;

            // Llevar al panel de la lista
            MostrarPanel(panelLista);

            txtInfoContacto.Clear();
        }


        private void txtInfoContacto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
