using dominio1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio1;

namespace wfrmPokemon
{
    public partial class frmAltaPokemon : Form
    {
        public frmAltaPokemon()
        {
            InitializeComponent();
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevoPokemon = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                nuevoPokemon.Numero = int.Parse(txbNumero.Text);
                nuevoPokemon.Nombre = txbNombre.Text;
                nuevoPokemon.Descripcion = txbDescripcion.Text;
                nuevoPokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                nuevoPokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                negocio.Agregar(nuevoPokemon);
                MessageBox.Show("Agregado exitosamente");
                Close(); 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio ();

            try { 
            
                cboTipo.DataSource = elementoNegocio.Listar();
                cboDebilidad.DataSource = elementoNegocio.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
