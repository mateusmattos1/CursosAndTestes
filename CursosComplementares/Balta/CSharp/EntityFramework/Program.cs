using System;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

/* Anotações
   -> Lazy loading: select sem inner join possível em virtuals
   -> Eager loading: modo padrão, nao carrega subitens, devendo usar Include e Select
   -> ThenInclude: serve para pegar colunas do include (subselect) -> não perfomático,
   sendo recomendado usar query manual e mapeamento.
*/

namespace Blog
{
    class Program
    {
        static async Task Main(string[] args) // Método síncrono
        {
            using var context = new BlogDataContext();

            #region Banco

            #region insert
            // var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
            // context.Tags.Add(tag);

            // var user = context.Users.FirstOrDefault();
            // context.Posts.Add(new Post
            // {
            //     Author = user,
            //     Body = "meu artigo",
            //     Category = new Category
            //     {
            //         Name = "Backend",
            //         Slug = "backend"
            //     },
            //     CreateDate = System.DateTime.Now,
            //     Slug = "MEU-RTIGOs",
            //     Summary = "Qualquer coisa..",
            //     Title = "Meu artigo",
            // });
            // context.SaveChanges();
            #endregion

            #region update
            // var tag = context.Tags.FirstOrDefault(x => x.Id == 2);
            // tag.Name = ".NET";
            // tag.Slug = "dotnet";
            // context.Update(tag);
            // context.SaveChanges();
            #endregion

            #region delete
            // var tag = context.Tags.FirstOrDefault(x => x.Id == 2);
            // context.Remove(tag);
            // context.SaveChanges();
            #endregion

            #region consulta
            // var posts = context
            //     .Posts
            //     .AsNoTracking()
            //     .Include(x => x.Author)
            //     .Include(x => x.Category)
            //     // .ThenInclude(x => x...) -> SUBSELECT
            //     .OrderByDescending(x => x.LastUpdateDate)
            //     .ToList();

            // foreach (var post in posts)
            //     Console.Write($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
            #endregion

            #endregion

            #region perfomance

            // Tracking (leitura simples) -> Metadados
            var posts = context.Posts;
            var posts2 = context.Posts.AsNoTracking();

            // Async -> Múltipla tarefas
            // Await -> Aguardar, mas processa paralelamente -> ganho de perfomace
            var posts3 = await context.Posts.FirstOrDefaultAsync(x => x.Id == 1);
            var tags = await context.Users.ToListAsync();
            var metodoAsync = await GetPosts(context);

            // Paginacao de dados
            var posts4 = GetPosts(context, 0, 25);
            var posts5 = GetPosts(context, 25, 50);
            var posts6 = GetPosts(context, 50, 75);

            // Queryes
            var posts7 = context.PostWithTagsCount.ToList();

            #endregion
            Console.WriteLine("Finished");

        }

        public static async Task<List<Post>> GetPosts(BlogDataContext context)
        {
            return await context.Posts.ToListAsync();
        }

        public static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25 /* Paginar dados */)
        {
            var posts = context.Posts.AsNoTracking().Skip(skip).Take(take).ToList();
            return posts;
        }
    }
}