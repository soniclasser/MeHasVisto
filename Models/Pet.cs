//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeHasVisto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public int PetID { get; set; }
        public string PetName { get; set; }
        public Nullable<int> PetAgeYears { get; set; }
        public Nullable<int> PetAgeMonths { get; set; }
        public int StatusID { get; set; }
        public Nullable<System.DateTime> LastSeenOn { get; set; }
        public string LastSeenWhere { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    
        public virtual Status Status { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
