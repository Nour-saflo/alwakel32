//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Al_Wakel_Pro_move_1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.CurrencyOperations = new HashSet<CurrencyOperations>();
            this.Operation = new HashSet<Operation>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> CenterId { get; set; }
        public string CurrnceyName { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string PasswordForEditQuantity { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual Center Center { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrencyOperations> CurrencyOperations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operation { get; set; }
    }
}
