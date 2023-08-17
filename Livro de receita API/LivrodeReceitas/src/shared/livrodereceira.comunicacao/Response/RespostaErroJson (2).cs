using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrodereceira.comunicacao.Response
{
    public class RespostaErroJson
    {
        public List<string> Mensagem { get; set; }

        public RespostaErroJson(string mensagem)
        {
            Mensagem = new List<string>();
            Mensagem.Add(mensagem);
        }

        public RespostaErroJson(List<string> mensagem)
        {
            Mensagem = mensagem;
        }

        public RespostaErroJson()
        {
        }
    }



}
