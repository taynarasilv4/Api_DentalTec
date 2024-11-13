using Api_DentalTec.Database;
using Api_DentalTec.Models;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class ProdutoDAO
    {

        private static ConnectionMysql conn;

        public ProdutoDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Produto item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO produtos (nomeproduto_pro, codigoBarra_pro, dataFabricacao_pro, dataValidade_pro, valor_pro)" + "VALUES (@nomeproduto, @codigoBarra, @dataFabricacao, @dataValidade, @valor_pro)";

                query.Parameters.AddWithValue("@nomeproduto", item.Nomeproduto);
                query.Parameters.AddWithValue("@codigoBarra", item.CodigoBarra);
                query.Parameters.AddWithValue("@dataFabricacao", item.DataFabricacao.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@dataValidade", item.DataValidade.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@valor", item.Valor);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM produtos";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        Id = reader.GetInt32("id_pro"),
                        Nomeproduto = reader.GetString("nomeproduto_pro"),
                        CodigoBarra = reader.GetInt32("codigoBarra_pro"),
                        DataFabricacao = reader.GetDateTime("dataFabricacao_pro"),
                        DataValidade = reader.GetDateTime("dataValidade_pro"),
                        Valor = reader.GetDouble("valor_pro")
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Produto? GetById(int id)
        {
            try
            {
                Produto _produto = new Produto();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM produtos WHERE id_pro = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _produto.Id = reader.GetInt32("id_pro");
                    _produto.Nomeproduto = reader.GetString("nomeproduto_pro");
                    _produto.CodigoBarra = reader.GetInt32("codigoBarra_pro");
                    _produto.DataFabricacao = reader.GetDateTime("dataFabricacao_pro");
                    _produto.DataValidade = reader.GetDateTime("dataValidade_pro");
                    _produto.Valor = reader.GetDouble("valor_pro");

                }

                return _produto;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Produto item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE produtos SET valor_pro = @_valor, dataValidade_pro = @_dataValidade,  dataFabricacao_pro = @_dataFabricacao, codigoBarra_pro = @_codigoBarra,  nomeproduto_pro = @_nomeproduto WHERE id_pro = @_id";

                query.Parameters.AddWithValue("@_valor", item.Valor);
                query.Parameters.AddWithValue("@_dataValidade", item.DataValidade);
                query.Parameters.AddWithValue("@_dataFabricacao", item.DataFabricacao);
                query.Parameters.AddWithValue("@_codigoBarra", item.CodigoBarra);
                query.Parameters.AddWithValue("@_nomeproduto", item.Nomeproduto);
                query.Parameters.AddWithValue("@_id", item.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM produtos WHERE id_des = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }


    }
}







