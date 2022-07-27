using System;
using Microsoft.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            // ReadUsers();
            // ReadUser(1);
            // CreateUser();
            // UpdateUser(1);
            // DeleteUser(1);
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();
                Console.WriteLine("Todos os usuários:");
                foreach (var user in users)
                {
                    Console.WriteLine(" - " + user.Name);
                }
                Console.WriteLine("");
            }
        }

        public static void ReadUser(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                Console.WriteLine("Usuário com Id " + id + ":");
                var users = connection.Get<User>(id);

                Console.WriteLine(" - " + users.Name);
                Console.WriteLine("");
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe balta.io",
                Email = "mateus@gmail.com",
                Image = "https://aidsdas.com",
                Name = "Mateus de Mattos",
                PasswordHash = "HASH",
                Slug = "Equipe SEFAZ"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);

                Console.WriteLine("Usuário cadastrado com sucesso");
                Console.WriteLine("");
            }
        }

        public static void UpdateUser(int id)
        {
            var user = new User()
            {
                Id = id,
                Bio = "Equipe balta.io",
                Email = "andre@gmail.com",
                Image = "https://baltacom",
                Name = "Andre Baltieri",
                PasswordHash = "HASH",
                Slug = "Equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);

                Console.WriteLine("Usuário atualizado com sucesso");
                Console.WriteLine("");
            }
        }

        public static void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(id);
                connection.Delete<User>(user);

                Console.WriteLine("Usuário deletado com sucesso");
                Console.WriteLine("");
            }
        }
    }
}