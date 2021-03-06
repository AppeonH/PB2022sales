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
    [DataWindow("d_dddw_customer_address", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Person.BusinessEntityAddress\" )  TABLE(NAME=\"Person.Address\" )  TABLE(NAME=\"Person.AddressType\" )  TABLE(NAME=\"Sales.Customer\" )  TABLE(NAME=\"Person.StateProvince\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Person.Address.AddressID\"    OP =\"=\"RIGHT=\"Person.BusinessEntityAddress.AddressID\" )    JOIN (LEFT=\"Person.AddressType.AddressTypeID\"    OP =\"=\"RIGHT=\"Person.BusinessEntityAddress.AddressTypeID\" )    JOIN (LEFT=\"Sales.Customer.TerritoryID\"    OP =\"=\"RIGHT=\"Person.StateProvince.TerritoryID\" )WHERE(    EXP1 =\"(\\\"Person\\\".\\\"BusinessEntityAddress\\\".\\\"BusinessEntityID\\\"\"   OP =\"=\"    EXP2 =\"\\\"Sales\\\".\\\"Customer\\\".\\\"PersonID\\\"\"    LOGIC =\"or\" ) WHERE(    EXP1 =\"\\\"Person\\\".\\\"BusinessEntityAddress\\\".\\\"BusinessEntityID\\\"\"   OP =\"=\"    EXP2 =\"\\\"Sales\\\".\\\"Customer\\\".\\\"StoreID\\\")\"    LOGIC =\"and\" ) WHERE(    EXP1 =\"\\\"Person\\\".\\\"Address\\\".\\\"StateProvinceID\\\"\"   OP =\"=\"    EXP2 =\"\\\"Person\\\".\\\"StateProvince\\\".\\\"StateProvinceID\\\"\"    LOGIC =\"and\" ) WHERE(    EXP1 =\"\\\"Sales\\\".\\\"Customer\\\".\\\"CustomerID\\\"\"   OP =\"=\"    EXP2 =\":al_customer_id\" ) ) ARG(NAME = \"al_customer_id\" TYPE = number)")]
    #endregion
    [DwParameter("al_customer_id", typeof(double?))]
    public class D_Dddw_Customer_Address
    {
        [DwColumn("Person.BusinessEntityAddress", "BusinessEntityID")]
        public int Businessentityaddress_Businessentityid { get; set; }

        [DwColumn("Person.BusinessEntityAddress", "AddressID")]
        public int Businessentityaddress_Addressid { get; set; }

        [DwColumn("Person.BusinessEntityAddress", "AddressTypeID")]
        public int Businessentityaddress_Addresstypeid { get; set; }

        [DwColumn("Person.Address", "AddressLine1")]
        [StringLength(60)]
        public string Address_Addressline1 { get; set; }

        [DwColumn("Person.Address", "AddressLine2")]
        [StringLength(60)]
        public string Address_Addressline2 { get; set; }

        [DwColumn("Person.Address", "City")]
        [StringLength(30)]
        public string Address_City { get; set; }

        [DwColumn("Person.Address", "StateProvinceID")]
        public int Address_Stateprovinceid { get; set; }

        [DwColumn("Person.Address", "PostalCode")]
        [StringLength(15)]
        public string Address_Postalcode { get; set; }

        [DwColumn("Person.AddressType", "Name")]
        [StringLength(50)]
        public string Addresstype_Name { get; set; }

        [SqlDefaultValue("autoincrement")]
        [DwColumn("Sales.Customer", "CustomerID")]
        public int Customer_Customerid { get; set; }

        [DwColumn("Person.StateProvince", "StateProvinceCode")]
        public string Stateprovince_Stateprovincecode { get; set; }

        [DwColumn("Person.StateProvince", "CountryRegionCode")]
        public string Stateprovince_Countryregioncode { get; set; }

        [DwColumn("Person.StateProvince", "Name")]
        public string Stateprovince_Name { get; set; }

    }

}