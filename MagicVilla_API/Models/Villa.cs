using MagicVilla_API.Custom_Validations;
using MagicVilla_API.DataExample;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is require")]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field {0} is require")]
        [MinLength(3)]
        public string Details { get; set; }
        [Required(ErrorMessage = "The field {0} is require")]
        [Range(1, 1000)]
        public double Tarifa { get; set; }
        [Required(ErrorMessage = "The filed {0} is require")]
        [Range(1, 10, ErrorMessage = " This filed has to be between {1} and {2}")]
        public int Ocupantes { get; set; }
        [Required]
        public int MetrosCuadrados { get; set; }
        public string imageUrl { get; set; }
        [FirstLetterCapital]
        public string Amenidad { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please insert to email valid")]
        public string Email { get; set; }

        public MyEnum myEnum { get; set; }
        [DateValidationcs]
        public DateTime dateofBirth { get; set; }


    }
}
