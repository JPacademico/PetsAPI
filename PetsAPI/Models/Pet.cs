using System;
using System.Collections.Generic;

namespace PetsAPI.Models
{
    public partial class Pet
    {
        public int IdPet { get; set; }
        public string? NomePet { get; set; }
        public string? Tipo { get; set; }
        public int? Idade { get; set; }
        public int? IdTutor { get; set; }

        public virtual Tutor? IdTutorNavigation { get; set; }
    }
}
