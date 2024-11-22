using Api_DentalTec.Database;
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
                using (var query = conn.Query())
                {
                    query.CommandText = "INSERT INTO produto (nomeproduto_pro, codigoBarra_pro, dataFabricacao_pro, dataValidade_pro, valor_pro)" + "VALUES (@nomeproduto, @codigoBarra, @dataFabricacao, @dataValidade, @valor)";

                    query.Parameters.AddWithValue("@nomeproduto", item.Nomeproduto);
                    query.Parameters.AddWithValue("@codigoBarra", item.CodigoBarra);
                    query.Parameters.AddWithValue("@dataFabricacao", item.DataFabricacao.ToString("yyyy-MM-dd"));
                    query.Parameters.AddWithValue("@dataValidade", item.DataValidade.ToString("yyyy-MM-dd"));
                    query.Parameters.AddWithValue("@valor", item.Valor);

                    int result = query.ExecuteNonQuery();

                    if (result == 0)
                    {
                        throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                    }

                    return (int)query.LastInsertedId;
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
        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();

                using (var query = conn.Query())
                {
                    query.CommandText = "SELECT * FROM produto";

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
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
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os produtos: " + ex.Message);
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

                using (var query = conn.Query())
                {
                    query.CommandText = "SELECT * FROM produto WHERE id_pro = @_id";

                    query.Parameters.AddWithValue("@_id", id);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return null;
                        }
                        reader.Read();
                        _produto = new Produto()
                        {
                            Id = reader.GetInt32("id_pro"),
                            Nomeproduto = reader.GetString("nomeproduto_pro"),
                            CodigoBarra = reader.GetInt32("codigoBarra_pro"),
                            DataFabricacao = reader.GetDateTime("dataFabricacao_pro"),
                            DataValidade = reader.GetDateTime("dataValidade_pro"),
                            Valor = reader.GetDouble("valor_pro")
                        };
                    }
                }
                return _produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o produtos: " + ex.Message);
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
                using (var query = conn.Query())
                {
                    query.CommandText = "UPDATE produto SET valor_pro = @_valor, dataValidade_pro = @_dataValidade,  dataFabricacao_pro = @_dataFabricacao, codigoBarra_pro = @_codigoBarra,  nomeproduto_pro = @_nomeproduto WHERE id_pro = @_id";

                    query.Parameters.AddWithValue("@_valor", item.Valor);
                    query.Parameters.AddWithValue("@_dataValidade", item.DataValidade);
                    query.Parameters.AddWithValue("@_dataFabricacao", item.DataFabricacao);
                    query.Parameters.AddWithValue("@_codigoBarra", item.CodigoBarra);
                    query.Parameters.AddWithValue("@_nomeproduto", item.Nomeproduto);
                    query.Parameters.AddWithValue("@_id", item.Id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("O produto não foi atualizado.");
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o produto: " + ex.Message);
                
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
                using (var query = conn.Query())
                {
                    query.CommandText = "DELETE FROM produto WHERE id_pro = @_id";

                    query.Parameters.AddWithValue("@_id", id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("O produto não foi removido.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o produto: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}







