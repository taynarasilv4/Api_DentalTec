using API___Funcionario__DentalTec_.Models;
using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("funcionarios")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Funcionario> listaFuncionarios = new FuncionarioDAO().List();
                return Ok(listaFuncionarios);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var funcionario = new FuncionarioDAO().GetById(id);

                if (funcionario == null)
                {
                    return NotFound();
                }

                return Ok(funcionario);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] FuncionarioDTO item)
        {
            var funcionario = new Funcionario
            {
                Nome = item.Nome,
                Usuario = item.Usuario,
                Senha = item.Senha,
                Cpf = item.Cpf,
                Status = item.Status,
                Cargo = item.Cargo,
                Salario = item.Salario,
                Rg = item.Rg,
                Expedidor = item.Expedidor,
                DataNascimento = item.DataNascimento,
                Ctps = item.Ctps,
                EstadoCivil = item.EstadoCivil,
                Sexo = item.Sexo,
                DataEmissao = item.DataEmissao,
                Email = item.Email,
                Telefone = item.Telefone,
                Cnh = item.Cnh,
                Cep = item.Cep,
                Cidade = item.Cidade,
                Rua = item.Rua,
                Numero = item.Numero,
                Bairro = item.Bairro
            };

            try
            {
                var dao = new FuncionarioDAO();
                funcionario.Id = dao.Insert(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FuncionarioDTO item)
        {
            try
            {
                var funcionario = new FuncionarioDAO().GetById(id);

                if (funcionario == null)
                {
                    return NotFound();
                }

                funcionario.Nome = item.Nome;
                funcionario.Usuario = item.Usuario;
                funcionario.Senha = item.Senha;
                funcionario.Cpf = item.Cpf;
                funcionario.Status = item.Status;
                funcionario.Cargo = item.Cargo;
                funcionario.Salario = item.Salario;
                funcionario.Rg = item.Rg;
                funcionario.Expedidor = item.Expedidor;
                funcionario.DataNascimento = item.DataNascimento;
                funcionario.Ctps = item.Ctps;
                funcionario.EstadoCivil = item.EstadoCivil;
                funcionario.Sexo = item.Sexo;
                funcionario.DataEmissao = item.DataEmissao;
                funcionario.Email = item.Email;
                funcionario.Telefone = item.Telefone;
                funcionario.Cnh = item.Cnh;
                funcionario.Cep = item.Cep;
                funcionario.Cidade = item.Cidade;
                funcionario.Rua = item.Rua;
                funcionario.Numero = item.Numero;
                funcionario.Bairro = item.Bairro;

                new FuncionarioDAO().Update(funcionario);

                return Ok(funcionario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var funcionario = new FuncionarioDAO().GetById(id);

                if (funcionario == null)
                {
                    return NotFound();
                }

                // Chame o método Delete da DAO
                new FuncionarioDAO().Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Erro ao excluir o funcionário: {e.Message}");
            }
        }
    }
}

