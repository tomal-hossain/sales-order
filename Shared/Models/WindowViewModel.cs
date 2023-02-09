using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models
{
    public class WindowViewModel
    {
        [Required, MinLength(3), MaxLength(150)]
        public string Name { get; set; }

        [Required, Range(1, 100)]
        public int Quantity { get; set; }

        public IList<SubElementViewModel> SubElements { get; set; }
    }
}
