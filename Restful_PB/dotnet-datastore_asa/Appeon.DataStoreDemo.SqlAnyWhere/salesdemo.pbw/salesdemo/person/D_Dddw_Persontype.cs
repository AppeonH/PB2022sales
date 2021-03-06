using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SnapObjects.Data;
using DWNet.Data;
using Newtonsoft.Json;
using System.Collections;

namespace Appeon.DataStoreDemo.SqlAnywhere
{
    [DataWindow("d_dddw_persontype", DwStyle.Grid)]
    [DwSort("persontype A")]
    [DwData(typeof(D_Dddw_Persontype_Data))]
    public class D_Dddw_Persontype
    {
        [DwColumn("persontype")]
        public string Persontype { get; set; }

        [DwColumn("typedesc")]
        public string Typedesc { get; set; }

    }

    #region D_Dddw_Persontype_Data
    public class D_Dddw_Persontype_Data : DwDataInitializer<D_Dddw_Persontype>
    {
        public override IList<D_Dddw_Persontype> GetDefaultData()
        {
            var list = new List<D_Dddw_Persontype>();
			 
            list.Add(new D_Dddw_Persontype() { Persontype = "SC", Typedesc = "Store Contact" });
				 
            list.Add(new D_Dddw_Persontype() { Persontype = "IN", Typedesc = "Individual (retail) customer" });
				 
            list.Add(new D_Dddw_Persontype() { Persontype = "SP", Typedesc = "Sales person" });
				 
            list.Add(new D_Dddw_Persontype() { Persontype = "EM", Typedesc = "Employee (non-sales)" });
				 
            list.Add(new D_Dddw_Persontype() { Persontype = "VC", Typedesc = "Vendor contact" });
				 
            list.Add(new D_Dddw_Persontype() { Persontype = "GC", Typedesc = "General contact" });
				
            return list;
        }
    }
    #endregion
}