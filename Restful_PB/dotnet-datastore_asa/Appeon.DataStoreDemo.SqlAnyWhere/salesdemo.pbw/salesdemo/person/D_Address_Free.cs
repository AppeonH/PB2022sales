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
    [DataWindow("d_address_free", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM Person.Address \r\n "
                  +"WHERE Person.Address.addressid = :al_addressid")]
    #endregion
    [DwParameter("al_addressid", typeof(double?))]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [Table("Address", Schema = "Person")]
    public class D_Address_Free
    {
        [Identity]
        [DwColumn("Person.Address", "addressid")]
        [Key]
        public int Addressid { get; set; } = 0;

        [DwColumn("Person.Address", "addressline1")]
        [StringLength(60)]
        public string Addressline1 { get; set; }

        [DwColumn("Person.Address", "addressline2")]
        [StringLength(60)]
        public string Addressline2 { get; set; }

        [DwColumn("Person.Address", "city")]
        [StringLength(30)]
        public string City { get; set; }

        [DwChild("Stateprovinceid", "Name", typeof(D_Dddw_Stateprovince))]
        [DwColumn("Person.Address", "stateprovinceid")]
        public int Stateprovinceid { get; set; }

        [DwColumn("Person.Address", "postalcode")]
        [StringLength(15)]
        public string Postalcode { get; set; }

        [DwColumn("Person.Address", "modifieddate", TypeName = "timestamp")]
        public DateTime Modifieddate { get; set; } = Convert.ToDateTime("1/1/2019 12:00:00 AM");

    }

}