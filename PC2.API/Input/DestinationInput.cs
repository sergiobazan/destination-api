using System.ComponentModel.DataAnnotations;

namespace si730pc2u201624050.API.Input
{
    public class DestinationInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MaxUsers { get; set; }
        [Required]
        [Range(0, 1)]
        public int IsRisky { get; set; }
    }
}
