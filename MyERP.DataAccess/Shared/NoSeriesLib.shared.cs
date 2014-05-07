using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Shared
{
    public class NoSeriesLib
    {
        public static void NextNo(string NoSeqName, ref string No)
        {
            var newNo = 0;
#if !SILVERLIGHT
            using (var dbContext = new EntitiesModel())
            {
                using (var connection = dbContext.Connection)
                {
                    string SqlQuery = String.Format("SELECT nextval('{0}')", new object[] { NoSeqName });

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = SqlQuery;
                        newNo = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            int startPos = 0;
            int endPos = 0;
            NoSeriesLib.GetIntegerPos(No, ref startPos, ref endPos);
            NoSeriesLib.ReplaceNoText(ref No, newNo, 0, startPos, endPos);
#endif
        }
        public static void ReplaceNoText(ref string No, int NewNo, int FixedLength, int StartPos, int EndPos)
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
            OldLength = EndPos - StartPos + 1;
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
            No = StartNo + ZeroNo + NewNo + EndNo;
        }

        public static void GetIntegerPos(string No, ref int StartPos, ref int EndPos)
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
