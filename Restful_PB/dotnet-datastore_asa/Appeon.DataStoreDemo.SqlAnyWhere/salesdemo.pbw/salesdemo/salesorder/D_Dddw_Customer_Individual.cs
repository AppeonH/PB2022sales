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
    [DataWindow("d_dddw_customer_individual", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT TOP 100 \r\n "
                  +"@(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM Sales.Customer, \r\n "
                  +"Sales.SalesTerritory, \r\n "
                  +"Person.Person \r\n "
                  +"WHERE ( Sales.SalesTerritory.TerritoryID = Sales.Customer.TerritoryID ) and \r\n "
                  +"( ( Sales.Customer.PersonID is not null ) AND \r\n "
                  +"( Sales.Customer.PersonID = Person.Person.BusinessEntityID ) ) \r\n "
                  +"ORDER BY Sales.Customer.CustomerID ASC")]
    #endregion
    public class D_Dddw_Customer_Individual
    {
        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("Sales.Customer", "CustomerID")]
        public int Customer_Customerid { get; set; }

        [DwColumn("Sales.Customer", "PersonID")]
        public int? Customer_Personid { get; set; }

        [DwColumn("Sales.Customer", "TerritoryID")]
        public int? Customer_Territoryid { get; set; }

        [DwColumn("Sales.Customer", "AccountNumber")]
        [StringLength(10)]
        public string Customer_Accountnumber { get; set; }

        [DwColumn("Sales.SalesTerritory", "Name")]
        [StringLength(50)]
        public string Salesterritory_Name { get; set; }

        [DwColumn("Person.Person", "Title")]
        public string Person_Title { get; set; }

        [DwColumn("Person.Person", "FirstName")]
        public string Person_Firstname { get; set; }

        [DwColumn("Person.Person", "MiddleName")]
        public string Person_Middlename { get; set; }

        [DwColumn("Person.Person", "LastName")]
        public string Person_Lastname { get; set; }

        [DwColumn("Person.Person", "Suffix")]
        public string Person_Suffix { get; set; }

        [DwCompute(" person_lastname +\" \" + person_firstname ")]
        [JsonIgnore]
        [IgnoreDataMember]
        public object Full_Name { get; set; }

    }

}