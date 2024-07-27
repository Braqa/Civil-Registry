using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegjistriCivil.Models
{
    // Base Class
    public class FamilyMemberBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Costructor
        public FamilyMemberBase()
        {

        }
        public FamilyMemberBase(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    // Derived Class of FamilyMemberBase
    public class FamilyMember : FamilyMemberBase
    {
        // Properties
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }

        // Constructor 
        public FamilyMember()
        {

        }
        public FamilyMember(string firstName, string lastName, DateTime dateOfBirth, string placeOfBirth, string nationality)
            : base(firstName, lastName)
        {
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            Nationality = nationality;
        }
    }

    // Derived Class of FamilyMember 
    public class FamilyMemberWithRelation : FamilyMember
    {
        // Propertie
        public Relation Relation { get; set; }
        public int PersonalNumber { get; set; }

        // Constructor
        public FamilyMemberWithRelation()
        {

        }
        public FamilyMemberWithRelation(string firstName, string lastName, DateTime dateOfBirth, string placeOfBirth, string nationality, int personalNumber, Relation relation)
            : base(firstName, lastName, dateOfBirth, placeOfBirth, nationality)
        {
            PersonalNumber = personalNumber;
            Relation = relation;
        }
    }

    // Enum
    public enum Relation
    {
        Father,
        Mother,
        Brother,
        Sister
    }
}
