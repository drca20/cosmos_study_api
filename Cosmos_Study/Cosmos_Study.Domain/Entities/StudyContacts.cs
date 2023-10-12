using Cosmos_Study.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Domain.Entities
{
    public class StudyContacts : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Gender { get; set; }
        public string PreferedLanguage { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsOpttoEmail { get; set; }
        public bool IsOpttoMobile { get; set; }
        public string WeightUnit { get; set; }
        public string HeightUnit { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
        public string StudyUniqueId { get; set; }
        public int StudyId { get; set; }
        public string SiteId { get; set; }
        public Study Study { get; set; }
    }
}
