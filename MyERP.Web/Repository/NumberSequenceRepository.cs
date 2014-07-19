using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class NumberSequenceRepository 
    {
        public NumberSequenceRepository()
        {
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.Client);
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.Organization);
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.RecCreatedByUser);
        }

        public override IQueryable<NumberSequence> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }

        public void CreateSequenceOfNumberSequence(NumberSequence numberSequence)
        {
            String NoSeqName = "seq_no_series_" + numberSequence.Id.ToString().Replace("-", "_");
            using (var dbContext = new EntitiesModel())
            {
                string sqlQuery = String.Format("CREATE SEQUENCE {0} MINVALUE {1} MAXVALUE {2} START {3};\n",
                    new object[]
                    {NoSeqName, numberSequence.StartingNo, numberSequence.EndingNo, numberSequence.CurrentNo});
                sqlQuery += String.Format("UPDATE number_sequence SET no_seq_name = '{0}' WHERE id = '{1}'",
                    new object[] {NoSeqName, numberSequence.Id.ToString()});

                // 3. Create a new instance of the OACommand class.
                using (var command = dbContext.Connection.CreateCommand())
                {
                    command.CommandText = sqlQuery;
                    command.ExecuteNonQuery();
                    dbContext.SaveChanges();
                }
            }
        }

        public new void AddNew(NumberSequence numberSequence)
        {
            numberSequence = base.AddNew(numberSequence);

            String NoSeqName = "seq_no_series_" + numberSequence.Id.ToString().Replace("-", "_");
            using (var dbContext = new EntitiesModel())
            {
                string sqlQuery = String.Format("CREATE SEQUENCE {0} MINVALUE {1} MAXVALUE {2} START {3};\n",
                    new object[] { NoSeqName, numberSequence.StartingNo, numberSequence.EndingNo, numberSequence.CurrentNo });
                sqlQuery += String.Format("UPDATE number_sequence SET no_seq_name = '{0}' WHERE id = '{1}'",
                    new object[] { NoSeqName, numberSequence.Id.ToString() });

                // 3. Create a new instance of the OACommand class.
                using (var command = dbContext.Connection.CreateCommand())
                {
                    command.CommandText = sqlQuery;
                    command.ExecuteNonQuery();
                }
                
                dbContext.SaveChanges();
            }
        }

        public new void Delete(NumberSequence numberSequence)
        {
            //TODO : check values has transaction => disable delete

            string sqlQuery = String.Format("DROP SEQUENCE {0};", numberSequence.NoSeqName);
            using (var command = dataContext.Connection.CreateCommand())
            {
                command.CommandText = sqlQuery;
                command.ExecuteNonQuery();
            }
            base.Delete(numberSequence); //Delete & SaveChange
        }

        public int GetSequenceNextVal(String key)
        {
            var entity = GetAll().FirstOrDefault(c => c.Id == new Guid(key));
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            int sequenceNextVal = 0;
            // 2. Initialize the sql query.
            string sqlQuery = String.Format("SELECT nextval('{0}')", new object[] { entity.NoSeqName });

            // 3. Create a new instance of the OACommand class.
            using (var command = dataContext.Connection.CreateCommand())
            {
                command.CommandText = sqlQuery;

                // 4. Execute the command and retrieve the scalar values.
                sequenceNextVal = Convert.ToInt32(command.ExecuteScalar());
            }
            entity.CurrentNo = sequenceNextVal;
            Update(entity);

            return sequenceNextVal;
        }
    }

}