using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegjistriCivil.Models
{
    public class IdCard : Document
    {
        // Properties
        [Required]
        [Display(Name = "Id Card Number")]
        public string IdCardNumber { get; set; }
        [Required]
        public string Residence { get; set; }

        [Display(Name = "Expire Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        public Person Person { get; set; }

        // Constructor
        public IdCard()
        {

        }
        public IdCard(int id, DateTime documentIssuingDate, string documentIssuedBy, Person person, string idCardNumber, string residence, DateTime expireDate)
            : base(id, documentIssuingDate, documentIssuedBy)
        {
            Person = person;
            IdCardNumber = idCardNumber;
            Residence = residence;
            ExpireDate = expireDate;
        }

        //public string ToShortString()
        //{
        //    return $"Name: {Person.Name} {Person.LastName}, DoB: {Person.DateOfBirth.ToShortDateString()}, ID: {Person.PersonalNumber}";
        //}
    }
}
