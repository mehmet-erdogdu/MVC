//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPNET_MVC.Models.EntitiyFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detay
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string Baslik { get; set; }
        public string Makale { get; set; }
        public System.DateTime Olusturma_Tarihi { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
    }
}
