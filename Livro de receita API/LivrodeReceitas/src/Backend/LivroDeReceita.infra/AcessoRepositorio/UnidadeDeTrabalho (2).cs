using Org.BouncyCastle.Asn1.Cmp;
using LivroDeReceita.Domain.Repositorio;
using LivroDeReceita.infra.AcessoRepositorio.Repositorio;

namespace LivroDeReceita.infra.AcessoRepositorio
{
    public sealed class UnidadeDeTrabalho : IDisposable, IUnidadeDeTrabalho
    {

        private readonly LivroDeReceitaContext _contexto;
        private bool _disposed;

       public UnidadeDeTrabalho(LivroDeReceitaContext contexto) 
        {
            _contexto = contexto;
        }

        public async Task Commit()
        {
            await _contexto.SaveChangesAsync();
        }

        public void Dispose() 
        {
            Dispose(true);
        }

        private void Dispose(bool disposing) 
        {
            if (!_disposed && disposing ) 
            { 
                _contexto.Dispose();
            }

            _disposed = true;

        }
    }
}
