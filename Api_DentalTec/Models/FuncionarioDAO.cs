using Api_DentalTec.Database;
using Api_DentalTec.Models;
using MySql.Data.MySqlClient;

namespace API___Funcionario__DentalTec_.Models
{
    public class FuncionarioDAO
    {
        private static ConnectionMysql _conn;

        public FuncionarioDAO()
        {
            _conn = new ConnectionMysql();
        }

        // Inserir um novo funcionário
        public int Insert(Funcionario item)
        {
            try
            {
                using (var query = _conn.Query())
                {
                    query.CommandText = "INSERT INTO funcionario (nome_func, usuario_func, senha_func, cpf_func, status_func, cargo_func, salario_func, rg_func, expedidor_func, datanasc_func, ctps_func, estadocivil_func, sexo_func, dataemissao_func, email_func, telefone_func, cnh_func, cep_func, cidade_func, rua_func, numero_func, bairro_func) " +
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
                throw new Exception("Erro ao inserir o funcionário: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Listar todos os funcionários
        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                using (var query = _conn.Query())
                {
                    query.CommandText = "SELECT * FROM funcionario";
                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
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
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os funcionários: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Buscar funcionário pelo id
        public Funcionario? GetById(int id)
        {
            try
            {
                Funcionario funcionario = null;

                using (var query = _conn.Query())
                {
                    query.CommandText = "SELECT * FROM funcionario WHERE id_func = @_id";
                    query.Parameters.AddWithValue("@_id", id);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            funcionario = new Funcionario()
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
                            };
                        }
                    }
                }

                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o funcionário: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Atualizar um funcionário existente
        public void Update(Funcionario item)
        {
            try
            {
                using (var query = _conn.Query())
                {
                    query.CommandText = "UPDATE funcionario SET nome_func = @_nome, usuario_func = @_usuario, senha_func = @_senha, cpf_func = @_cpf, status_func = @_status, cargo_func = @_cargo, salario_func = @_salario, rg_func = @_rg, expedidor_func = @_expedidor, datanasc_func = @_dataNascimento, ctps_func = @_ctps, estadocivil_func = @_estadoCivil, sexo_func = @_sexo, dataemissao_func = @_dataEmissao, email_func = @_email, telefone_func = @_telefone, cnh_func = @_cnh, cep_func = @_cep, cidade_func = @_cidade, rua_func = @_rua, numero_func = @_numero, bairro_func = @_bairro WHERE id_func = @_id";

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

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("O funcionário não foi atualizado.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o funcionário: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Remover um funcionário
        public void Delete(int id)
        {
            try
            {
                using (var query = _conn.Query())
                {
                    query.CommandText = "DELETE FROM funcionario WHERE id_func = @_id";
                    query.Parameters.AddWithValue("@_id", id);

                    int rowsAffected = query.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("O funcionário não foi removido.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o funcionário: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}

