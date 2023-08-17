using livrodereceira.comunicacao.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceita.api.Controllers
{
     public class LoginController : LivroDeReceiraController
    {
        [HttpPost]
        [ProducesDefaultResponseType(typeof(RespostaLoginJson), StatusCode.status200Ok)]
        public async Task<IActionResult> Login([FromBody] RequisicaoLoginJson requisicao)
        {

            object usacase = null;
            var resposta = await usacase.Executar(requisicao);
            return View();
        }
    }
}
