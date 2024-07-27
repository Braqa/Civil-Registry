using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
