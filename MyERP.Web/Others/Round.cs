using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace MyERP.Web.Others
{
    public static class Round
    {
        public static Decimal RoundAmount(Decimal amount)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            return Math.Round(amount, 0, MidpointRounding.AwayFromZero);
        }

        public static Decimal RoundUnitAmount(Decimal unitAmount)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            return Math.Round(unitAmount, 0, MidpointRounding.AwayFromZero);
        }

        public static Decimal RoundAmountLCY(Decimal amount)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            return Math.Round(amount, 0, MidpointRounding.AwayFromZero);
        }

        public static Decimal RoundUnitAmountLCY(Decimal unitAmount)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            return Math.Round(unitAmount, 0, MidpointRounding.AwayFromZero);
        }
    }
}