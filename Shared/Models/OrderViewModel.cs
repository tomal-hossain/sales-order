using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SharedModels.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(150)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string State { get; set; }

        public IList<WindowViewModel> Windows { get; set; }

        [JsonIgnore]
		public bool ShowDetails { get; set; }
	}
}
