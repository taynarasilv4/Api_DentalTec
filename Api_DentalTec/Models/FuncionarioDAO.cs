using Api_DentalTec.Database;
using Api_DentalTec.Models;
using MySql.Data.MySqlClient;

namespace API___Funcionario__DentalTec_.Models
{
    public class FuncionarioDAO
    {
        private static ConnectionMysql conn;

        public FuncionarioDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Funcionario item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO funcionarios (nome_func, usuario_func, senha_func, cpf_func, status_func, cargo_func, salario_func, rg_func, expedidor_func, datanasc_func, ctps_func, estadocivil_func, sexo_func, dataemissao_func, email_func, telefone_func, cnh_func, cep_func, cidade_func, rua_func, numero_func, bairro_func) " +
                                    "VALUES (@nome, @usuario, @senha, @cpf, @status, @cargo, @salario, @rg, @expedidor, @dataNascimento, @ctps, @estadoCivil, @sexo, @dataEmissao, @email, @telefone, @cnh, @cep, @cidade, @rua, @numero, @bairro)";

                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@usuario", item.Usuario);
                query.Parameters.AddWithValue("@senha", item.Senha);
                query.Parameters.AddWithValue("@cpf", item.Cpf);
                query.Parameters.AddWithValue("@status", item.Status);
                query.Parameters.AddWithValue("@cargo", item.Cargo);
                query.Parameters.AddWithValue("@salario", item.Salario);
                query.Parameters.AddWithValue("@rg", item.Rg);
                query.Parameters.AddWithValue("@expedidor", item.Expedidor);
                query.Parameters.AddWithValue("@dataNascimento", item.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@ctps", item.Ctps);
                query.Parameters.AddWithValue("@estadoCivil", item.EstadoCivil);
                query.Parameters.AddWithValue("@sexo", item.Sexo);
                query.Parameters.AddWithValue("@dataEmissao", item.DataEmissao.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@email", item.Email);
                query.Parameters.AddWithValue("@telefone", item.Telefone);
                query.Parameters.AddWithValue("@cnh", item.Cnh);
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

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionarios";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {
                        Id = reader.GetInt32("id_func"),
                        Nome = reader.GetString("nome_func"),
                        Usuario = reader.GetString("usuario_func"),
                        Senha = reader.GetString("senha_func"),
                        Cpf = reader.GetString("cpf_func"),
                        Status = reader.GetString("status_func"),
                        Cargo = reader.GetString("cargo_func"),
                        Salario = reader.GetDouble("salario_func"),
                        Rg = reader.GetString("rg_func"),
                        Expedidor = reader.GetString("expedidor_func"),
                        DataNascimento = reader.GetDateTime("datanasc_func"),
                        Ctps = reader.GetString("ctps_func"),
                        EstadoCivil = reader.GetString("estadocivil_func"),
                        Sexo = reader.GetString("sexo_func"),
                        DataEmissao = reader.GetDateTime("dataemissao_func"),
                        Email = reader.GetString("email_func"),
                        Telefone = reader.GetString("telefone_func"),
                        Cnh = reader.GetString("cnh_func"),
                        Cep = reader.GetString("cep_func"),
                        Cidade = reader.GetString("cidade_func"),
                        Rua = reader.GetString("rua_func"),
                        Numero = reader.GetString("numero_func"),
                        Bairro = reader.GetString("bairro_func")
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

        public Funcionario? GetById(int id)
        {
            try
            {
                Funcionario funcionario = new Funcionario();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionarios WHERE id_func = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    funcionario.Id = reader.GetInt32("id_func");
                    funcionario.Nome = reader.GetString("nome_func");
                    funcionario.Usuario = reader.GetString("usuario_func");
                    funcionario.Senha = reader.GetString("senha_func");
                    funcionario.Cpf = reader.GetString("cpf_func");
                    funcionario.Status = reader.GetString("status_func");
                    funcionario.Cargo = reader.GetString("cargo_func");
                    funcionario.Salario = reader.GetDouble("salario_func");
                    funcionario.Rg = reader.GetString("rg_func");
                    funcionario.Expedidor = reader.GetString("expedidor_func");
                    funcionario.DataNascimento = reader.GetDateTime("datanasc_func");
                    funcionario.Ctps = reader.GetString("ctps_func");
                    funcionario.EstadoCivil = reader.GetString("estadocivil_func");
                    funcionario.Sexo = reader.GetString("sexo_func");
                    funcionario.DataEmissao = reader.GetDateTime("dataemissao_func");
                    funcionario.Email = reader.GetString("email_func");
                    funcionario.Telefone = reader.GetString("telefone_func");
                    funcionario.Cnh = reader.GetString("cnh_func");
                    funcionario.Cep = reader.GetString("cep_func");
                    funcionario.Cidade = reader.GetString("cidade_func");
                    funcionario.Rua = reader.GetString("rua_func");
                    funcionario.Numero = reader.GetString("numero_func");
                    funcionario.Bairro = reader.GetString("bairro_func");
                }

                return funcionario;
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

        public void Update(Funcionario item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE funcionarios SET nome_func = @_nome, usuario_func = @_usuario, senha_func = @_senha, cpf_func = @_cpf, status_func = @_status, cargo_func = @_cargo, salario_func = @_salario, rg_func = @_rg, expedidor_func = @_expedidor, datanasc_func = @_dataNascimento, ctps_func = @_ctps, estadocivil_func = @_estadoCivil, sexo_func = @_sexo, dataemissao_func = @_dataEmissao, email_func = @_email, telefone_func = @_telefone, cnh_func = @_cnh, cep_func = @_cep, cidade_func = @_cidade, rua_func = @_rua, numero_func = @_numero, bairro_func = @_bairro WHERE id_func = @_id";

                query.Parameters.AddWithValue("@_nome", item.Nome);
                query.Parameters.AddWithValue("@_usuario", item.Usuario);
                query.Parameters.AddWithValue("@_senha", item.Senha);
                query.Parameters.AddWithValue("@_cpf", item.Cpf);
                query.Parameters.AddWithValue("@_status", item.Status);
                query.Parameters.AddWithValue("@_cargo", item.Cargo);
                query.Parameters.AddWithValue("@_salario", item.Salario);
                query.Parameters.AddWithValue("@_rg", item.Rg);
                query.Parameters.AddWithValue("@_expedidor", item.Expedidor);
                query.Parameters.AddWithValue("@_dataNascimento", item.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@_ctps", item.Ctps);
                query.Parameters.AddWithValue("@_estadoCivil", item.EstadoCivil);
                query.Parameters.AddWithValue("@_sexo", item.Sexo);
                query.Parameters.AddWithValue("@_dataEmissao", item.DataEmissao.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@_email", item.Email);
                query.Parameters.AddWithValue("@_telefone", item.Telefone);
                query.Parameters.AddWithValue("@_cnh", item.Cnh);
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
                query.CommandText = "DELETE FROM funcionario WHERE Id = @_id";

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
