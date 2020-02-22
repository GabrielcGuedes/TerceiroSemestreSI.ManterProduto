using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ManterProduto
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string marca = txtMarca.Text;
                double preco = Convert.ToDouble(txtPreco.Text);

                Modelo.Produto objProduto = new Modelo.Produto();
                objProduto.Nome = nome;
                objProduto.Marca = marca;
                objProduto.Preco = preco;

                objProduto.Cadastrar();

                MessageBox.Show("operação realizada com sucesso.");
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar." + ex.Message, "falha na operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            }
        }
    }

