using System.Linq;

namespace MyERP.Repository.MyERPService
{
    public partial class GeneralJournalLine
    {
   
        partial void OnGeneralJournalDocumentIdChanged()
        {
            if (GeneralJournalDocument.GeneralJournalLines.Count == 0)
                this.LineNo = 10000;
            else
                this.LineNo = GeneralJournalDocument.GeneralJournalLines.Where(c => c.LineNo % 10000 == 0).Max(m => m.LineNo) + 10000;
        }
    }
}
