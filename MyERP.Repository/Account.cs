using System;

namespace MyERP.DataAccess
{
    public partial class Account
    {
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        partial void OnCreated()
        {
            this.ArAp = false;
            this.Detail = false;
            this.Level = 0;
            this.RecCreated = DateTime.Now;
            this.RecModified = DateTime.Now;
            this.Status = (int)AccountStatusType.Active;
        }
    }
}
