using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AdminPanelLoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get ;set; }
    }
}