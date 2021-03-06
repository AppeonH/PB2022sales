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
    [DataWindow("d_product_detail", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"production.product\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"production.product.productid\"   OP =\"=\"    EXP2 =\":al_productid\" ) ) ARG(NAME = \"al_productid\" TYPE = number)")]
    #endregion
    [DwParameter("al_productid", typeof(double?))]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [Table("product", Schema = "production")]
    public class D_Product_Detail
    {
        [Identity]
        [DwColumn("production.product", "productid")]
        [Key]
        public int Productid { get; set; } = 0;

        [DwColumn("production.product", "name")]
        [ConcurrencyCheck]
        [StringLength(50)]
        public string Name { get; set; }

        [DwColumn("production.product", "productnumber")]
        [ConcurrencyCheck]
        [StringLength(25)]
        public string Productnumber { get; set; }

        [DwColumn("production.product", "makeflag")]
        [ConcurrencyCheck]
        public bool Makeflag { get; set; }

        [DwColumn("production.product", "color")]
        [ConcurrencyCheck]
        [StringLength(15)]
        public string Color { get; set; }

        [DwColumn("production.product", "safetystocklevel")]
        [ConcurrencyCheck]
        public short Safetystocklevel { get; set; } = 10;

        [DwColumn("production.product", "reorderpoint")]
        [ConcurrencyCheck]
        public short Reorderpoint { get; set; } = 10;

        [DwColumn("production.product", "standardcost")]
        [ConcurrencyCheck]
        public decimal Standardcost { get; set; }

        [DwColumn("production.product", "listprice")]
        [ConcurrencyCheck]
        public decimal Listprice { get; set; }

        [DwColumn("production.product", "size")]
        [ConcurrencyCheck]
        public string Size { get; set; }

        [DwChild("Unitmeasurecode", "Name", typeof(D_Dddw_Unit), AutoRetrieve = true)]
        [DwColumn("production.product", "sizeunitmeasurecode")]
        [ConcurrencyCheck]
        public string Sizeunitmeasurecode { get; set; }

        [DwChild("Unitmeasurecode", "Name", typeof(D_Dddw_Unit), AutoRetrieve = true)]
        [DwColumn("production.product", "weightunitmeasurecode")]
        [ConcurrencyCheck]
        public string Weightunitmeasurecode { get; set; }

        [DwColumn("production.product", "weight")]
        [ConcurrencyCheck]
        public decimal? Weight { get; set; }

        [DwColumn("production.product", "daystomanufacture")]
        [ConcurrencyCheck]
        public int Daystomanufacture { get; set; }

        [DwColumn("production.product", "productline")]
        [ConcurrencyCheck]
        public string Productline { get; set; }

        [DwColumn("production.product", "class")]
        [ConcurrencyCheck]
        public string Class { get; set; }

        [DwColumn("production.product", "style")]
        [ConcurrencyCheck]
        public string Style { get; set; }

        [DwChild("Productsubcategoryid", "Name", typeof(D_Dddw_Subcategory), AutoRetrieve = true)]
        [DwColumn("production.product", "productsubcategoryid")]
        [ConcurrencyCheck]
        public int? Productsubcategoryid { get; set; }

        [DwColumn("production.product", "productmodelid")]
        [ConcurrencyCheck]
        public int? Productmodelid { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("production.product", "sellstartdate", TypeName = "timestamp")]
        public DateTime Sellstartdate { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("production.product", "sellenddate", TypeName = "timestamp")]
        public DateTime? Sellenddate { get; set; }

        [SqlDefaultValue("current server timestamp")]
        [DwColumn("production.product", "modifieddate", TypeName = "timestamp")]
        [ConcurrencyCheck]
        public DateTime Modifieddate { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("production.product", "finishedgoodsflag")]
        public bool Finishedgoodsflag { get; set; } = Convert.ToBoolean(0);

    }

}