//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class db_API_Operationallog
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string types { get; set; }
        public string events { get; set; }
        public string more { get; set; }
        public Nullable<decimal> money { get; set; }
        public Nullable<decimal> lastmoney { get; set; }
        public Nullable<decimal> nowmoney { get; set; }
        public string bak { get; set; }
        public Nullable<System.DateTime> times { get; set; }
    }
}
