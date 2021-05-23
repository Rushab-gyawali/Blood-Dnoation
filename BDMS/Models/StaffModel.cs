using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDMS.Models
{
    public class StaffModel
    {
        public int SNNo { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffMiddleName { get; set; }
        public string StaffLastName { get; set; }
        public string StaffAddress { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string District { get; set; }
        public string Munciplity { get; set; }
        public string City { get; set; }
        public int WardNo { get; set; }
        public string CreatedBy { get; set; }
        public string IsActive { get; set; }
        public string Designation { get; set; }
        public string BloodGroup { get; set; }
        public string DateOfBirth { get; set; }
        public string StaffId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}