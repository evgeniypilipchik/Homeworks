using System.Text.Json;

namespace Homework_14
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var users = JsonSerializer.Deserialize<User[]>(content, options);

            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine("Name: " + users[i].Name);
                Console.WriteLine("Email: " + users[i].Email);
                Console.WriteLine("Company: " + users[i].Company.Name);
                Console.WriteLine();
            }

            User user = new User()
            {
                Id = 11,
                Name = "New User",
                Username = "newuser",
                Email = "newuser@gmail.com",

                Address = new Address()
                {
                    Street = "userstreet",
                    Suite = "usersuite",
                    City = "usersity",
                    Zipcode = "userzipcode",

                    Geo = new Geo()
                    {
                        Lat = "userlat",
                        Lng = "userlng",
                    }
                },

                Phone = "userphone",
                Website = "userwebsite",

                Company = new Company()
                {
                    Name = "companyname",
                    CatchPhrase = "companycatchphrase",
                    Bs = "companybs"
                }
            };

            var json = JsonSerializer.Serialize(user);
            var newContent = new StringContent(json);
            var newResponse = await client.PostAsync("https://jsonplaceholder.typicode.com/users", newContent);
            Console.WriteLine($"Status code: {(int)newResponse.StatusCode}\n");
        }
    }
}
