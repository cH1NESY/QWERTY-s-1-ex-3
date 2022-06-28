//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QWERTY_s_1_ex_3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            this.FirstDiagnostic = new HashSet<FirstDiagnostic>();
            this.Repair = new HashSet<Repair>();
        }
    
        public int id { get; set; }
        public int type { get; set; }
        public string model { get; set; }
        public string damage { get; set; }
        public string complaint { get; set; }
        public Nullable<int> master { get; set; }
        public int client { get; set; }
        public string WorkerMasters { get => Worker.FIO; }
        public string typeOrders { get => Type1.Title; }

        public string RepairStatus {get   
            {
                if (Repair.Count != 0)
                {
                    return "В ремонте";
                }
                if (FirstDiagnostic.Count != 0)
                {
                    return "На диагностике";
                }
                else { return ""; }
            } }

        public virtual Client Client1 { get; set; }
        public virtual Type Type1 { get; set; }
        public virtual Types Types { get; set; }
        public virtual Worker Worker { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirstDiagnostic> FirstDiagnostic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repair> Repair { get; set; }
    }
}
