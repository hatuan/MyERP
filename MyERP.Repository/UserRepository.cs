using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace MyERP.Repositories
{
    [Export]
    public class UserRepository : RepositoryBase
    {
        public void GetUsers()
        {

        }

        public void GetUserByUserNameAndPassword(String userName, String pass)
        {
            //using (HttpClientHandler handler = new HttpClientHandler())
            //{
            //    handler.Credentials = new NetworkCredential("username", "password");

            //    HttpClient client = new HttpClient(handler);
            //    Container.Credentials = new NetworkCredential(userName, pass);
            //    var task = client.GetAsync("https://localhost:44300/api/values");
            //    if (task.Result.StatusCode == HttpStatusCode.Unauthorized)
            //    {
            //        Console.WriteLine("wrong credentials");
            //    }
            //    else
            //    {
            //        task.Result.EnsureSuccessStatusCode();
            //        Console.WriteLine(task.Result.Content.ReadAsAsync<string>().Result);
            //    }

            //    Container.Credentials = new NetworkCredential(userName, pass);
            //    var task = Container.Users.Where(u => u.Name == userName);

            //}

            
            Container.Credentials = new NetworkCredential(userName, pass);
            var task = Container.Users.Where(u => u.Name == userName);
        }

        public void GetUserByUserName(String userName)
        {

        }
    }
}
