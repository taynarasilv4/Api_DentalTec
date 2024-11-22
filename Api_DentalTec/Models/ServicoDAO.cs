using Api_DentalTec.Database;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class ServicoDAO
    {
        private static ConnectionMysql _conn;

        public ServicoDAO()
        {
            _conn = new ConnectionMysql();
        }

        // Inserir um serviço
        public int Insert(Servico item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO servico (nomeServico_serv, profissionalEspecializado_serv, descricao_serv, id_orc_fk) " +
                                    "VALUES (@nomeServico, @profissionalEspecializado, @descricao, @idOrcamento)";

                query.Parameters.AddWithValue("@nomeServico", item.NomeServico);
                query.Parameters.AddWithValue("@profissionalEspecializado", item.ProfissionalEspecializado);
                query.Parameters.AddWithValue("@descricao", item.Descricao);
                query.Parameters.AddWithValue("@idOrcamento", item.IdOrcamento); // FK

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O serviço não foi inserido. Verifique e tente novamente.");
                }

                return (int)query.LastInsertedId;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao inserir o serviço: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Listar todos os serviços
        public List<Servico> List()
        {
            try
            {
                List<Servico> list = new List<Servico>();

                using (var query = _conn.Query())
                {
                    query.CommandText = "SELECT * FROM servico";
                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Servico()
                            {
                                Id = reader.GetInt32("id_serv"),
                                NomeServico = reader.GetString("nomeServico_serv"),
                                ProfissionalEspecializado = reader.GetString("profissionalEspecializado_serv"),
                                Descricao = reader.GetString("descricao_serv"),
                                IdOrcamento = reader.GetInt32("id_orc_fk")
                            });
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar serviços: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Buscar um serviço por ID
        public Servico? GetById(int id)
        {
            try
            {
                Servico servico = null;

                using (var query = _conn.Query())
                {
                    query.CommandText = "SELECT * FROM servico WHERE id_serv = @_id";
                    query.Parameters.AddWithValue("@_id", id);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            servico = new Servico()
                            {
                                Id = reader.GetInt32("id_serv"),
                                NomeServico = reader.GetString("nomeServico_serv"),
                                ProfissionalEspecializado = reader.GetString("profissionalEspecializado_serv"),
                                Descricao = reader.GetString("descricao_serv"),
                                IdOrcamento = reader.GetInt32("id_orc_fk")
                            };
                        }
                    }
                }

                return servico;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar serviço por ID: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Atualizar um serviço
        public void Update(Servico item)
        {
            try
            {
                using (var query = _conn.Query())
                {
                    query.CommandText = "UPDATE servico SET nomeServico_serv = @_nomeServico, profissionalEspecializado_serv = @_profissionalEspecializado, " +
                                    "descricao_serv = @_descricao, id_orc_fk = @_idOrcamento WHERE id_serv = @_id";

                    query.Parameters.AddWithValue("@_nomeServico", item.NomeServico);
                    query.Parameters.AddWithValue("@_profissionalEspecializado", item.ProfissionalEspecializado);
                    query.Parameters.AddWithValue("@_descricao", item.Descricao);
                    query.Parameters.AddWithValue("@_idOrcamento", item.IdOrcamento); // FK
                    query.Parameters.AddWithValue("@_id", item.Id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("O serviço não foi atualizado.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o serviço: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Excluir um serviço
        public void Delete(int id)
        {
            try
            {
                using (var query = _conn.Query())
                {
                    query.CommandText = "DELETE FROM servico WHERE id_serv = @_id";
                    query.Parameters.AddWithValue("@_id", id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("O serviço não foi removido.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o serviço: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
