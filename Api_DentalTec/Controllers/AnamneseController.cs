using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("anamneses")]
    [ApiController]
    public class AnamneseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Anamnese> listaAnamneses = new AnamneseDAO().List();

            return Ok(listaAnamneses);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnamneseDTO item)
        {

            var anamnese = new Anamnese();

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
            try
            {
                var dao = new AnamneseDAO();
                anamnese.Id = dao.Insert(anamnese);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Created("", anamnese);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            try
            {
                var anamnese = new AnamneseDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                return Ok(anamnese);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnamneseDTO item)
        {
            try
            {
                var anamnese = new AnamneseDAO().GetById(id);

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

                new AnamneseDAO().Update(anamnese);

                return Ok(anamnese);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
                // return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var anamnese = new AnamneseDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                new AnamneseDAO().Delete(anamnese.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }

}

