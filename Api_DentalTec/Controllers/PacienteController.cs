using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{

    [Route("pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        List<Paciente> listaPaciente = new List<Paciente>();

        public PacienteController()
        {
            var paciente1 = new Paciente()
            {
                Id = 1,
                Nome = "Natalia Pereira da Silva",
                Cpf = "000.000.000-00",
                Status = "Ativo",
                Rg = "11111111111-1",
                Expedidor = "SPP-RO",
                DataNascimento = new DateTime(2006, 5, 6),
                EstadoCivil = "Solteira",
                Sexo = "Feminino",
                Email = "natalia@gmail.com",
                Telefone = "(69) 99999-9999",
                Cep = "76916-000",
                Cidade = "Presidente Médici",
                Rua = "Avenida Flor",
                Numero = "4321",
                Bairro = "Flores de Verão"

            };

            listaPaciente.Add(paciente1);
        }

        [HttpGet] //listagem
        public IActionResult Get()
        {
            return Ok(listaPaciente);
        }

        [HttpGet("{id}")] //listagem = busca pelo id
        public IActionResult GetById(int id)
        {
            var paciente = listaPaciente.Where(item => item.Id == id).FirstOrDefault(); /*fazendo busca*/
            if (paciente == null) /*verifica se existe*/
            {
                return NotFound();
            }

            return Ok(paciente);
        }


        [HttpPost] //criar um registro
        public IActionResult Post([FromBody] PacienteDTO item)
        {

            if (!Validations.ValidaCPF.ValidaCpf(item.Cpf))//se false
            {
                return BadRequest("CPF inválido.");
            }

            var contador = listaPaciente.Count();

            var paciente = new Paciente();

            paciente.Id = contador + 1;
            paciente.Nome = item.Nome;
            paciente.Cpf = item.Cpf;
            paciente.Status = item.Status;
            paciente.Rg = item.Rg;
            paciente.Expedidor = item.Expedidor;
            paciente.DataNascimento = item.DataNascimento;
            paciente.EstadoCivil = item.EstadoCivil;
            paciente.Sexo = item.Sexo;
            paciente.Email = item.Email;
            paciente.Telefone = item.Telefone;
            paciente.Cep = item.Cep;
            paciente.Cidade = item.Cidade;
            paciente.Rua = item.Rua;
            paciente.Numero = item.Numero;
            paciente.Bairro = item.Bairro;

            listaPaciente.Add(paciente);

            return StatusCode(StatusCodes.Status201Created, paciente);
        }

        [HttpPut("{id}")] //atualizar um registro
        public IActionResult Put(int id, [FromBody] PacienteDTO item)
        {
            var paciente = listaPaciente.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca*/

            if (paciente == null) /*verifica se existe*/
            {
                return NotFound();
            }

            if (!Validations.ValidaCPF.ValidaCpf(item.Cpf))//se false
            {
                return BadRequest("CPF inválido.");
            }

            paciente.Nome = item.Nome;
            paciente.Cpf = item.Cpf;
            paciente.Status = item.Status;
            paciente.Rg = item.Rg;
            paciente.Expedidor = item.Expedidor;
            paciente.DataNascimento = item.DataNascimento;
            paciente.EstadoCivil = item.EstadoCivil;
            paciente.Sexo = item.Sexo;
            paciente.Email = item.Email;
            paciente.Telefone = item.Telefone;
            paciente.Cep = item.Cep;
            paciente.Cidade = item.Cidade;
            paciente.Rua = item.Rua;
            paciente.Numero = item.Numero;
            paciente.Bairro = item.Bairro;

            return Ok(paciente);
        }

        [HttpDelete("{id}")] //excluir um registro
        public IActionResult Delete(int id)
        {
            var paciente = listaPaciente.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca*/

            if (paciente == null) /*verifica se existe*/
            {
                return NotFound();
            }

            listaPaciente.Remove(paciente);

            /*return NoContent(); /*status code 204 e você não retorna nenhuma informação*/
            return Ok(paciente);
        }
    }
}

