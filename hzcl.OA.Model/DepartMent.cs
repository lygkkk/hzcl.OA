//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace hzcl.OA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartMent
    {
        public int ID { get; set; }
        public string DepName { get; set; }
        public int ParentId { get; set; }
        public string TreePath { get; set; }
        public Nullable<int> Level { get; set; }
        public Nullable<bool> IsLeaf { get; set; }
    }
}
