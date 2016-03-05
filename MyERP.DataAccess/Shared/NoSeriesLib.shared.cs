using System;
using System.Linq;
#if SILVERLIGHT
using MyERP.Repositories;
#endif
using System.Security.Cryptography;

namespace MyERP.DataAccess.Shared
{
    public class NoSeriesLib
    {
#if !SILVERLIGHT
        public static string NextNo(Guid noSeqId, string noFormat)
#else
        public static void NextNo(Guid noSeqId, string noFormat, Action<String> callback)
#endif
        {
            int startPos = 0;
            int endPos = 0;
#if !SILVERLIGHT
            var newNo = 0;
            using (var dbContext = new EntitiesModel())
            {
                using (var connection = dbContext.Connection)
                {
                    string noSeqName = (from numberSequence in dbContext.NumberSequences
                        where numberSequence.Id.Equals(noSeqId)
                        select numberSequence.NoSeqName).FirstOrDefault();

                    if (noSeqName == null)
                        newNo = 0;
                    else
                    {
                        string SqlQuery = String.Format("SELECT nextval('{0}')", new object[] {noSeqName});

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = SqlQuery;
                            newNo = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
            }
           
            NoSeriesLib.GetIntegerPos(noFormat, ref startPos, ref endPos);
            return NoSeriesLib.ReplaceNoText(noFormat, newNo, 0, startPos, endPos);
#else
            NumberSequenceRepository NumberSequenceRepository = new NumberSequenceRepository();
            NumberSequenceRepository.SequenceNextVal(noSeqId, newNo => 
            {
                bool IsDigit = false;
                int i;

                if (noFormat != "")
                {
                    i = noFormat.Length - 1;
                    do
                    {
                        IsDigit = noFormat[i] == '0' ? true : false;
                        if (IsDigit)
                        {
                            if (endPos == 0)
                                endPos = i;
                            startPos = i;
                        }
                        i--;
                    }
                    while ((i >= 0) && !(startPos != 0 && !IsDigit));
                }

                callback(NoSeriesLib.ReplaceNoText(noFormat, newNo, 0, startPos, endPos));
            });
#endif
        }

        private static string ReplaceNoText(string No, int NewNo, int FixedLength, int StartPos, int EndPos)
        {
            string StartNo = "";
            string EndNo = "";
            string ZeroNo = "";
            int NewLength;
            int OldLength;

            if (StartPos > 0)
                StartNo = No.Substring(0, StartPos);
            if (EndPos < No.Length - 1)
                EndNo = No.Substring(EndPos + 1);
            NewLength = NewNo.ToString().Length;
            OldLength = EndPos - StartPos;
            if (FixedLength > OldLength)
                OldLength = FixedLength;
            if (OldLength > NewLength)
                ZeroNo = new string('0', OldLength - NewLength);

            if (StartNo.Length + ZeroNo.Length + NewLength + EndNo.Length > 15)
            {
#if !SILVERLIGHT
                //ERROR The number cannot be extended to more than 20 characters.
                //MessageBox.Show("The number cannot be extended to more than 15 characters.");
#else
                
#endif
            }
            return StartNo + ZeroNo + NewNo + EndNo;
        }

        private static void GetIntegerPos(string No, ref int StartPos, ref int EndPos)
        {
            bool IsDigit = false;
            int i;

            StartPos = 0;
            EndPos = 0;
            if (No != "")
            {
                i = No.Length - 1;
                do
                {
                    IsDigit = No[i] == '0' ? true : false;
                    if (IsDigit)
                    {
                        if (EndPos == 0)
                            EndPos = i;
                        StartPos = i;
                    }
                    i--;
                }
                while ((i >= 0) && !(StartPos != 0 && !IsDigit));
            }
        }
    }
}
