//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OplataTruda
{
    using System;
    using System.Collections.Generic;
    
    public partial class SotrHistory
    {
        public int idSotrHistory { get; set; }
        public string FullName { get; set; }
        public System.DateTime Date { get; set; }
        public int idTypeAct { get; set; }
        public string Description { get; set; }
    
        public virtual TypeAction TypeAction { get; set; }
    }
}
