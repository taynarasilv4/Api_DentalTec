using Api_DentalTec.Database;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class OrcamentoDAO
    {
        private static ConnectionMysql conn;

        public OrcamentoDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Orcamento item)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "INSERT INTO orcamento (nome_orc, data_Nasc_orc, cpf_orc, rua_orc, numero_orc, bairro_orc, " +
                    "cidade_orc, email_orc, contato_orc, profissional_orc, data_orc, servico_orc, regiao_orc, valor_unit_orc) " +
                    "VALUES (@nome, @data_Nascimento, @cpf, @rua, @numero, @bairro, @cidade, @email, @contato, @profissional," +
                    " @data, @servico, @regiao, @valor_Unitario)";

                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@data_Nascimento", item.Data_Nasc.ToString("yyyy-MM-dd HH:mm:ss")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@cpf", item.Cpf);
                query.Parameters.AddWithValue("@rua", item.Rua);
                query.Parameters.AddWithValue("@numero", item.Numero);
                query.Parameters.AddWithValue("@bairro", item.Bairro);
                query.Parameters.AddWithValue("@cidade", item.Cidade);
                query.Parameters.AddWithValue("@email", item.Email);
                query.Parameters.AddWithValue("@contato", item.Contato);
                query.Parameters.AddWithValue("@profissional", item.Profissional);
                query.Parameters.AddWithValue("@data", item.Data.ToString("yyyy-MM-dd HH:mm:ss"));
                query.Parameters.AddWithValue("@servico", item.Servico);
                query.Parameters.AddWithValue("@regiao", item.Regiao);
                query.Parameters.AddWithValue("@valor_Unitario", item.Valor_Unit);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Orcamento> List()
        {
            try
            {
                List<Orcamento> list = new List<Orcamento>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM orcamento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Orcamento()
                    {
                        Id = reader.GetInt32("id_orc"),
                        Nome = reader.GetString("nome_orc"),
                        Data_Nasc = reader.GetDateTime("data_Nasc_orc"),
                        Cpf = reader.GetString("cpf_orc"),
                        Rua = reader.GetString("rua_orc"),
                        Numero = reader.GetInt32("numero_orc"),
                        Bairro = reader.GetString("bairro_orc"),
                        Cidade = reader.GetString("cidade_orc"),
                        Email = reader.GetString("email_orc"),
                        Contato = reader.GetString("contato_orc"),
                        Profissional = reader.GetString("profissional_orc"),
                        Data = reader.GetDateTime("data_orc"),
                        Servico = reader.GetString("servico_orc"),
                        Regiao = reader.GetString("regiao_orc"),
                        Valor_Unit = reader.GetDouble("valor_Unit_orc")
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Orcamento? GetById(int id)
        {
            try
            {
                Orcamento _orcamento = new Orcamento();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM orcamento WHERE id_orc = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _orcamento.Id = reader.GetInt32("id_orc");
                    _orcamento.Nome = reader.GetString("nome_orc");
                    _orcamento.Data_Nasc = reader.GetDateTime("data_Nasc_orc");
                    _orcamento.Cpf = reader.GetString("cpf_orc");
                    _orcamento.Rua = reader.GetString("rua_orc");
                    _orcamento.Numero = reader.GetInt32("numero_orc");
                    _orcamento.Bairro = reader.GetString("bairro_orc");
                    _orcamento.Cidade = reader.GetString("cidade_orc");
                    _orcamento.Email = reader.GetString("email_orc");
                    _orcamento.Contato = reader.GetString("contato_orc");
                    _orcamento.Profissional = reader.GetString("profissional_orc");
                    _orcamento.Data = reader.GetDateTime("data_orc");
                    _orcamento.Servico = reader.GetString("servico_orc");
                    _orcamento.Regiao = reader.GetString("regiao_orc");
                    _orcamento.Valor_Unit = reader.GetDouble("valor_Unit_orc");
                }

                return _orcamento;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Orcamento item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE orcamento SET nome_orc = @_nome, data_Nasc_orc = @_data_Nasc, cpf_orc = @_cpf," +
                    "rua_orc = @_rua, numero_orc = @_numero, bairro_orc = @_bairro, cidade_orc = @_cidade, email_orc = @_email," +
                    "contato_orc = @_contato, profissional_orc = @_profissional, data_orc = @_data, servico_orc = @_servico," +
                    "regiao_orc = @_regiao, valor_Unit_orc = @_valor_Unit WHERE id_orc = @_id";

                query.Parameters.AddWithValue("@_nome", item.Nome);
                query.Parameters.AddWithValue("@_data_Nasc", item.Data_Nasc);
                query.Parameters.AddWithValue("@_cpf", item.Cpf);
                query.Parameters.AddWithValue("@_rua", item.Rua);
                query.Parameters.AddWithValue("@_numero", item.Numero);
                query.Parameters.AddWithValue("@_bairro", item.Bairro);
                query.Parameters.AddWithValue("@_cidade", item.Cidade);
                query.Parameters.AddWithValue("@_email", item.Email);
                query.Parameters.AddWithValue("@_contato", item.Contato);
                query.Parameters.AddWithValue("@_profissional", item.Profissional);
                query.Parameters.AddWithValue("@_data", item.Data);
                query.Parameters.AddWithValue("@_servico", item.Servico);
                query.Parameters.AddWithValue("@_regiao", item.Regiao);
                query.Parameters.AddWithValue("@_valor_Unit", item.Valor_Unit);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
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
                query.CommandText = "DELETE FROM orcamento WHERE id_orc = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}


















