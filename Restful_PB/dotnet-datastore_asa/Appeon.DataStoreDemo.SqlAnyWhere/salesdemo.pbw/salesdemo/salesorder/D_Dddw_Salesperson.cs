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
    [DataWindow("d_dddw_salesperson", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM Sales.SalesPerson  , \r\n "
                  +"Person.Person \r\n "
                  +"WHERE ( Sales.SalesPerson.BusinessEntityID = Person.Person.BusinessEntityID )")]
    #endregion
    public class D_Dddw_Salesperson
    {
        [DwColumn("Sales.SalesPerson", "businessentityid")]
        public int Salesperson_Businessentityid { get; set; }

        [DwColumn("Person.Person", "title")]
        [StringLength(8)]
        public string Person_Title { get; set; }

        [DwColumn("Person.Person", "firstname")]
        [StringLength(50)]
        public string Person_Firstname { get; set; }

        [DwColumn("Person.Person", "middlename")]
        [StringLength(50)]
        public string Person_Middlename { get; set; }

        [DwColumn("Person.Person", "lastname")]
        [StringLength(50)]
        public string Person_Lastname { get; set; }

        [DwColumn("Person.Person", "suffix")]
        [StringLength(10)]
        public string Person_Suffix { get; set; }

        [DwCompute(" person_lastname + \" \" +  person_middlename  + \" \" +  person_firstname ")]
        [JsonIgnore]
        [IgnoreDataMember]
        public object Full_Name { get; set; }

    }

}