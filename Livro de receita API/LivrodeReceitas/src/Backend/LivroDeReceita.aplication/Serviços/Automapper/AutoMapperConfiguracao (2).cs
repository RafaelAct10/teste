using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.aplication.Serviços.Automapper
{
    public class AutoMapperConfiguracao : Profile
    {
            public AutoMapperConfiguracao()
        {
            CreateMap<Comunicao.Requisicoes.RegistrarUsuarioJson, Domain.Entidades.Usuario>();
        }
    }
}
