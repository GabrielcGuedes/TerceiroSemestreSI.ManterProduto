using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManterProduto.Util;
using Npgsql;

namespace ManterProduto.Modelo
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }

        public Produto()
        {

        }
        public Produto(string nome, string marca, double preco)
        {
            this.Nome = nome;
            this.Marca = marca;
            this.Preco = preco;
        }
        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "INSERT INTO produto (nome, marca, preco) VALUES" +
                                "('" + this.Nome + "', '" + this.Marca + "', '" + this.Preco + "')";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@nome", this.Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@marca", this.Marca));
                cmd.Parameters.Add(new NpgsqlParameter("@preco", this.Preco));
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
        public List<Produto> Listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "SELECT * FROM produto";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Produto> listaProdutos = new List<Produto>();
                while(dr.Read())
                {
                    Produto novoProduto = new Produto();
                    novoProduto.Id = Convert.ToInt16(dr["id"]);
                    novoProduto.Nome = dr["nome"].ToString();
                    novoProduto.Marca = dr["marca"].ToString();
                    novoProduto.Preco = Convert.ToDouble(dr["preco"]);

                    listaProdutos.Add(novoProduto);
                }
                return listaProdutos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                if(conexao != null)
                {
                    conexao.Close();
                }
            }
        }
    }
}
