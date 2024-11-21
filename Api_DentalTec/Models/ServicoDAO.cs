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

        public int Insert(Servico item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO servico (nomeServico_serv, profissionalEspecializado_serv, descricao_serv) " +
                                    "VALUES (@nomeServico, @profissionalEspecializado, @descricao)";

                query.Parameters.AddWithValue("@nomeServico", item.NomeServico);
                query.Parameters.AddWithValue("@profissionalEspecializado", item.ProfissionalEspecializado);
                query.Parameters.AddWithValue("@descricao", item.Descricao);

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
                _conn.Close();
            }
        }

        public List<Servico> List()
        {
            try
            {
                List<Servico> list = new List<Servico>();
                // List<Servico> list = [];

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM servico";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Servico()
                    {
                        Id = reader.GetInt32("id_serv"),
                        NomeServico = reader.GetString("nomeServico_serv"),
                        ProfissionalEspecializado = reader.GetString("profissionalEspecializado_serv"),
                        Descricao = reader.GetString("descricao_serv")
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
                _conn.Close();
            }
        }

        public Servico? GetById(int id)
        {
            try
            {
                Servico _servico = new Servico();
                // Servico _servico = new();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM servico WHERE id_serv = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _servico.Id = reader.GetInt32("id_serv");
                    _servico.NomeServico = reader.GetString("nomeServico_serv");
                    _servico.ProfissionalEspecializado = reader.GetString("profissionalEspecializado_serv");
                    _servico.Descricao = reader.GetString("descricao_serv");
                }

                return _servico;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(Servico item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE servico SET nomeServico_serv = @_nomeServico, profissionalEspecializado_serv = @_profissionalEspecializado, descricao_serv = @_descricao WHERE id_serv = @_id";

                query.Parameters.AddWithValue("@_nomeServico", item.NomeServico);
                query.Parameters.AddWithValue("@_profissionalEspecializado", item.ProfissionalEspecializado);
                query.Parameters.AddWithValue("@_descricao", item.Descricao);
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
                _conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM servico WHERE id_serv = @_id";

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
                _conn.Close();
            }
        }
    }
}