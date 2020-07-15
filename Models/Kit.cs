using System.ComponentModel.DataAnnotations;

namespace CS_Lego.Models
{
    public class Kit
    {
        public int Id {get; set;}
        public string Description {get; set;}
        [Required]
        public string Name {get; set;}

        public double Price {get; set;}

        public string Creator {get; set;}
    }
}