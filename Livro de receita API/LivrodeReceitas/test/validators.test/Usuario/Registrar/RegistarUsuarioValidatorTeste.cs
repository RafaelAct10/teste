using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace validators.test.Usuario.Registrar
{
    public class RegistarUsuarioValidatorTeste
    {
        [Fact]
        public void validar_Erro_Nome_Vazio()
        {
            var validator = new RegsitrarUsuarioValidator();

            var requisicao = new RegistrarUsuarioJson
            {
                Email = "teste@teste.com.br",
                Nome = "teste",
                Senha = "1234567",
                Telefone = "teste"
            };

            var resultado =  validator.Validar(requisicao);

            resultado.isValid.Should().NotBeNull();
            resultado.Email.Should().Be();
            resultado.Nome.Should().Be();
            resultado = validator.Validar(requisicao); resultado.isValid.Should().NotBeNull(); resultado.Email.Should().Be();

        }
    }
}
