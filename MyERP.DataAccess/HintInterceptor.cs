using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public class HintInterceptor : DbCommandInterceptor
    {
        private static readonly Regex _tableAliasRegex = new Regex(@"(?<tableAlias>AS \[Extent\d+\](?! WITH \(*HINT*\)))", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        [ThreadStatic] public static string HintValue;

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (!String.IsNullOrWhiteSpace(HintValue))
            {
                command.CommandText = _tableAliasRegex.Replace(command.CommandText, "${tableAlias} WITH (*HINT*)");
                command.CommandText = command.CommandText.Replace("*HINT*", HintValue);
            }

            HintValue = String.Empty;
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (!String.IsNullOrWhiteSpace(HintValue))
            {
                command.CommandText = _tableAliasRegex.Replace(command.CommandText, "${tableAlias} WITH (*HINT*)");
                command.CommandText = command.CommandText.Replace("*HINT*", HintValue);
            }

            HintValue = String.Empty;
        }
    }
}
