using Api_DentalTec.Database;
using Api_DentalTec.Models;
using MySql.Data.MySqlClient;

namespace Api_DentalTec.Models
{
    public class AnamneseDAO
    {
        private static ConnectionMysql conn;

        public AnamneseDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Anamnese item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO anamneses (febre_ana, tratamento_ana, cicatrizacao_ana, anestesia_ana, " +
                    "drogas_ana, diabetes_ana, doencas_familiares_ana, doencas_familiares_texto_ana, alergia_ana, alergia_texto_ana," +
                    "doencas_art_reu_ana, hipertensao_ana, dst_ana, doenca_cardiaca_ana, gravidez_ana, observacoes_ana) " +
                    "VALUES (@febre, @tratamento, @cicatrizacao, @anestesia, @drogas, @diabetes, @doencas_familiares, " +
                    "@doencas_familiares_texto, @alergia, @alergia_texto, @doencas_art_reu, @hipertensao, @dst, @doenca_cardiaca," +
                    "@gravidez, @observacoes)";

                query.Parameters.AddWithValue("@febre", item.Febre);
                query.Parameters.AddWithValue("@tratamento", item.Tratamento);
                query.Parameters.AddWithValue("@cicatrizacao", item.Cicatrizacao);
                query.Parameters.AddWithValue("@anestesia", item.Anestesia);
                query.Parameters.AddWithValue("@drogas", item.Drogas);
                query.Parameters.AddWithValue("@diabetes", item.Diabetes);
                query.Parameters.AddWithValue("@doencas_familiares", item.Doencas_Familiares);
                query.Parameters.AddWithValue("@doencas_familiares_texto", item.Doencas_Familiares_Texto);
                query.Parameters.AddWithValue("@alergia", item.Alergia);
                query.Parameters.AddWithValue("@alergia_texto", item.Alergia_Texto);
                query.Parameters.AddWithValue("@doencas_art_reu", item.Doencas_Art_Reu);
                query.Parameters.AddWithValue("@hipertensao", item.Hipertensao);
                query.Parameters.AddWithValue("@dst", item.Dst);
                query.Parameters.AddWithValue("@doenca_cardiaca", item.Doenca_Cardiaca);
                query.Parameters.AddWithValue("@gravidez", item.Gravidez);
                query.Parameters.AddWithValue("@observacoes", item.Observacoes);

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

        public List<Anamnese> List()
        {
            try
            {
                List<Anamnese> list = new List<Anamnese>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamneses";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Anamnese()
                    {
                        Id = reader.GetInt32("id_ana"),
                        Febre = reader.GetBoolean("febre_ana"),
                        Tratamento = reader.GetBoolean("tratamento_ana"),
                        Cicatrizacao = reader.GetBoolean("cicatrizacao_ana"),
                        Anestesia = reader.GetBoolean("anestesia_ana"),
                        Drogas = reader.GetBoolean("drogas_ana"),
                        Diabetes = reader.GetBoolean("diabetes_ana"),
                        Doencas_Familiares = reader.GetBoolean("doencas_familiares_ana"),
                        Doencas_Familiares_Texto = reader.GetString("doencas_familiares_texto_ana"),
                        Alergia = reader.GetBoolean("alergia_ana"),
                        Alergia_Texto = reader.GetString("alergia_texto_ana"),
                        Doencas_Art_Reu = reader.GetBoolean("doencas_art_reu_ana"),
                        Hipertensao = reader.GetBoolean("hipertensao_ana"),
                        Dst = reader.GetBoolean("dst_ana"),
                        Doenca_Cardiaca = reader.GetBoolean("doenca_cardiaca_ana"),
                        Gravidez = reader.GetBoolean("gravidez_ana"),
                        Observacoes = reader.GetString("observacoes_ana")
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

        public Anamnese? GetById(int id)
        {
            try
            {
                Anamnese _anamnese = new Anamnese();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamneses WHERE id_ana = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _anamnese.Id = reader.GetInt32("id_ana");
                    _anamnese.Febre = reader.GetBoolean("febre_ana");
                    _anamnese.Tratamento = reader.GetBoolean("tratamento_ana");
                    _anamnese.Cicatrizacao = reader.GetBoolean("cicatrizacao_ana");
                    _anamnese.Anestesia = reader.GetBoolean("anestesia_ana");
                    _anamnese.Drogas = reader.GetBoolean("drogas_ana");
                    _anamnese.Diabetes = reader.GetBoolean("diabetes_ana");
                    _anamnese.Doencas_Familiares = reader.GetBoolean("doencas_familiares_ana");
                    _anamnese.Doencas_Familiares_Texto = reader.GetString("doencas_familiares_texto_ana");
                    _anamnese.Alergia = reader.GetBoolean("alergia_ana");
                    _anamnese.Alergia_Texto = reader.GetString("alergia_texto_ana");
                    _anamnese.Doencas_Art_Reu = reader.GetBoolean("doencas_art_reu_ana");
                    _anamnese.Hipertensao = reader.GetBoolean("hipertensao_ana");
                    _anamnese.Dst = reader.GetBoolean("dst_ana");
                    _anamnese.Doenca_Cardiaca = reader.GetBoolean("doenca_cardiaca_ana");
                    _anamnese.Gravidez = reader.GetBoolean("gravidez_ana");
                    _anamnese.Observacoes = reader.GetString("observacoes_ana");
                }

                return _anamnese;
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

        public void Update(Anamnese item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE anamneses SET febre_ana = @_febre, tratamento_ana = @_tratamento, " +
                    "cicatrizacao_ana = @_cicatrizacao, anestesia_ana = @_anestesia, drogas_ana = @_drogas, " +
                    "diabetes_ana = @_diabetes, doencas_familiares_ana = @_doencas_familiares, " +
                    "doencas_familiares_texto_ana = @_doencas_familiares_texto, alergia_ana = @_alergia, alergia_ana = @_alergia," +
                    " alergia_texto_ana = @_alergia_texto, doencas_art_reu_ana = @_doencas_art_reu, hipertensao_ana = @_hipertensao," +
                    "dst_ana = @_dst, doenca_cardiaca_ana = @_doenca_cardiaca, gravidez_ana = @_gravidez, " +
                    "observacoes_ana = @_observacoes WHERE id_ana = @_id";

                query.Parameters.AddWithValue("@_febre", item.Febre);
                query.Parameters.AddWithValue("@_tratamento", item.Tratamento);
                query.Parameters.AddWithValue("@_cicatrizacao", item.Cicatrizacao);
                query.Parameters.AddWithValue("@_anestesia", item.Anestesia);
                query.Parameters.AddWithValue("@_drogas", item.Drogas);
                query.Parameters.AddWithValue("@_diabetes", item.Diabetes);
                query.Parameters.AddWithValue("@_doencas_familiares", item.Doencas_Familiares);
                query.Parameters.AddWithValue("@_doencas_familiares_texto", item.Doencas_Familiares_Texto);
                query.Parameters.AddWithValue("@_alergia", item.Alergia);
                query.Parameters.AddWithValue("@_alergia_texto", item.Alergia_Texto);
                query.Parameters.AddWithValue("@_doencas_art_reu", item.Doencas_Art_Reu);
                query.Parameters.AddWithValue("@_hipertensao", item.Hipertensao);
                query.Parameters.AddWithValue("@_dst", item.Dst);
                query.Parameters.AddWithValue("@_doenca_cardiaca", item.Doenca_Cardiaca);
                query.Parameters.AddWithValue("@_gravidez", item.Gravidez);
                query.Parameters.AddWithValue("@_observacoes", item.Observacoes);


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
                query.CommandText = "DELETE FROM anamneses WHERE id_ana = @_id";

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
    