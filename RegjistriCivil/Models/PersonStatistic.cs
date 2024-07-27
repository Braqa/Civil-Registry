using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.Models
{
    // Klasa Personi
    public class PersonStatistic
    {

        //Properties
        public int Id { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        public Employment Employment { get; set; }

        [Required]
        public SchoolQualification SchoolQualification { get; set; }

        [Required]
        public HealthStatus HealthStatus { get; set; }

        public string Diagnosis { get; set; }

        [Required]
        public Migration Migration { get; set; }

        public string PlaceOfMigration { get; set; }

        //public int Age
        //{
        //    get
        //    {
        //        // Save today's date.
        //        var today = DateTime.Today;
        //        // Calculate the age.
        //        var age = today.Year - DateOfBirth.Year;
        //        // Go back to the year the person was born in case of a leap year
        //        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        //        return age;
        //    }
        //}

        // Constructor
        public PersonStatistic() { }

        //public PersonStatistics(string firstName, string lastName, int personalNumber, DateTime dateOfBirth, Gender gender, string placeOfBirth, string nationality)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    PersonalNumber = personalNumber;
        //    DateOfBirth = dateOfBirth;
        //    Gender = gender;
        //    PlaceOfBirth = placeOfBirth;
        //    Nationality = nationality;
        //}

        //public PersonStatistics(int id, string firstName, string lastName, int personalNumber, DateTime dateOfBirth, Gender gender, string placeOfBirth, string nationality,
        //    string employment, string schoolQualification, string healthStatus, string diagnosis, string migration, string placeOfMigration)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    PersonalNumber = personalNumber;
        //    DateOfBirth = dateOfBirth;
        //    Gender = gender;
        //    PlaceOfBirth = placeOfBirth;
        //    Nationality = nationality;
        //    Employment = employment;
        //    SchoolQualification = schoolQualification;
        //    HealthStatus = healthStatus;
        //    Diagnosis = diagnosis;
        //    Migration = migration;
        //    PlaceOfMigration = placeOfMigration;
        //}

        //public PersonStatistics(string name, string lastName, string address, int personalNumber, DateTime dateOfBirth, Gender gender, string placeOfBirth, string nationality,
        //string employment, string schoolQualification, string healthStatus, string diagnosis, string migration, string placeOfMigration)
        //    : base(name, lastName, address)
        //{
        //    PersonalNumber = personalNumber;
        //    DateOfBirth = dateOfBirth;
        //    Gender = gender;
        //    PlaceOfBirth = placeOfBirth;
        //    Nationality = nationality;
        //    Employment = employment;
        //    SchoolQualification = schoolQualification;
        //    HealthStatus = healthStatus;
        //    Diagnosis = diagnosis;
        //    Migration = migration;
        //    PlaceOfMigration = placeOfMigration;
        //}
    }

    public enum Employment
    {
        Employed,
        Unemployed,
        Pensioner
    }

    public enum SchoolQualification
    {
        PreSchool,
        ElementarySchool,
        HighSchool,
        University
    }

    public enum HealthStatus
    {
        Healthy,
        Diabetes,
        Tbc,
        HepatitA,
        HepatitB
    }

    public enum Migration
    {
        Yes,
        No
    }


}

