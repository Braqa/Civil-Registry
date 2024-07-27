using System;
using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.Models
{
    public class DeathCertificate : Certificate
    {
        // Properties
        [Display(Name = "Date of Death")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfDeath { get; set; }

        [Required]
        [Display(Name = "Place of Death")]
        public string PlaceOfDeath { get; set; }


        // Composition Subject
        public Person Person { get; set; }

        // Composition Parents
        public virtual FamilyMemberBase Father { get; set; }
        public int? FatherId { get; set; }

        public virtual FamilyMemberBase Mother { get; set; }
        public int? MotherId { get; set; }

        public virtual FamilyMemberBase Spouse { get; set; }
        public int? SpouseId { get; set; }

        // Composition
        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        // Constructor
        public DeathCertificate()
        {

        }
        public DeathCertificate(int id, DateTime documentIssuingDate, string documentIssuedBy, string serialNumber, string referenceNumber, string municipality, Person person,
            FamilyMemberBase father, FamilyMemberBase mother, FamilyMemberBase spouse, MaritalStatus maritalStatus, DateTime dateOfDeath, string placeOfDeath)
            : base(id, documentIssuingDate, documentIssuedBy, serialNumber, referenceNumber, municipality)
        {
            Person = person;
            Father = father;
            Mother = mother;
            Spouse = spouse;
            MaritalStatus = maritalStatus;
            DateOfDeath = dateOfDeath;
            PlaceOfDeath = placeOfDeath;
        }
    }
}
