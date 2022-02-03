using System.ComponentModel.DataAnnotations;

namespace REST_API_DOTNET.Models
{
    public class Computer
    {
        public int Id { get; set; }

        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Display(Name = "Год выпуска")]
        public int Year { get; set; }
    }
}
