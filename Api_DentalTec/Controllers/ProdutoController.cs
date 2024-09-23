using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    public class ProdutoController : ControllerBase
    {
            List<Produto> listaProduto = new List<Produto>();
            public ProdutoController()
            {
                var produto1 = new Produto();
                {
                    produto1.Nomeproduto = "Anestésico tópico";
                    produto1.CodigoBarra = 00004000049999020;
                    produto1.DataFabricacao = new DateTime(2024, 09, 16);
                    produto1.DataValidade = new DateTime(2026, 09, 16);
                    produto1.Id = 1;
                    produto1.Valor = 150;

                }
                listaProduto.Add(produto1);
            }

            [HttpGet] //listagem
            public IActionResult Get()
            {
                return Ok(listaProduto);
            }

            [HttpGet("{id}")] //listagem = busca pelo id
            public IActionResult GetById(int id)
            {
                var produto = listaProduto.Where(item => item.Id == id).FirstOrDefault(); /*fazendo busca do produto*/

                if (produto == null) /*verifica se existe*/
                {
                    return NotFound();
                }

                return Ok(produto);
            }

            [HttpPost] //criar um registro
            public IActionResult Post([FromBody] ProdutoDTO item)
            {

                var contador = listaProduto.Count();

                var produto = new Produto();


                produto.Nomeproduto = item.Nomeproduto;
                produto.CodigoBarra = item.CodigoBarra;
                produto.DataFabricacao = item.DataFabricacao;
                produto.DataValidade = item.DataValidade;
                produto.Id = contador + 1;
                produto.Valor = item.Valor;


                listaProduto.Add(produto);

                return StatusCode(StatusCodes.Status201Created, produto);
            }

            [HttpPut("{id}")] //atualizar um registro
            public IActionResult Put(int id, [FromBody] ProdutoDTO item)
            {
                var produto = listaProduto.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca do produto*/

                if (produto == null) /*verifica se existe*/
                {
                    return NotFound();
                }

                produto.Nomeproduto = item.Nomeproduto;
                produto.CodigoBarra = item.CodigoBarra;
                produto.DataFabricacao = item.DataFabricacao;
                produto.DataValidade = item.DataValidade;
                produto.Id = item.Id;
                produto.Valor = item.Valor;

                return Ok(produto);
            }

            [HttpDelete("{id}")] //excluir um registro
            public IActionResult Delete(int id)
            {
                var produto = listaProduto.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca de produto*/

                if (produto == null) /*verifica se existe*/
                {
                    return NotFound();
                }

                listaProduto.Remove(produto);
                return Ok(produto); /*mostra o produto que você excluiu*/
            }

    }
}
