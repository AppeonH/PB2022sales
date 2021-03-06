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
    [DataWindow("d_address", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM Person.Address \r\n "
                  +"where (Person.Address.stateprovinceid = :stateId or :stateId = 0) \r\n "
                  +"and (Person.Address.city like :city)")]
    #endregion
    [DwParameter("stateId", typeof(double?))]
    [DwParameter("city", typeof(string))]
    [DwSort("addressid A")]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [Table("Address", Schema = "Person")]
    public class D_Address
    {
        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("Person.Address", "addressid")]
        [Key]
        public int Addressid { get; set; }

        [DwColumn("Person.Address", "addressline1")]
        [ConcurrencyCheck]
        [StringLength(60)]
        public string Addressline1 { get; set; }

        [DwColumn("Person.Address", "addressline2")]
        [ConcurrencyCheck]
        [StringLength(60)]
        public string Addressline2 { get; set; }

        [DwColumn("Person.Address", "city")]
        [ConcurrencyCheck]
        [StringLength(30)]
        public string City { get; set; }

        [DwChild("Stateprovinceid", "Name", typeof(D_Dddw_Stateprovince))]
        [DwColumn("Person.Address", "stateprovinceid")]
        [ConcurrencyCheck]
        public int Stateprovinceid { get; set; }

        [DwColumn("Person.Address", "postalcode")]
        [ConcurrencyCheck]
        [StringLength(15)]
        public string Postalcode { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Address", "modifieddate", TypeName = "timestamp")]
        public DateTime Modifieddate { get; set; }

    }

}