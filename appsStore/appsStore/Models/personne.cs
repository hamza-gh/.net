//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace appsStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class personne
    {
        public int id_per { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
    
        public virtual admin admin { get; set; }
        public virtual login login { get; set; }
        public virtual utilisateur utilisateur { get; set; }
    }
}
