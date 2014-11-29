using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyERP.DataAccess.Resources;

namespace MyERP.DataAccess.RudeValidation
{
    public static class NotNullValidators
    {
        public static ValidationResult GuidNotNull(Guid guid,
            ValidationContext validationContext)
        {
            if (guid == Guid.Empty)
            {
                return new ValidationResult(
                    ValidationErrorResources.ValidationErrorRequiredField
                    , new[] {validationContext.MemberName});
            }

            return ValidationResult.Success;
        }
    }
}
