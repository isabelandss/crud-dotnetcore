using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Models
{
    public class Pokemon
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int height { get; set; }

        public int weight { get; set; }
    }
}