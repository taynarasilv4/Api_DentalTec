using Api_DentalTec.Database;
using Api_DentalTec.Models;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class DespesaDao
    {

        private static ConnectionMysql conn;

        public DespesaDao()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Despesa item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO despesas (funcionario_des, caixa_des, data_des, valor_des, descricao_des)" + "VALUES (@funcionario, @caixa, @data, @valor, @descricao)";

                query.Parameters.AddWithValue("@funcionario", item.Funcionario);
                query.Parameters.AddWithValue("@caixa", item.Caixa);
                query.Parameters.AddWithValue("@data", item.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@valor", item.Valor);
                query.Parameters.AddWithValue("@descricao", item.Descricao);


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

        public List<Despesa> List()
        {
            try
            {
                List<Despesa> list = new List<Despesa>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM despesas";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Despesa()
                    {
                        Id = reader.GetInt32("id_des"),
                        Funcionario = reader.GetString("funcionario_des"),
                        Caixa = reader.GetString("caixa_des"),
                        Data = reader.GetDateTime("data_des"),
                        Valor = reader.GetDouble("valor_des"),
                        Descricao = reader.GetString("descricao_des")
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

        public Despesa? GetById(int id)
        {
            try
            {
                Despesa _despesa = new Despesa();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM despesas WHERE id_des = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _despesa.Id = reader.GetInt32("id_des");
                    _despesa.Funcionario = reader.GetString("funcionario_des");
                    _despesa.Caixa = reader.GetString("caixa_des");
                    _despesa.Data = reader.GetDateTime("data_des");
                    _despesa.Valor = reader.GetDouble("valor_des");
                    _despesa.Descricao = reader.GetString("descricao_des");

                }

                return _despesa;
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

        public void Update(Despesa item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE despesas SET descricao_des = @_descricao, valor_des = @_valor,  data_des = @_data,  caixa_des = @_caixa,  funcionario_des = @_funcionario WHERE id_des = @_id";

                query.Parameters.AddWithValue("@_descricao", item.Descricao);
                query.Parameters.AddWithValue("@_valor", item.Valor);
                query.Parameters.AddWithValue("@_data", item.Data);
                query.Parameters.AddWithValue("@_caixa", item.Caixa);
                query.Parameters.AddWithValue("@_funcionario", item.Funcionario);
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
                query.CommandText = "DELETE FROM despesas WHERE id_des = @_id";

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
   


  