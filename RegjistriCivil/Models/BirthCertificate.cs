using System;
using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.Models
{
    public class BirthCertificate : Certificate
    {
        // Composition
        public Person Person { get; set; }

        public virtual FamilyMember FatherDetails { get; set; }
        public int? FatherDetailsId { get; set; }

        public virtual FamilyMember MotherDetails { get; set; }
        public int? MotherDetailsId { get; set; }

        // Constructor
        public BirthCertificate()
        {

        }
        public BirthCertificate(int id, DateTime documentIssuingDate, string documentIssuedBy, string serialNumber, string referenceNumber, string municipality,
            Person person, FamilyMember fatherDetails, FamilyMember motherDetails)
            : base(id, documentIssuingDate, documentIssuedBy, serialNumber, referenceNumber, municipality)
        {
            Person = person;
            FatherDetails = fatherDetails;
            MotherDetails = motherDetails;
        }

    }
}
