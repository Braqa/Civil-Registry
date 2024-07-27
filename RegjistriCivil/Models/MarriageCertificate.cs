using System;
using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.Models
{
    public class MarriageCertificate : Certificate
    {
        // Properties
        [Required]
        [Display(Name = "Place of Marriage")]
        public string PlaceOfMarriage { get; set; }

        [Required]
        [Display(Name = "Date of Marriage")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfMarriage { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        public virtual Person Husband { get; set; }
        public int? HusbandId { get; set; }

        public virtual FamilyMemberBase HusbandFather { get; set; }
        public int? HusbandFatherId { get; set; }

        public virtual FamilyMemberBase HusbandMother { get; set; }
        public int? HusbanMotherId { get; set; }

        public virtual Person Wife { get; set; }
        public int? WifeId { get; set; }

        public virtual FamilyMemberBase WifeFather { get; set; }
        public int? WifeFatherId { get; set; }

        public virtual FamilyMemberBase WifeMother { get; set; }
        public int? WifeMotherId { get; set; }

        // Constructor
        public MarriageCertificate()
        {

        }
        public MarriageCertificate(int id, DateTime documentIssuingDate, string documentIssuedBy, string serialNumber, string referenceNumber, string municipality, string placeOfMarriage,
            DateTime dateOfMarriage, Person husband, FamilyMemberBase husbandFather, FamilyMemberBase husbandMother, Person wife, FamilyMemberBase wifeFather, FamilyMemberBase wifeMother)
            : base(id, documentIssuingDate, documentIssuedBy, serialNumber, referenceNumber, municipality)
        {
            PlaceOfMarriage = placeOfMarriage;
            DateOfMarriage = dateOfMarriage;
            Husband = husband;
            HusbandFather = husbandFather;
            HusbandMother = husbandMother;
            Wife = wife;
            WifeFather = wifeFather;
            WifeMother = wifeMother;
        }
    }
}
