using Api_DentalTec.Database;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class AgendaDAO
    {

        private static ConnectionMysql _conn;

        public AgendaDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Agenda item)
        {
            try
            {
                using (var query = _conn.Query())
                {


                    query.CommandText = "INSERT INTO agenda (nome_age, profissional_age, data_age, hora_age) " +
                                        "VALUES (@nome, @profissional, @data, @hora)";

                    query.Parameters.AddWithValue("@nome", item.NomeAgenda);
                    query.Parameters.AddWithValue("@profissional", item.ProfissionalAgenda);
                    query.Parameters.AddWithValue("@data", item.DataAgenda.ToString("yyyy-MM-dd"));
                    query.Parameters.AddWithValue("@hora", item.HoraAgenda);

                    int result = query.ExecuteNonQuery();

                    if (result == 0)
                    {
                        throw new Exception("O registro não foi inserido. Verifique e tente novamente.");
                    }

                    return (int)query.LastInsertedId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir a agenda: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }



        public List<Agenda> List()
        {
            try
            {
                List<Agenda> list = new List<Agenda>();

                using (var query = _conn.Query())
                {
                    query.CommandText = "SELECT * FROM agenda";
                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Agenda()
                            {
                                Id = reader.GetInt32("id_age"),
                                NomeAgenda = reader.GetString("nome_age"),
                                ProfissionalAgenda = reader.GetString("profissional_age"),
                                DataAgenda = reader.GetDateTime("data_age"),
                                HoraAgenda = reader.GetDateTime("hora_age").TimeOfDay
                            });
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as agenda: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
        public Agenda? GetById(int id)
        {
            try
            {
                Agenda agenda = null;

                using (var query = _conn.Query())
                {
                    query.CommandText = "SELECT * FROM agenda WHERE id_age = @_id";
                    query.Parameters.AddWithValue("@_id", id);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            agenda = new Agenda()
                            {
                                Id = reader.GetInt32("id_age"),
                                NomeAgenda = reader.GetString("nome_age"),
                                ProfissionalAgenda = reader.GetString("profissional_age"),
                                DataAgenda = reader.GetDateTime("data_age"),
                                HoraAgenda = reader.GetDateTime("hora_age").TimeOfDay
                            };
                        }
                    }
                }

                return agenda;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a agenda: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }


        public void Update(Agenda item)
        {
            try
            {
                using (var query = _conn.Query())
                {
                    query.CommandText = "UPDATE agenda SET nome = @_nome, profissional = @_profissional, data = @_data, hora = @_hora WHERE id = @_id";


                    query.Parameters.AddWithValue("@_nome", item.NomeAgenda);
                    query.Parameters.AddWithValue("@_profissional", item.ProfissionalAgenda);
                    query.Parameters.AddWithValue("@_data", item.DataAgenda.ToString("yyyy-MM-dd"));
                    query.Parameters.AddWithValue("@_hora", item.HoraAgenda.ToString("yyyy-MM-dd"));
                    query.Parameters.AddWithValue("@_id", item.Id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("A agenda não foi atualizado.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a agenda: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var query = _conn.Query())
                {
                    query.CommandText = "DELETE FROM agenda WHERE id_age = @_id";
                    query.Parameters.AddWithValue("@_id", id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("A agenda não foi removido.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover a agenda: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}

