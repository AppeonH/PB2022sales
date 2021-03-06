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
    [DataWindow("d_history_price", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM production.productlistpricehistory \r\n "
                  +"WHERE    production.productlistpricehistory.productid = :al_id")]
    #endregion
    [DwParameter("al_id", typeof(double?))]
    [DwSort("modifieddate D")]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [Table("productlistpricehistory", Schema = "production")]
    public class D_History_Price
    {
        [DwChild("Productid", "Name", typeof(D_Dddw_Product))]
        [DwColumn("production.productlistpricehistory", "productid")]
        [Key]
        public int Productid { get; set; }

        [DwColumn("production.productlistpricehistory", "startdate", TypeName = "timestamp")]
        [Key]
        public DateTime Startdate { get; set; }

        [DwColumn("production.productlistpricehistory", "enddate", TypeName = "timestamp")]
        public DateTime? Enddate { get; set; }

        [DwColumn("production.productlistpricehistory", "listprice")]
        public decimal Listprice { get; set; }

        [SqlDefaultValue("current server timestamp")]
        [DwColumn("production.productlistpricehistory", "modifieddate", TypeName = "timestamp")]
        public DateTime Modifieddate { get; set; }

        [DwCompute("getrow()")]
        [JsonIgnore]
        [IgnoreDataMember]
        public object Compute_1 { get; set; }

    }

}