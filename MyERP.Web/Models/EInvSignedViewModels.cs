using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyERP.Web.Models
{

    public class SignXMLDTO
    {
        public string OriginXML { get; set; }
        public string SignedXML { get; set; }
        public string SerialNumber { get; set; }
        public string PIN { get; set; }
        public bool Status { get; set; }
        public long UomId { get; set; }
        public string Exception { get; set; }
    }
}