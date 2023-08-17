using LivroDeReceita.infra.Migration;
using LivroDeReceita.infra;
using LivroDeReceita.Domain.Extension;
using LivroDeReceita.api.Filtros;
using LivroDeReceita.aplication.Serviços.Automapper;
using LivroDeReceita.aplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositorio(builder.Configuration);
builder.Services.AddAplication(builder.Configuration);


builder.Services.AddMvc(option => option.Filters.Add(typeof(FiltroDasExcepetions)));

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguracao());

}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

atualizarBaseDeDados();

app.Run();

void atualizarBaseDeDados()
{
   var conexa= builder.Configuration.GetConexao();
   var NomeDataBase = builder.Configuration.GetNomeDataBase();

    DataBase.CriarDataBase(conexa, NomeDataBase);

    app.MigrateBancoDeDados();
}
