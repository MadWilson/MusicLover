//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Performer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Performer()
        {
            this.Album = new HashSet<Album>();
        }
    
        public int id_performer { get; set; }
        public string performer1 { get; set; }
        public string country { get; set; }
        public System.DateTime birthdate { get; set; }
        public int id_group { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Album> Album { get; set; }
        public virtual Group Group { get; set; }
    }
}
