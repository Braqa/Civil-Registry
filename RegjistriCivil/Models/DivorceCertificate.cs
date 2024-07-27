using System;

namespace RegjistriCivil.Models
{
    public class DivorceCertificate : Certificate
    {
        // Properties
        public string PlaceOfDivorce { get; set; }
        public DateTime DateOfDivorce { get; set; }


        public MaritalStatus MaritalStatus { get; set; }

        // Composition of Husband
        public Person Husband { get; set; }

        // Composition of Wife
        public Person Wife { get; set; }

        // Constructor
        public DivorceCertificate()
        {

        }

        public DivorceCertificate(int id, DateTime documentIssuingDate, string documentIssuedBy, string serialNumber, string referenceNumber,
            string municipality, string placeOfDivorce, DateTime dateOfDivorce, MaritalStatus maritalStatus, Person husband, Person wife) :
            base(id, documentIssuingDate, documentIssuedBy, serialNumber, referenceNumber, municipality)
        {
            PlaceOfDivorce = placeOfDivorce;
            DateOfDivorce = dateOfDivorce;
            MaritalStatus = maritalStatus;
            Husband = husband;
            Wife = wife;
        }
    }
}
