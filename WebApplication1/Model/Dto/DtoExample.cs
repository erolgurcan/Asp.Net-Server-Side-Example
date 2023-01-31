using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.Dto
    {
    public class DtoExample
        {

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime createdDAte { get; set; }

        public int Occupancy { get; set; }

        public int Sqft { get; set; }



        }
    }
