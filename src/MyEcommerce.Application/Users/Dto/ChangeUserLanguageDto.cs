using System.ComponentModel.DataAnnotations;

namespace MyEcommerce.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}