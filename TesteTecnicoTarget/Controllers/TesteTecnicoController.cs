using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTarget.Service.Interfaces;

namespace TesteTecnicoTarget.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TesteTecnicoController : ControllerBase
    {
        private readonly ITesteTecnicoService _service;

        public TesteTecnicoController(ITesteTecnicoService service)
        {
            _service = service;
        }

        [HttpGet("Desafio 1 - Soma")]
        public IActionResult Soma()
        {
            return Ok(_service.Soma());
        }

        [HttpGet("Desafio 2 - Fibonacci")]
        public IActionResult Fibonacci(int numeroEscolhido)
        {
            return Ok(_service.Fibonacci(numeroEscolhido));
        }
        
        [HttpGet("Desafio 3 - Faturamento Diário")]
        public IActionResult FaturamentoDiario()
        {
            return Ok(_service.FaturamentoDiario());
        }
        
        [HttpGet("Desafio 4 - Faturamento Mensal por Estado em Porcentagem")]
        public IActionResult FaturamentoMensalPorEstadoEmPorcentagem()
        {
            return Ok(_service.FaturamentoMensalPorEstadoEmPorcentagem());
        }
        
        [HttpGet("Desafio 5 - Inverter String")]
        public IActionResult InverterString(string texto)
        {
            return Ok(_service.InverterString(texto));
        }
    }
}
