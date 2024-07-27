using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegjistriCivil.Models
{
    public abstract class Document
    {
        // Properties
        public int Id { get; set; }

        [Required]
        [Display(Name = "Issuing Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DocumentIssuingDate { get; set; }

        [Required]
        [Display(Name = "Issued By")]
        public string DocumentIssuedBy { get; set; }

        // Constructor
        public Document()
        {

        }
        public Document(int id, DateTime documentIssuingDate, string documentIssuedBy)
        {
            Id = id;
            DocumentIssuingDate = documentIssuingDate;
            DocumentIssuedBy = documentIssuedBy;
        }

    }

    // Derived Class of Document
    public abstract class Certificate : Document
    {
        // Properties - Basic info of each certificate
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Required]
        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }
        [Required]
        public string Municipality { get; set; }

        // Constructor
        public Certificate()
        {

        }
        public Certificate(int id, DateTime documentIssuingDate, string documentIssuedBy, string serialNumber, string referenceNumber, string municipality)
            : base(id, documentIssuingDate, documentIssuedBy)
        {
            SerialNumber = serialNumber;
            ReferenceNumber = referenceNumber;
            Municipality = municipality;
        }
    }
}
