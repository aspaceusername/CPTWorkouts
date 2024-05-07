using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CPTWorkouts.Models;
using CPTWorkouts.Services.MBWayPagamentos;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CPTWorkouts.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIMBWAY : ControllerBase
    {
        

        [HttpGet]
        [Route("CreatePagamentoMB")]
       public async Task<IActionResult> CreatePagamentoMB([FromQuery] decimal preco, [FromQuery] string telemovel)
        {
            var respostaJson = await MBWayPagamentos.MBWayPay(preco, telemovel);
            MBWay resposta = JsonSerializer.Deserialize<MBWay>(respostaJson);
            resposta.EstadoMbWay = EstadoMbWay.Pendente;
            resposta.customerPhone = telemovel;
            resposta.amount = preco;
            //criar na base de dados algo do tipo MBWay que guarde a transactionStatus, transactionID e a reference.
            //A ideia é através da transactionID conseguir "recriar" a compra.
            //Utilizar Fatura.cs

            return Ok("");
        }
    }
}
