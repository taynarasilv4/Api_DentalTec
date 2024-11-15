using Api_DentalTec.Database;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class CaixaDAO
    {
        private static ConnectionMysql conn;

        public CaixaDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Caixa item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tarefas (Funcionario, TotalEntrada, TotalSaida, ValorTotal, ValorInicial, TipoPagamento) VALUES " +
                    "(@Funcionario, @TotalEntrada, @TotalSaida, @ValorTotal, @ValorInicial, @TipoPagamento)";

                query.Parameters.AddWithValue("@Funcionario", item.Funcionario);
                query.Parameters.AddWithValue("@TotalEntrada", item.TotalEntrada);
                query.Parameters.AddWithValue("@TotalSaida", item.TotalSaida);
                query.Parameters.AddWithValue("@ValorTotal", item.ValorTotal);
                query.Parameters.AddWithValue("@ValorInicial", item.ValorInicial);
                query.Parameters.AddWithValue("@TipoPagamento", item.TipoPagamento);



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

        public List<Caixa> List()
        {
            try
            {
                List<Caixa> list = new List<Caixa>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM caixa";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Caixa()
                    {
                        Id = reader.GetInt32("id_cai"),
                        Funcionario = reader.GetString("funcionario_cai"),
                        TotalEntrada = Convert.ToDouble(reader["totalEntrada_cai"]),
                        TotalSaida = Convert.ToDouble(reader["totalEntrada_cai"]),
                        ValorTotal = Convert.ToDouble(reader["totalEntrada_cai"]),
                        ValorInicial = Convert.ToDouble(reader["totalEntrada_cai"]),
                        TipoPagamento = reader.GetString("tipoPagamento_cai")
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

        public Caixa? GetById(int id)
        {
            try
            {
                Caixa caixa = new Caixa();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM agenda WHERE Id = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    caixa.Id = reader.GetInt32("Id");
                    caixa.Funcionario = reader.GetString("Funcionario");
                    caixa.TotalEntrada = reader.GetDouble("TotalEntrada");
                    caixa.TotalSaida = reader.GetDouble("TotalSaida");
                    caixa.ValorTotal = reader.GetDouble("ValorTotal");
                    caixa.ValorInicial = reader.GetDouble("ValorInicial");
                    caixa.TipoPagamento = reader.GetString("TipoPagamento");

                }

                return caixa;
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


        public void Update(Caixa item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE agenda SET Funcionario = @Funcionario, TotalEntrada = @TotalEntrada, TotalSaida= @TotalSaida, ValorTotal = @ValorTotal, ValorInicial = @ValorInicial,TipoPagamento = @TipoPagamento WHERE Id = @_id";

                query.Parameters.AddWithValue("@Funcionario", item.Funcionario);
                query.Parameters.AddWithValue("@TotalEntrada", item.TotalEntrada);
                query.Parameters.AddWithValue("@TotalSaida", item.TotalSaida);
                query.Parameters.AddWithValue("@ValorTotal", item.ValorTotal);
                query.Parameters.AddWithValue("@ValorInicial", item.ValorInicial);
                query.Parameters.AddWithValue("@TipoPagamento", item.TipoPagamento);


                query.Parameters.AddWithValue("@_id", item.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente.");
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
                query.CommandText = "DELETE FROM paciente WHERE Id = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente.");
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





