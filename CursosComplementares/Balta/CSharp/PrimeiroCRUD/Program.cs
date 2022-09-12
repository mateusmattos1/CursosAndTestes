/* Anotações da Seção 1 
// Exe em execução no computador ouvindo uma porta do computador esperando requisicoes

// Construção da aplicação web
var builder = WebApplication.CreateBuilder(args);

// Construção de fato
var app = builder.Build();

// Exemplo de requisicao, método de obter
// Mapear -> a barra se refere a URL sem nada (conceito de rotas)
app.MapGet("/", () =>
{
    return Results.Ok("Hello world");
});

// Podemos passar uma informacao na requisicao
app.MapGet("/name/{nome}", (string nome) =>
{
    return Results.Ok($"Hello {nome}");
});

// Pode passar o mesmo endereço
app.MapPost("/", (User user) => { return Results.Ok(user); });

app.MapGet("/hello", () => "Hello World!"); // -> Função anônima: sem nome retornando string
app.MapGet("/banana", () => "Banana é muito bom");

// Colocando em andamento
app.Run();

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
}
*/
using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
