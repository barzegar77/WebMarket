using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان اجباریست")]
        [DisplayName("عنوان")]
        public string Name { get; set; }
    }
}
