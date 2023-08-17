using LivroDeReceita.Domain.Entidades;
using LivroDeReceita.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.infra.AcessoRepositorio.Repositorio
{
    public class UsuarioRepositorio : IUsuarioReadOnlyRepositorio, IUsuariowriteOnlyRepositorio
    {

        private readonly LivroDeReceitaContext _contexto;
        public UsuarioRepositorio(LivroDeReceitaContext context)
        {
            _contexto = context;
        }
        public async Task Adicionar(Usuario usuario)
        {
           await _contexto.Usuarios.AddAsync(usuario);
        }

        public async Task<bool> ExisteUsuarioComEmail(string email)
        {
            return await _contexto.Usuarios.AnyAsync(c => c.Email.Equals(email));
        }

        public async Task<Usuario> Login(string username, string password)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(c => c.Email.Equals(username) && c.Senha.Equals(password));
        }
    }
}
