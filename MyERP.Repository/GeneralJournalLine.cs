using System.Linq;

namespace MyERP.Repository.MyERPService
{
    public partial class GeneralJournalLine
    {
        
        partial void OnGeneralJournalDocumentIdChanged()
        {
            int _numberOfGeneralJournalLineOfDocument =
                GeneralJournalDocument.GeneralJournalLines.Where(c => c.LineNo%10000 == 0).ToList().Count;
            this.LineNo = _numberOfGeneralJournalLineOfDocument*10000 + 10000;
        }
    }
}
