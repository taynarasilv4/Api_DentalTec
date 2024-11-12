using Api_DentalTec.Database;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class ConsultaDAO
    {
        private static ConnectionMysql conn;

        public ConsultaDAO()
        {
            conn = new ConnectionMysql();
        }

        // Inserir uma nova consulta
        public int Insert(Consulta item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = @"
                INSERT INTO consulta 
                (nomepaciente_cons, datanascimento_cons, sexo_cons, endereco_cons, telefone_cons, 
                dataconsulta_cons, horaconsulta_cons, nomemedico_cons, especialidade_cons, 
                motivoconsulta_cons, historicosaude_cons, sintomas_cons, examefisico_cons, 
                diagnostico_cons, tratamentoorientacoes_cons, observacoes_cons) 
                VALUES 
                (@nomepaciente, @datanascimento, @sexo, @endereco, @telefone, @dataconsulta, 
                @horaconsulta, @nomemedico, @especialidade, @motivoconsulta, @historicosaude, 
                @sintomas, @examefisico, @diagnostico, @tratamentoorientacoes, @observacoes)";

                query.Parameters.AddWithValue("@nomepaciente", item.NomePaciente);
                query.Parameters.AddWithValue("@datanascimento", item.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@sexo", item.Sexo);
                query.Parameters.AddWithValue("@endereco", item.Endereco);
                query.Parameters.AddWithValue("@telefone", item.Telefone);
                query.Parameters.AddWithValue("@dataconsulta", item.DataConsulta.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@horaconsulta", item.HoraConsulta);
                query.Parameters.AddWithValue("@nomemedico", item.NomeMedico);
                query.Parameters.AddWithValue("@especialidade", item.Especialidade);
                query.Parameters.AddWithValue("@motivoconsulta", item.MotivoConsulta);
                query.Parameters.AddWithValue("@historicosaude", item.HistoricoSaude);
                query.Parameters.AddWithValue("@sintomas", item.Sintomas);
                query.Parameters.AddWithValue("@examefisico", item.ExameFisico);
                query.Parameters.AddWithValue("@diagnostico", item.Diagnostico);
                query.Parameters.AddWithValue("@tratamentoorientacoes", item.TratamentoOrientacoes);
                query.Parameters.AddWithValue("@observacoes", item.Observacoes);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir consulta: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Listar todas as consultas
        public List<Consulta> List()
        {
            try
            {
                List<Consulta> list = new List<Consulta>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM consulta";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Consulta()
                    {
                        Id = reader.GetInt32("id_cons"),
                        NomePaciente = reader.GetString("nomepaciente_cons"),
                        DataNascimento = reader.GetDateTime("datanascimento_cons"),
                        Sexo = reader.GetString("sexo_cons"),
                        Endereco = reader.GetString("endereco_cons"),
                        Telefone = reader.GetString("telefone_cons"),
                        DataConsulta = reader.GetDateTime("dataconsulta_cons"),
                        HoraConsulta = TimeSpan.Parse(reader.GetString("horaconsulta_cons")),
                        NomeMedico = reader.GetString("nomemedico_cons"),
                        Especialidade = reader.GetString("especialidade_cons"),
                        MotivoConsulta = reader.GetString("motivoconsulta_cons"),
                        HistoricoSaude = reader.GetString("historicosaude_cons"),
                        Sintomas = reader.GetString("sintomas_cons"),
                        ExameFisico = reader.GetString("examefisico_cons"),
                        Diagnostico = reader.GetString("diagnostico_cons"),
                        TratamentoOrientacoes = reader.GetString("tratamentoorientacoes_cons"),
                        Observacoes = reader.GetString("observacoes_cons")
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar consultas: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Buscar consulta pelo ID
        public Consulta? GetById(int id)
        {
            try
            {
                Consulta consulta = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM consulta WHERE id_cons = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.Read())
                {
                    consulta = new Consulta()
                    {
                        Id = reader.GetInt32("id_cons"),
                        NomePaciente = reader.GetString("nomepaciente_cons"),
                        DataNascimento = reader.GetDateTime("datanascimento_cons"),
                        Sexo = reader.GetString("sexo_cons"),
                        Endereco = reader.GetString("endereco_cons"),
                        Telefone = reader.GetString("telefone_cons"),
                        DataConsulta = reader.GetDateTime("dataconsulta_cons"),
                        HoraConsulta = TimeSpan.Parse(reader.GetString("horaconsulta_cons")),
                        NomeMedico = reader.GetString("nomemedico_cons"),
                        Especialidade = reader.GetString("especialidade_cons"),
                        MotivoConsulta = reader.GetString("motivoconsulta_cons"),
                        HistoricoSaude = reader.GetString("historicosaude_cons"),
                        Sintomas = reader.GetString("sintomas_cons"),
                        ExameFisico = reader.GetString("examefisico_cons"),
                        Diagnostico = reader.GetString("diagnostico_cons"),
                        TratamentoOrientacoes = reader.GetString("tratamentoorientacoes_cons"),
                        Observacoes = reader.GetString("observacoes_cons")
                    };
                }

                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar consulta: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Atualizar consulta
        public void Update(Consulta item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = @"
                UPDATE consulta 
                SET nomepaciente_cons = @nomepaciente, datanascimento_cons = @datanascimento, sexo_cons = @sexo, endereco_cons = @endereco, telefone_cons = @telefone, 
                dataconsulta_cons = @dataconsulta, horaconsulta_cons = @horaconsulta, 
                nomemedico_cons = @nomemedico, especialidade_cons = @especialidade, 
                motivoconsulta_cons = @motivoconsulta, historicosaude_cons = @historicosaude, 
                sintomas_cons = @sintomas, examefisico_cons = @examefisico, 
                diagnostico_cons = @diagnostico, tratamentoorientacoes_cons = @tratamentoorientacoes, 
                observacoes_cons = @observacoes 
                WHERE id_cons = @id";

                query.Parameters.AddWithValue("@id", item.Id);
                query.Parameters.AddWithValue("@nomepaciente", item.NomePaciente);
                query.Parameters.AddWithValue("@datanascimento", item.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@sexo", item.Sexo);
                query.Parameters.AddWithValue("@endereco", item.Endereco);
                query.Parameters.AddWithValue("@telefone", item.Telefone);
                query.Parameters.AddWithValue("@dataconsulta", item.DataConsulta.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@horaconsulta", item.HoraConsulta);
                query.Parameters.AddWithValue("@nomemedico", item.NomeMedico);
                query.Parameters.AddWithValue("@especialidade", item.Especialidade);
                query.Parameters.AddWithValue("@motivoconsulta", item.MotivoConsulta);
                query.Parameters.AddWithValue("@historicosaude", item.HistoricoSaude);
                query.Parameters.AddWithValue("@sintomas", item.Sintomas);
                query.Parameters.AddWithValue("@examefisico", item.ExameFisico);
                query.Parameters.AddWithValue("@diagnostico", item.Diagnostico);
                query.Parameters.AddWithValue("@tratamentoorientacoes", item.TratamentoOrientacoes);
                query.Parameters.AddWithValue("@observacoes", item.Observacoes);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Atualização não realizada. Verifique e tente novamente");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar consulta: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Deletar consulta
        public void Delete(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM consulta WHERE id_cons = @id";

                query.Parameters.AddWithValue("@id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("A consulta não foi deletada. Verifique e tente novamente");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar consulta: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

