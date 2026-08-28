using System;
using System.Collections.Generic;
using System.Data;

namespace Acme.Analytics
{
    public class MemberExport
    {
        const string ColEmail = "email_address";
        const string CssEmail = "email_address";
        const string MetricName = "phone_number";
        const string DefaultSender = "maria@example.com";
        const int RetryLimit = 3;

        public string BuildSelect(string tableName, List<string> fieldList)
        {
            return $"SELECT {string.Join(",", fieldList)} FROM {tableName}";
        }

        public string Export(IDbConnection db, IDataReader rs, Element el, Metrics metrics, ILogger log)
        {
            var sql = BuildSelect("member_profile",
                new List<string> { "email_address", "phone_number", "date_of_birth", "created_at" });
            var email = rs.GetString(rs.GetOrdinal(ColEmail));
            el.AddClass(CssEmail);
            metrics.Increment(MetricName);
            log.Info("Sending email to member");
            return email;
        }
    }
}
