using LivroDeReceira.Exceptions;
using LivroDeReceita.aplication.UseCases.Usuario.Registrar;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LivroDeReceita.api.Controllers
{
   
    public class WeatherForecastController : LivroDeReceiraController
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get([FromServices] IRegistrarUsuarioUseCase useCase)
        {

            await useCase.Executar(new Comunicacao.Requisicoes.RegistrarUsuarioJson
            {
                Email= "teste@teste.com.br",
                Nome = "teste",
                Senha = "1234565",
                Telefone  = "11 9304302989"
            });

            return Ok();
        }
    }
}