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
    [DataWindow("d_dddw_product", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"production.product\" ) @(_COLUMNS_PLACEHOLDER_) )")]
    #endregion
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [Table("product", Schema = "production")]
    public class D_Dddw_Product
    {
        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("production.product", "productid")]
        [Key]
        public int Productid { get; set; }

        [DwColumn("production.product", "name")]
        [ConcurrencyCheck]
        [StringLength(50)]
        public string Name { get; set; }

    }

}