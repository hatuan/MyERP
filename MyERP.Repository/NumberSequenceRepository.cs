using System;
using System.ComponentModel.Composition;

namespace MyERP.Repositories
{
    [Export]
    public class NumberSequenceRepository : RepositoryBase
    {
        public void SequenceNextVal(string sequenceName, Action<int> callback)
        {

        }
    }
}
