﻿using Api_DentalTec.Database;
using Api_DentalTec.Models;
using MySql.Data.MySqlClient;

public class PacienteDAO
{
    private readonly ConnectionMysql _conn;

    public PacienteDAO()
    {
        _conn = new ConnectionMysql();
    }

    // Inserir um novo paciente
    public int Insert(Paciente item)
    {
        try
        {
            using (var query = _conn.Query())
            {
                query.CommandText = "INSERT INTO paciente (nome_pac, cpf_pac, status_pac, rg_pac, expedidor_pac, datanasc_pac, estadocivil_pac, sexo_pac, email_pac, telefone_pac, cep_pac, cidade_pac, rua_pac, numero_pac, bairro_pac) " +
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
            throw new Exception("Erro ao inserir o paciente: " + ex.Message);
        }
        finally
        {
            _conn.Close();
        }
    }

    // Listar todos os pacientes
    public List<Paciente> List()
    {
        try
        {
            List<Paciente> list = new List<Paciente>();

            using (var query = _conn.Query())
            {
                query.CommandText = "SELECT * FROM paciente";
                using (MySqlDataReader reader = query.ExecuteReader())
                {
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
                }
            }

            return list;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar os paciente: " + ex.Message);
        }
        finally
        {
            _conn.Close();
        }
    }

    // Buscar paciente pelo id
    public Paciente? GetById(int id)
    {
        try
        {
            Paciente? paciente = null;

            using (var query = _conn.Query())
            {
                query.CommandText = "SELECT * FROM paciente WHERE id_pac = @_id";
                query.Parameters.AddWithValue("@_id", id);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        paciente = new Paciente()
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
                        };
                    }
                }
            }

            return paciente;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar o paciente: " + ex.Message);
        }
        finally
        {
            _conn.Close();
        }
    }

    // Atualizar um paciente existente
    public void Update(Paciente item)
    {
        try
        {
            using (var query = _conn.Query())
            {
                query.CommandText = "UPDATE paciente SET nome_pac = @_nome, cpf_pac = @_cpf, status_pac = @_status, rg_pac = @_rg, expedidor_pac = @_expedidor, datanasc_pac = @_dataNascimento, estadocivil_pac = @_estadoCivil, sexo_pac = @_sexo, email_pac = @_email, telefone_pac = @_telefone, cep_pac = @_cep, cidade_pac = @_cidade, rua_pac = @_rua, numero_pac = @_numero, bairro_pac = @_bairro WHERE id_pac = @_id";

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

                int rowsAffected = query.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("O paciente não foi atualizado.");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar o paciente: " + ex.Message);
        }
        finally
        {
            _conn.Close();
        }
    }

    // Remover um paciente
    public void Delete(int id)
    {
        try
        {
            using (var query = _conn.Query())
            {
                query.CommandText = "DELETE FROM pacientes WHERE id_pac = @_id";
                query.Parameters.AddWithValue("@_id", id);

                int rowsAffected = query.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("O paciente não foi removido.");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao remover o paciente: " + ex.Message);
        }
        finally
        {
            _conn.Close();
        }
    }
}

