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
                                                                                       orderby numberSequence.Code
                                                                                       select numberSequence;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<NumberSequence>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void SequenceNextVal(string sequenceName, Action<int> callback)
        {

        }

        public void SaveChanges()
        {
            this.Container.BeginSaveChanges(result =>
            {
                var response = this.Container.EndSaveChanges(result);
                System.Diagnostics.Debug.WriteLine(response);
            }, null);
        }

        public void Update(NumberSequence entity)
        {
            this.Container.UpdateObject(entity);
        }

        public void Delete(NumberSequence entity)
        {
            this.Container.DeleteObject(entity);
        }

        public void AddNew(NumberSequence entity)
        {
            this.Container.AddToNumberSequences(entity);
        }
    }
}
