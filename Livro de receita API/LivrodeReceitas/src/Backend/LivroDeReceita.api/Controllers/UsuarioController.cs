using livrodereceira.comunicacao.Request;
using livrodereceira.comunicacao.Response;
using LivroDeReceita.aplication.UseCases.Usuario.Registrar;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LivroDeReceita.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : LivroDeReceiraController
    {
        [HttpPost]
        [ProducesResponseType(typeof(RespostaUsuarioRegistrado), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarUsuario([FromServices]IRegistrarUsuarioUseCase useCase, 
        [FromQuery] RegistrarUsuarioJson request)

        {
            var resultado = await useCase.Executar(request);

            return Created(string.Empty, resultado);    

        }
    }
}