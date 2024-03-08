using System;
using System.Collections.Generic;

namespace PetsAPI.Models
{
    public partial class Tutor
    {
        public Tutor()
        {
            Pets = new HashSet<Pet>();
        }

        public int IdTutor { get; set; }
        public string? NomeTutor { get; set; }
        public decimal? Cpf { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
