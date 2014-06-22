using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    public enum AccountStatusType : byte
    {
        [Display(Name = "InActive")]
        Inactive = 0,
        [Display(Name = "Active")]
        Active = 1
    }
}
