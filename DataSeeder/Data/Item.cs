//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSeeder.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int BrandID { get; set; }
        public int CountryID { get; set; }
        public int ColorID { get; set; }
        public int TypeID { get; set; }
        public int MaterialID { get; set; }
        public decimal Price { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual Country Country { get; set; }
        public virtual Material Material { get; set; }
        public virtual Type Type { get; set; }
    }
}