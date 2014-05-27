using System;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using MyERP.Infrastructure;
using MyERP.Repository.MyERPService;


namespace MyERP.Repositories
{
    [Export]
    public class UserRepository : RepositoryBase
    {
        public void GetUsers()
        {

        }

        public void Auth(String name, String password, Action<bool> callback)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(String.Format("http://localhost/MyERP.Web/auth?name={0}&password={1}", name, password)));
            request.Method = "GET";

            request.BeginGetResponse(result =>
            {
                try
                {
                    HttpWebRequest _request = (HttpWebRequest) result.AsyncState;
                    HttpWebResponse _response = (HttpWebResponse) _request.EndGetResponse(result);

                    if (_response.StatusCode == HttpStatusCode.Unauthorized)
                        UIThread.Invoke(() =>callback(false));
                    else
                        UIThread.Invoke(() =>callback(true));
                }
                catch (Exception)
                {
                    UIThread.Invoke(() => callback(false));
                }

            }, request);
        }

        public void SetAuthHeader(String authHeader)
        {
            base.AuthHeader = authHeader;
        }

        public void GetUserByUserNameAndPassword(String userName, String pass)
        {
        }

        public void GetUserByUserName(String name, Action<User> callback)
        {
            DataServiceQuery<User> query = (DataServiceQuery<User>) from user in Container.Users
                                           where user.Name == name
                                           select user;
            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<User>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() =>callback(response.FirstOrDefault()));
            }, query);
        }

        //private async Task GetGizmosSvcAsync()
        //{
        //    var gizmoService = new GizmoService();
        //    GizmosGridView.DataSource = await gizmoService.GetGizmosAsync();
        //    GizmosGridView.DataBind();
        //}
    }
}
