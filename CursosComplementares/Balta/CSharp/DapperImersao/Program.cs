using System.Data;
using BaltaDataAcess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace balta
{
    class Program
    {
        static void Main(String[] args)
        {
            const string connectionString
            = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

            #region ADO.NET

            /**

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }

            **/

            #endregion

            #region DAPPER

            using (var connection = new SqlConnection(connectionString))
            {
                // UpdateCategory(connection);
                // ExecuteProcedure(connection)
                // CreateManyCategories(connection);
                ListCategories(connection);
                // CreateCategory(connection);
            }

            #endregion
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();

            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO 
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"{rows} linha(s) inserida(s).");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @Id";

            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend 2022"
            });

            Console.WriteLine($"{rows} registro(s) atualizado(s).");
        }

        static void CreateManyCategories(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Azure DevOps";
            category.Url = "azure";
            category.Description = "Categoria destinada a serviços do Azure";
            category.Order = 4;
            category.Summary = "Azure DO";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria nova";
            category2.Order = 9;
            category2.Summary = "Categoria";
            category2.Featured = true;

            var insertSql = @"INSERT INTO 
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            var rows = connection.Execute(insertSql, new[]{
            new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            },
            new
            {
                category2.Id,
                category2.Title,
                category2.Url,
                category2.Summary,
                category2.Order,
                category2.Description,
                category2.Featured
            }
            });
            Console.WriteLine($"{rows} linha(s) inserida(s).");
        }

        static void ExecuteProcedure(SqlConnection connection)
        {
            var sql = "[spDeleteStudent]";
            var pars = new { StudentId = "a25829da-f008-424e-a600-3edb303766fd" };

            var affectedRows = connection.Execute(
                sql,
                pars,
                commandType: CommandType.StoredProcedure);

            Console.WriteLine($"{affectedRows} linhas afetadas");
        }
    }
}
