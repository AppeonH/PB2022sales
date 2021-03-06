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
    [DataWindow("d_dddw_customer_creditcard", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM Sales.creditcard, \r\n "
                  +"Sales.personcreditcard, \r\n "
                  +"Sales.customer \r\n "
                  +"WHERE ( Sales.personcreditcard.creditcardid = Sales.creditcard.creditcardid ) and \r\n "
                  +"( Sales.personcreditcard.businessentityid = Sales.customer.personid ) and \r\n "
                  +"( Sales.Customer.CustomerID = :al_customer_id )")]
    #endregion
    [DwParameter("al_customer_id", typeof(double?))]
    public class D_Dddw_Customer_Creditcard
    {
        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("Sales.customer", "customerid")]
        public int Customer_Customerid { get; set; }

        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("Sales.creditcard", "creditcardid")]
        public int Creditcard_Creditcardid { get; set; }

        [DwColumn("Sales.creditcard", "cardtype")]
        [StringLength(50)]
        public string Creditcard_Cardtype { get; set; }

        [DwColumn("Sales.creditcard", "cardnumber")]
        [StringLength(25)]
        public string Creditcard_Cardnumber { get; set; }

        [DwColumn("Sales.creditcard", "expmonth")]
        public byte Creditcard_Expmonth { get; set; }

        [DwColumn("Sales.creditcard", "expyear")]
        public short Creditcard_Expyear { get; set; }

    }

}