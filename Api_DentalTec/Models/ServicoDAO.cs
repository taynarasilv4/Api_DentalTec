using Api_DentalTec.Database;
using Api_DentalTec.Models;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class ServicoDAO
    {
        private static ConnectionMysql conn;

        public ServicoDAO()
        {
            conn = new ConnectionMysql();
        }

        //inserir um novo serviço
        public int Insert(Servico item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO servico (Servicoo, ProfissionalEspecializado, Descricao) " +
                                    "VALUES (@Servicoo, @ProfissionalEspecializado, @Descricao)";

                query.Parameters.AddWithValue("@Servicoo", item.Servicoo);
                query.Parameters.AddWithValue("@ProfissionalEspecializado", item.ProfissionalEspecializado);
                query.Parameters.AddWithValue("@Descricao", item.Descricao);

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

        //listar todos os serviços
        public List<Servico> List()
        {
            try
            {
                List<Servico> list = new List<Servico>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM servico";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Servico()
                    {
                        Id = reader.GetInt32("Id"),
                        Servicoo = reader.GetString("Servicoo"),
                        ProfissionalEspecializado = reader.GetString("ProfissionalEspecializado"),
                        Descricao = reader.GetString("Descricao")
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

        //buscar um serviço por id
        public Servico? GetById(int id)
        {
            try
            {
                Servico _servico = new Servico();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM servico WHERE Id = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _servico.Id = reader.GetInt32("Id");
                    _servico.Servicoo = reader.GetString("Servicoo");
                    _servico.ProfissionalEspecializado = reader.GetString("ProfissionalEspecializado");
                    _servico.Descricao = reader.GetString("Descricao");
                }

                return _servico;
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

        //atualizar um serviço existente
        public void Update(Servico item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE servico SET Servicoo = @_Servicoo, ProfissionalEspecializado = @_ProfissionalEspecializado, Descricao = @_Descricao WHERE Id = @_id";

                query.Parameters.AddWithValue("@_Servicoo", item.Servicoo);
                query.Parameters.AddWithValue("@_ProfissionalEspecializado", item.ProfissionalEspecializado);
                query.Parameters.AddWithValue("@_Descricao", item.Descricao);
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

        //excluir serviço pelo id
        public void Delete(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM servico WHERE Id = @_id";

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
