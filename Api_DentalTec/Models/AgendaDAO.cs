using Api_DentalTec.Database;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class AgendaDAO
    {
        private static ConnectionMysql conn;

        public AgendaDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Agenda item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO agenda (Nome ,Profissional, Data, Hora) " +
                                    "VALUES (@Nome, @Profissional, @Data, @Hora)";

                query.Parameters.AddWithValue("@Nome", item.NomeAgenda);
                query.Parameters.AddWithValue("@Profissional", item.ProfissionalAgenda);
                query.Parameters.AddWithValue("@Data", item.DataAgenda);
                query.Parameters.AddWithValue("@Hora", item.HoraAgenda);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");
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

        public List<Agenda> List()
        {
            try
            {
                List<Agenda> list = new List<Agenda>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM agenda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Agenda()
                    {
                        Id = reader.GetInt32("Id"),
                        NomeAgenda = reader.GetString("Nome"),
                        ProfissionalAgenda = reader.GetString("Profissional"),
                        DataAgenda = reader.GetDateTime("Data"),
                        HoraAgenda = reader.GetDateTime("Hora").TimeOfDay


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

        public Agenda? GetById(int id)
        {
            try
            {
                Agenda agenda = new Agenda();

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
                    agenda.Id = reader.GetInt32("Id");
                    agenda.NomeAgenda = reader.GetString("Nome");
                    agenda.ProfissionalAgenda = reader.GetString("Profissional");
                    agenda.DataAgenda = reader.GetDateTime("Data");
                    agenda.HoraAgenda = reader.GetDateTime("Hora").TimeOfDay;

                }

                return agenda;
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

        public void Update(Agenda item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE agenda SET Nome = @_Nome, Profissional = @_Profissional, Data= @_Data, Hora = @_Hora WHERE Id = @_id";

                query.Parameters.AddWithValue("@_Nome", item.NomeAgenda);
                query.Parameters.AddWithValue("@_Profissional", item.ProfissionalAgenda);
                query.Parameters.AddWithValue("@_Data", item.DataAgenda);

                query.Parameters.AddWithValue("@_Hora", item.HoraAgenda);

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

        //excluir agenda pelo id
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



