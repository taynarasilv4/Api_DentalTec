using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        List<Funcionario> listaFuncionario = new List<Funcionario>();

        public FuncionarioController()
        {
            var funcionario1 = new Funcionario()
            {
                Id = 1,
                Nome = "Sthefany Lorrany Gomes Silva",
                Usuario = "stheeex",
                Senha = "123",
                Cpf = "169.843.643-29",
                Status = "Ativo",
                Cargo = "Desenvolvedora",
                Salario = 1000.00,
                Rg = "4774664958594-1",
                Expedidor = "SSP-RO",
                DataNascimento = new DateTime(2006, 9, 20),
                Ctps = "12345678",
                EstadoCivil = "Solteira",
                Sexo = "Feminino",
                DataEmissao = new DateTime(2024, 9, 15),
                Email = "sthefany@gmail.com",
                Telefone = "(69) 98765-4321",
                Cnh = "1234567890",
                Cep = "76916-000",
                Cidade = "Presidente Médici",
                Rua = "Avenida x",
                Numero = "1234",
                Bairro = "Xyz"

            };

            listaFuncionario.Add(funcionario1);
        }

        [HttpGet] //listagem
        public IActionResult Get()
        {
            return Ok(listaFuncionario);
        }

        [HttpGet("{id}")] //listagem = busca pelo id
        public IActionResult GetById(int id)
        {
            var funcionario = listaFuncionario.Where(item => item.Id == id).FirstOrDefault(); /*fazendo busca do funcionario*/

            if (funcionario == null) /*verifica se existe*/
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        [HttpPost] //criar um registro
        public IActionResult Post([FromBody] FuncionarioDTO item)
        {

            if (!Validations.ValidaCPF.ValidaCpf(item.Cpf))//se false
            {
                return BadRequest("CPF inválido.");
            }

            var contador = listaFuncionario.Count();

            var funcionario = new Funcionario();

            funcionario.Id = contador + 1;
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

            listaFuncionario.Add(funcionario);

            return StatusCode(StatusCodes.Status201Created, funcionario);
        }

        [HttpPut("{id}")] //atualizar um registro
        public IActionResult Put(int id, [FromBody] FuncionarioDTO item)
        {
            var funcionario = listaFuncionario.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca do funcionario*/

            if (funcionario == null) /*verifica se existe*/
            {
                return NotFound();
            }

            if (!Validations.ValidaCPF.ValidaCpf(item.Cpf))//se false
            {
                return BadRequest("CPF inválido.");
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

            return Ok(funcionario);
        }

        [HttpDelete("{id}")] //excluir um registro
        public IActionResult Delete(int id)
        {
            var funcionario = listaFuncionario.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca do funcionario*/

            if (funcionario == null) /*verifica se existe*/
            {
                return NotFound();
            }

            listaFuncionario.Remove(funcionario);

            /*return NoContent(); /*status code 204 e você não retorna nenhuma informação*/
            return Ok(funcionario); /*mostra o funcionario que você excluiu*/
        }
    }
}
