using System;
using MyERPApp.MyERPService;

namespace MyERPApp
{
    public class MyERPContext : MyERPModel
    {
        public MyERPContext() : base(new Uri("http://localhost:1602/MyERPService.svc", UriKind.Absolute)) { }

    }
}
