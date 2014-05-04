using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;
using MyERP.DataAccess.Resources;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(NoSeries.NoSeriesMetadata))]
    public partial class NoSeries
    {
        internal sealed class NoSeriesMetadata
        {

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Code { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }

            [Include]
            [Association("NoSeries-client-association", "ClientId", "Id")]
            public Client Client { get; set; }

            [Include]
            [Association("NoSeries-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("NoSeries-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
            [Association("NoSeries-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }
        public NoSeriesStatusType StatusType
        {
            get { return (NoSeriesStatusType)Status; }
            set
            {
                //intentionally empty
            }
        }
    }

    public enum NoSeriesStatusType
    {
        Inactive = 0,
        Active = 1
    }
}
