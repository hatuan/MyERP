using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace MyERP.Web.Others
{
    public static class Round
    {

        public static Decimal RoundAmountLCY(Decimal Amount)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            return Math.Round(Amount, 0, MidpointRounding.AwayFromZero);
        }

        public static Decimal RoundUnitAmountLCY(Decimal UnitAmount)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            return Math.Round(UnitAmount, 0, MidpointRounding.AwayFromZero);
        }
    }
}