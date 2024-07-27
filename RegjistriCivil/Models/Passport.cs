using System;
using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.Models
{
    public class Passport : Document
    {
        // Properties
        [Required]
        [RegularExpression("[P][0-9]{8}", ErrorMessage = "Passport number must contain letter 'P' and eight numbers.")]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        [Display(Name = "Eye Color")]
        public string EyeColor { get; set; }

        [Required]
        [Display(Name = "Expire Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }


        public Person Person { get; set; }

        // Constructor
        public Passport()
        {

        }
        public Passport(int id, DateTime documentIssuingDate, string documentIssuedBy, string passportNumber, double height, string eyeColor, Person person, DateTime expireDate)
            : base(id, documentIssuingDate, documentIssuedBy)
        {
            PassportNumber = passportNumber;
            Height = height;
            EyeColor = eyeColor;
            ExpireDate = expireDate;
            Person = person;
        }
    }
}
