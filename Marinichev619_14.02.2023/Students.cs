//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marinichev619_14._02._2023
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        public int IdStudent { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> GroupID { get; set; }
    
        public virtual Groups Groups { get; set; }
    }
}
