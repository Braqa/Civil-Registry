using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegjistriCivil.Models
{
    // Implementimi i interfacit
    public class FamilyCertificate : Certificate
    {
        // Properties
        public string Address { get; set; }
        //public List<FamilyMemberWithRelation> FamilyMembers { get; set; }


        // Composition
        public Person Person { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        // Constructor
        public FamilyCertificate()
        {

        }
        //public FamilyCertificate(int id, DateTime documentIssuingDate, string documentIssuedBy, string serialNumber, string referenceNumber, string municipality,
        //    Person person, MaritalStatus maritalStatus, string address, List<FamilyMemberWithRelation> familyMembers)
        //    : base(id, documentIssuingDate, documentIssuedBy, serialNumber, referenceNumber, municipality)
        //{
        //    Person = person;
        //    MaritalStatus = maritalStatus;
        //    Address = address;
        //    FamilyMembers = familyMembers;
        //}
    }
}
