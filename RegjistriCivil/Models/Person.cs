using System;
using System.ComponentModel.DataAnnotations;
using RegjistriCivil.Utilities;

namespace RegjistriCivil.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [MaxWords(2, ErrorMessage = "There are too many words in {0}")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Personal number must contain only ten numbers.")]
        [Display(Name = "Personal No")]
        public int PersonalNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string Nationality { get; set; }

    }

    public enum Gender
    {
        Mashkull,
        Femer
    }

}
