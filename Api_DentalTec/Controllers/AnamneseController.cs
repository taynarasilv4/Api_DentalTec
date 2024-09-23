using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("anamneses")]
    [ApiController]
    public class AnamneseController : ControllerBase
    {
        List<Anamnese> listaAnamnese = new List<Anamnese>();
        public AnamneseController()
        {
            var anamnese1 = new Anamnese()
            {
                Id = 1,
                Febre = true,
                Tratamento = false,
                Cicatrizacao = true,
                Anestesia = false,
                Drogas = false,
                Diabetes = true,
                Doencas_Familiares = true,
                Doencas_Familiares_Texto = "hipertensão",
                Alergia = false,
                Alergia_Texto = " ",
                Doencas_Art_Reu = false,
                Hipertensao = true,
                Dst = false,
                Doenca_Cardiaca = true,
                Gravidez = false,
                Observacoes = " "
            };

            listaAnamnese.Add(anamnese1);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaAnamnese);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            if (anamnese == null)
            {
                return NotFound();
            }

            return Ok(anamnese);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnamneseDTO item)
        {
            var contador = listaAnamnese.Count();

            var anamnese = new Anamnese();

            anamnese.Id = contador + 1;
            anamnese.Febre = item.Febre;
            anamnese.Tratamento = item.Tratamento;
            anamnese.Cicatrizacao = item.Cicatrizacao;
            anamnese.Anestesia = item.Anestesia;
            anamnese.Drogas = item.Drogas;
            anamnese.Diabetes = item.Diabetes;
            anamnese.Doencas_Familiares = item.Doencas_Familiares;
            anamnese.Doencas_Familiares_Texto = item.Doencas_Familiares_Texto;
            anamnese.Alergia = item.Alergia;
            anamnese.Alergia_Texto = item.Alergia_Texto;
            anamnese.Doencas_Art_Reu = item.Doencas_Art_Reu;
            anamnese.Hipertensao = item.Hipertensao;
            anamnese.Dst = item.Dst;
            anamnese.Doenca_Cardiaca = item.Doenca_Cardiaca;
            anamnese.Gravidez = item.Gravidez;
            anamnese.Observacoes = item.Observacoes;

            listaAnamnese.Add(anamnese);

            return StatusCode(StatusCodes.Status201Created, anamnese);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnamneseDTO item)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            if (anamnese == null)
            {
                return NotFound();
            }

            anamnese.Febre = item.Febre;
            anamnese.Tratamento = item.Tratamento;
            anamnese.Cicatrizacao = item.Cicatrizacao;
            anamnese.Anestesia = item.Anestesia;
            anamnese.Drogas = item.Drogas;
            anamnese.Diabetes = item.Diabetes;
            anamnese.Doencas_Familiares = item.Doencas_Familiares;
            anamnese.Doencas_Familiares_Texto = item.Doencas_Familiares_Texto;
            anamnese.Alergia = item.Alergia;
            anamnese.Alergia_Texto = item.Alergia_Texto;
            anamnese.Doencas_Art_Reu = item.Doencas_Art_Reu;
            anamnese.Hipertensao = item.Hipertensao;
            anamnese.Dst = item.Dst;
            anamnese.Doenca_Cardiaca = item.Doenca_Cardiaca;
            anamnese.Gravidez = item.Gravidez;
            anamnese.Observacoes = item.Observacoes;

            return Ok(anamnese);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            if (anamnese == null)
            {
                return NotFound();
            }

            listaAnamnese.Remove(anamnese);

            return Ok(anamnese);
        }
    }

}
