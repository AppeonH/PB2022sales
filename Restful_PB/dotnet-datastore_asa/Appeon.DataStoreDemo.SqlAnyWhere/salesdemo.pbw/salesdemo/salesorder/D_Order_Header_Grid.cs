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
    [DataWindow("d_order_header_grid", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Sales.SalesOrderHeader\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"Sales.SalesOrderHeader.OrderDate\"   OP =\"between\"    EXP2 =\":adt_start and :adt_end\"    LOGIC =\"And\" ) WHERE(    EXP1 =\"(Sales.SalesOrderHeader.CustomerID\"   OP =\"=\"    EXP2 =\":al_cust_id\"    LOGIC =\"or\" ) WHERE(    EXP1 =\":al_cust_id\"   OP =\"=\"    EXP2 =\"0)\" ) ) ORDER(NAME=\"Sales.SalesOrderHeader.orderdate\" ASC=no) ARG(NAME = \"adt_start\" TYPE = datetime)  ARG(NAME = \"adt_end\" TYPE = datetime)  ARG(NAME = \"al_cust_id\" TYPE = number)")]
    #endregion
    [DwParameter("adt_start", typeof(DateTime?))]
    [DwParameter("adt_end", typeof(DateTime?))]
    [DwParameter("al_cust_id", typeof(double?))]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [Table("SalesOrderHeader", Schema = "Sales")]
    public class D_Order_Header_Grid
    {
        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("Sales.SalesOrderHeader", "salesorderid")]
        [Key]
        public int Salesorderid { get; set; }

        [SqlDefaultValue("0")]
        [DwColumn("Sales.SalesOrderHeader", "revisionnumber")]
        [ConcurrencyCheck]
        public byte Revisionnumber { get; set; }

        [SqlDefaultValue("current server timestamp")]
        [DwColumn("Sales.SalesOrderHeader", "orderdate", TypeName = "timestamp")]
        [ConcurrencyCheck]
        public DateTime Orderdate { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "duedate", TypeName = "timestamp")]
        [ConcurrencyCheck]
        public DateTime Duedate { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "shipdate", TypeName = "timestamp")]
        [ConcurrencyCheck]
        public DateTime? Shipdate { get; set; }

        [SqlDefaultValue("1")]
        [DwColumn("Sales.SalesOrderHeader", "status")]
        [ConcurrencyCheck]
        public byte Status { get; set; }

        [SqlDefaultValue("True")]
        [DwColumn("Sales.SalesOrderHeader", "onlineorderflag")]
        [ConcurrencyCheck]
        public bool Onlineorderflag { get; set; }

        [SqlDefaultValue("(\"isnull\"('SO'+convert(nvarchar(23),\"SalesOrderID\"),'*** ERROR ***'))")]
        [DwColumn("Sales.SalesOrderHeader", "salesordernumber")]
        [ConcurrencyCheck]
        [StringLength(25)]
        public string Salesordernumber { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "purchaseordernumber")]
        [ConcurrencyCheck]
        [StringLength(25)]
        public string Purchaseordernumber { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "accountnumber")]
        [ConcurrencyCheck]
        [StringLength(15)]
        public string Accountnumber { get; set; }

        [DwChild("Customer_Customerid", "Full_Name", typeof(D_Dddw_Customer_Individual), AutoRetrieve = true)]
        [DwColumn("Sales.SalesOrderHeader", "customerid")]
        [ConcurrencyCheck]
        public int Customerid { get; set; }

        [DwChild("Salesperson_Businessentityid", "Full_Name", typeof(D_Dddw_Salesperson), AutoRetrieve = true)]
        [DwColumn("Sales.SalesOrderHeader", "salespersonid")]
        [ConcurrencyCheck]
        public int? Salespersonid { get; set; }

        [DwChild("Salesterritory_Territoryid", "Salesterritory_Name", typeof(D_Dddw_Salesterritory), AutoRetrieve = true)]
        [DwColumn("Sales.SalesOrderHeader", "territoryid")]
        [ConcurrencyCheck]
        public int? Territoryid { get; set; }

        [DwChild("Businessentityaddress_Addressid", "Address_Addressline1", typeof(D_Dddw_Customer_Address), AutoRetrieve = true)]
        [DwColumn("Sales.SalesOrderHeader", "billtoaddressid")]
        [ConcurrencyCheck]
        public int Billtoaddressid { get; set; }

        [DwChild("Businessentityaddress_Addressid", "Address_Addressline1", typeof(D_Dddw_Customer_Address), AutoRetrieve = true)]
        [DwColumn("Sales.SalesOrderHeader", "shiptoaddressid")]
        [ConcurrencyCheck]
        public int Shiptoaddressid { get; set; }

        [DwChild("Shipmethodid", "Name", typeof(D_Dddw_Shipmethod), AutoRetrieve = true)]
        [DwColumn("Sales.SalesOrderHeader", "shipmethodid")]
        [ConcurrencyCheck]
        public int Shipmethodid { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "creditcardid")]
        [ConcurrencyCheck]
        public int? Creditcardid { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "creditcardapprovalcode")]
        [ConcurrencyCheck]
        public string Creditcardapprovalcode { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "currencyrateid")]
        [ConcurrencyCheck]
        public int? Currencyrateid { get; set; }

        [SqlDefaultValue("0")]
        [DwColumn("Sales.SalesOrderHeader", "subtotal")]
        [ConcurrencyCheck]
        public decimal Subtotal { get; set; }

        [SqlDefaultValue("0")]
        [DwColumn("Sales.SalesOrderHeader", "taxamt")]
        [ConcurrencyCheck]
        public decimal Taxamt { get; set; }

        [SqlDefaultValue("0")]
        [DwColumn("Sales.SalesOrderHeader", "freight")]
        [ConcurrencyCheck]
        public decimal Freight { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "totaldue")]
        [ConcurrencyCheck]
        public decimal Totaldue { get; set; }

        [DwColumn("Sales.SalesOrderHeader", "comment")]
        [ConcurrencyCheck]
        [StringLength(128)]
        public string Comment { get; set; }

        [SqlDefaultValue("current server timestamp")]
        [DwColumn("Sales.SalesOrderHeader", "modifieddate", TypeName = "timestamp")]
        [ConcurrencyCheck]
        public DateTime Modifieddate { get; set; }

        [DwCompute("getrow()")]
        [JsonIgnore]
        [IgnoreDataMember]
        public object Compute_Row { get; set; }

    }

}