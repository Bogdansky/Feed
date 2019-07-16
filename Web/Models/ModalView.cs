using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ModalView
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public Helpers.Enums.SeverityEnum Severity { get; set; }
    }
}
