using SharedModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models
{
    public class SubElementViewModel
    {
        [Required]
        public ElementType Type { get; set; }

        [Required, Range(1, 100000)]
        public int Width { get; set; }

        [Required, Range(1, 100000)]
        public int Height { get; set; }
    }
}
