//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrder
    {
        public int OrderID { get; set; }
        public Nullable<int> Napolitana { get; set; }
        public Nullable<int> Kapricoza { get; set; }
        public Nullable<int> Margarita { get; set; }
        public Nullable<int> Sicilijana { get; set; }
        public Nullable<int> Special { get; set; }
        public string OrderDate { get; set; }
        public string CustomerJMBG { get; set; }
        public string OrderStatus { get; set; }
        public Nullable<int> TotalAmount { get; set; }
    }
}
