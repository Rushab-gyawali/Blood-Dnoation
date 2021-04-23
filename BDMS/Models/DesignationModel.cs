using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDMS.Models
{
    public class DesignationModel
    {
        public int SNo { get; set; }
        public string DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string Remarks { get; set; }
        public string IsActive { get; set; }
    }
}