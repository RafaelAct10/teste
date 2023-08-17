using AutoMapper;
using livrodereceira.comunicacao.Request;
using LivroDeReceira.Exceptions.ExceptionBase;
using LivroDeReceita.Domain.Repositorio;
using LivroDeReceita.infra.AcessoRepositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.aplication.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
    {

        private readonly IUsuariowriteOnlyRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public RegistrarUsuarioUseCase(IUsuariowriteOnlyRepositorio repositorio, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public async Task Executar(RegistrarUsuarioJson requisicao)
        {
            Validar(requisicao);

            var entidade = _mapper.Map<Domain.Entidades.Usuario>(requisicao);
            entidade.Senha = "cript";

           await _repositorio.Adicionar(entidade);
            await _unidadeDeTrabalho.Commit();
        }

        private void Validar (RegistrarUsuarioJson requisicao)
        {
            var validator = new RegsitrarUsuarioValidator();
            var resultado =  validator.Validate(requisicao);

            if (resultado.IsValid) 
            {
                var mensagensDeErro = resultado.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErroDeValidacaoExcepetion(mensagensDeErro);
            }
        }

    }
}
