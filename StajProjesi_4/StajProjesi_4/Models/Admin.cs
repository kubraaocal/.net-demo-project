//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StajProjesi_4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public partial class Admin
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Boş bırakmayınız")]
        public string ADMİN { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Boş bırakmayınız")]
        public string SİFRE { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}