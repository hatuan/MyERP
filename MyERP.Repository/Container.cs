using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MyERP.Infrastructure;

namespace MyERP.Repository.MyERPService
{
    public partial class Container
    {
        public void SequenceNextVal(Guid id, Action<int> callback)
        {
            Uri actionUri = new Uri(this.BaseUri,
                String.Format("NumberSequences(guid'{0}')/SequenceNextVal", id)
                );

            this.BeginExecute<int>(actionUri, result =>
            {
                var response = this.EndExecute<int>(result).FirstOrDefault();
                UIThread.Invoke(() => callback(response));
            }, this);
        }
    }
}
