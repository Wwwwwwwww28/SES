//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MITRA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Расход
    {
        public int ID_Отчёта { get; set; }
        public int ID_Материала { get; set; }
        public int Кол_во { get; set; }
    
        public virtual Материал Материал { get; set; }
        public virtual Отчёт Отчёт { get; set; }
    }
}
