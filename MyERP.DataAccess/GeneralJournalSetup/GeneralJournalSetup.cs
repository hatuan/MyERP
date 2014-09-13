using System.ComponentModel.DataAnnotations;


namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(GeneralJournalSetup.GeneralJournalSetupMetadata))]
    public partial class GeneralJournalSetup
    {
        internal sealed class GeneralJournalSetupMetadata
        {
            [Association("glsetup-general-journal-numbersequence-association", "GeneralJournalNumberSequenceId", "Id")]
            public NumberSequence GeneralJournalNumberSequence { get; set; }

            [Association("glsetup-lcy-currency-association", "LocalCurrencyId", "Id")]
            public Currency LocalCurrency { get; set; }

            [Association("glsetup-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("glsetup-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Association("glsetup-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Association("glsetup-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }
    }
}
