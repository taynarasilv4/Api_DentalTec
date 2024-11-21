using Api_DentalTec.Database;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class PacienteDAO
    {
        private static ConnectionMysql conn;

        public PacienteDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Paciente item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO pacientes (nome_pac, cpf_pac, status_pac, rg_pac, expedidor_pac, datanasc_pac, estadocivil_pac, sexo_pac, email_pac, telefone_pac, cep_pac, cidade_pac, rua_pac, numero_pac, bairro_pac) " +
                                    "VALUES (@nome, @cpf, @status, @rg, @expedidor, @dataNascimento, @estadoCivil, @sexo, @email, @telefone, @cep, @cidade, @rua, @numero, @bairro)";

                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@cpf", item.Cpf);
                query.Parameters.AddWithValue("@status", item.Status);
                query.Parameters.AddWithValue("@rg", item.Rg);
                query.Parameters.AddWithValue("@expedidor", item.Expedidor);
                query.Parameters.AddWithValue("@dataNascimento", item.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@estadoCivil", item.EstadoCivil);
                query.Parameters.AddWithValue("@sexo", item.Sexo);
                query.Parameters.AddWithValue("@email", item.Email);
                query.Parameters.AddWithValue("@telefone", item.Telefone);
                query.Parameters.AddWithValue("@cep", item.Cep);
                query.Parameters.AddWithValue("@cidade", item.Cidade);
                query.Parameters.AddWithValue("@rua", item.Rua);
                query.Parameters.AddWithValue("@numero", item.Numero);
                query.Parameters.AddWithValue("@bairro", item.Bairro);

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

        public List<Paciente> List()
        {
            try
            {
                List<Paciente> list = new List<Paciente>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM pacientes";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Paciente()
                    {
                        Id = reader.GetInt32("id_pac"),
                        Nome = reader.GetString("nome_pac"),
                        Cpf = reader.GetString("cpf_pac"),
                        Status = reader.GetString("status_pac"),
                        Rg = reader.GetString("rg_pac"),
                        Expedidor = reader.GetString("expedidor_pac"),
                        DataNascimento = reader.GetDateTime("datanasc_pac"),
                        EstadoCivil = reader.GetString("estadocivil_pac"),
                        Sexo = reader.GetString("sexo_pac"),
                        Email = reader.GetString("email_pac"),
                        Telefone = reader.GetString("telefone_pac"),
                        Cep = reader.GetString("cep_pac"),
                        Cidade = reader.GetString("cidade_pac"),
                        Rua = reader.GetString("rua_pac"),
                        Numero = reader.GetString("numero_pac"),
                        Bairro = reader.GetString("bairro_pac")
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

        public Paciente? GetById(int id)
        {
            try
            {
                Paciente paciente = new Paciente();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM pacientes WHERE id_pac= @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    paciente.Id = reader.GetInt32("id_pac");
                    paciente.Nome = reader.GetString("nome_pac");
                    paciente.Cpf = reader.GetString("cpf_pac");
                    paciente.Status = reader.GetString("status_pac"); paciente.Rg = reader.GetString("rg_pac");
                    paciente.Expedidor = reader.GetString("expedidor_pac");
                    paciente.DataNascimento = reader.GetDateTime("datanasc_pac");
                    paciente.EstadoCivil = reader.GetString("estadocivil_pac");
                    paciente.Sexo = reader.GetString("sexo_pac");
                    paciente.Email = reader.GetString("email_pac");
                    paciente.Telefone = reader.GetString("telefone_pac");
                    paciente.Cep = reader.GetString("cep_pac");
                    paciente.Cidade = reader.GetString("cidade_pac");
                    paciente.Rua = reader.GetString("rua_pac");
                    paciente.Numero = reader.GetString("numero_pac");
                    paciente.Bairro = reader.GetString("bairro_pac");
                }

                return paciente;
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

        public void Update(Paciente item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE pacientes SET nome_pac = @_nome, cpf_pac = @_cpf, status_pac = @_status, rg_pac = @_rg, expedidor_pac = @_expedidor, datanasc_pac = @_dataNascimento, estadocivil_pac= @_estadoCivil, sexo_pac= @_sexo, email_pac = @_email, telefone_pac = @_telefone, cep_pac = @_cep, cidade_pac = @_cidade, rua_pac = @_rua, numero_pac = @_numero, bairro_pac= @_bairro WHERE id_pac = @_id";

                query.Parameters.AddWithValue("@_nome", item.Nome);
                query.Parameters.AddWithValue("@_cpf", item.Cpf);
                query.Parameters.AddWithValue("@_status", item.Status);
                query.Parameters.AddWithValue("@_rg", item.Rg);
                query.Parameters.AddWithValue("@_expedidor", item.Expedidor);
                query.Parameters.AddWithValue("@_dataNascimento", item.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@_estadoCivil", item.EstadoCivil);
                query.Parameters.AddWithValue("@_sexo", item.Sexo);
                query.Parameters.AddWithValue("@_email", item.Email);
                query.Parameters.AddWithValue("@_telefone", item.Telefone);
                query.Parameters.AddWithValue("@_cep", item.Cep);
                query.Parameters.AddWithValue("@_cidade", item.Cidade);
                query.Parameters.AddWithValue("@_rua", item.Rua);
                query.Parameters.AddWithValue("@_numero", item.Numero);
                query.Parameters.AddWithValue("@_bairro", item.Bairro);
                query.Parameters.AddWithValue("@_id", item.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Atualização não realizada. Verifique e tente novamente");
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
                    throw new Exception("O funcionário não foi excluído. Verifique e tente novamente.");
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

