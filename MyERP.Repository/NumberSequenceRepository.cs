using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using MyERP.Infrastructure;
using MyERP.Repository.MyERPService;

namespace MyERP.Repositories
{
    [Export]
    public class NumberSequenceRepository : RepositoryBase
    {
        public DataServiceQuery<NumberSequence> GetNumberSequencesQuery()
        {
            return (DataServiceQuery<NumberSequence>)from numberSequence in Container.NumberSequences
                                              .Expand(c => c.RecCreatedByUser)
                                              .Expand(c => c.RecModifiedByUser)
                                              orderby numberSequence.Code
                                              select numberSequence;
        }

        public void GetNumberSequences(Action<IEnumerable<NumberSequence>> callback)
        {
            DataServiceQuery<NumberSequence> query = (DataServiceQuery<NumberSequence>)from numberSequence in Container.NumberSequences
                                                                                       .Expand(c => c.RecCreatedByUser)
                                                                                       .Expand(c => c.RecModifiedByUser)
                                                                                       where numberSequence.ClientId.Equals(SessionManager.Session["ClientId"])
                                                                                       orderby numberSequence.Code
                                                                                       select numberSequence;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<NumberSequence>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void SequenceNextVal(Guid id, Action<int> callback)
        {
            Uri actionUri = new Uri(this.Container.BaseUri,
                String.Format("NumberSequences(guid'{0}')/SequenceNextVal", id)
                );

            this.Container.BeginExecute<int>(actionUri, result =>
            {
                var response = this.Container.EndExecute<int>(result).FirstOrDefault();
                UIThread.Invoke(() => callback(response));
            }, this.Container);
        }
        
    }
}
