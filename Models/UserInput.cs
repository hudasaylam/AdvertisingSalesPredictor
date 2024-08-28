using System.ComponentModel.DataAnnotations;

namespace Advertising.Models
{
    public class UserInput
    {

        public class PredictionModel
        {
            [Required]
            [Range(0, double.MaxValue, ErrorMessage = "Value must be positive.")]
            public double TV { get; set; }

            [Required]
            [Range(0, double.MaxValue, ErrorMessage = "Value must be positive.")]
            public double Radio { get; set; }

            [Required]
            [Range(0, double.MaxValue, ErrorMessage = "Value must be positive.")]
            public double Newspaper { get; set; }

            public double? Prediction { get; set; }
        }
    

}
}
