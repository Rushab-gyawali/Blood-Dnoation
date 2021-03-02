using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDMS.Models
{
    public class DonorModel
    {
        public int Donorid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string District { get; set; }
        public string Munciplity { get; set; }
        public string City { get; set; }
        public int WardNo { get; set; }
        public string CreatedBy { get; set; }
        public string IsActive { get; set; }
    }
}