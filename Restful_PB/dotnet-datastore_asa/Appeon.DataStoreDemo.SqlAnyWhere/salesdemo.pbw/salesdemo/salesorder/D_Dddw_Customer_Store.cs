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
    [DataWindow("d_dddw_customer_store", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Sales.Customer\" )  TABLE(NAME=\"Sales.Store\" )  TABLE(NAME=\"Sales.SalesTerritory\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Sales.Store.BusinessEntityID\"    OP =\"=\"RIGHT=\"Sales.Customer.StoreID\" )    JOIN (LEFT=\"Sales.SalesTerritory.TerritoryID\"    OP =\"=\"RIGHT=\"Sales.Customer.TerritoryID\" )WHERE(    EXP1 =\"\\\"Sales\\\".\\\"Customer\\\".\\\"StoreID\\\"\"   OP =\"is not\"    EXP2 =\"null\" ) ) ORDER(NAME=\"Sales.Customer.CustomerID\" ASC=yes )")]
    #endregion
    public class D_Dddw_Customer_Store
    {
        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("Sales.Customer", "CustomerID")]
        public int Customer_Customerid { get; set; }

        [DwColumn("Sales.Customer", "StoreID")]
        public int? Customer_Storeid { get; set; }

        [DwColumn("Sales.Customer", "TerritoryID")]
        public int? Customer_Territoryid { get; set; }

        [DwColumn("Sales.Customer", "AccountNumber")]
        [StringLength(10)]
        public string Customer_Accountnumber { get; set; }

        [DwColumn("Sales.Store", "Name")]
        [StringLength(50)]
        public string Store_Name { get; set; }

        [DwColumn("Sales.SalesTerritory", "Name")]
        [StringLength(50)]
        public string Salesterritory_Name { get; set; }

        [DwColumn("Sales.SalesTerritory", "Group")]
        [StringLength(50)]
        public string Salesterritory_Group { get; set; }

    }

}