using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;


namespace LivroDeReceita.aplication.Serviços.Token
{
    public class TokenController
    {
        private const string EmailAlias = "eml";
        private readonly double _tempoDeVidaTokenEmMinutos;
        private readonly string _chaveDeSeguranca;

        public TokenController(double tempoDeVidaTokenEmMinutos, string chaveDeSeguranca)
        {
            _tempoDeVidaTokenEmMinutos = tempoDeVidaTokenEmMinutos;
            _chaveDeSeguranca = chaveDeSeguranca;
        }

        internal object GerarToken(string email)
        {
            throw new NotImplementedException();
        }
    }
    public string GerarToken(string emailDoUsuario)
    {
        var clains = new List<Claim>
            {
                new Claim(EmailAlias, emailDoUsuario),
            };

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clains),
                Expires = DateTime.UtcNow.AddMinutes(_tempoDeVidaTokenEmMinutos),
                SigningCredentials = new SigningCredentials(SimetricKey(), SecurityAlgorithms.HmacSha256Signature)

            };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    public  void ValidarToken(string token)
    {
        var tokenHandler =  new JwtSecurityTokenHandler();

        var paramtetrosValidacao = new TokenValidationParameters
        {
            RequireExpirationTime = true,
            IssuerSigningKey = SimetricKey(),
            ClockSkew =  new TimeSpan(0),
            ValidateIssuer = false,
            ValidateAudience = false,

        };
        tokenHandler.ValidateToken(token, paramtetrosValidacao, out _);
    }

    private SymmetricSecurityKey SimetricKey()
    {
        var symmetrickey = Convert.FromBase64String(_chaveDeSeguranca);
        return new SymmetricSecurityKey(symmetrickey);
    }


}
