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
    [DataWindow("d_productsalesreport", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("select top 5 @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"from Sales.SalesOrderDetail SalesOrderDetail \r\n "
                  +"inner join Sales.SalesOrderHeader SalesOrderHeader on SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID \r\n "
                  +"inner join Production.Product Product on SalesOrderDetail.ProductID = Product.ProductID \r\n "
                  +"inner join Production.ProductSubcategory ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID \r\n "
                  +"where SalesOrderHeader.Status in(1,2,5) and \r\n "
                  +"(ProductSubcategory.ProductSubcategoryID = :subCategoryId) and \r\n "
                  +"(SalesOrderHeader.OrderDate between :dateFrom and :dateTo) \r\n "
                  +"group by Product.ProductID, Product.Name \r\n "
                  +"order by sum(SalesOrderDetail.linetotal) desc")]
    #endregion
    [DwParameter("subCategoryId", typeof(double?))]
    [DwParameter("dateFrom", typeof(DateTime?))]
    [DwParameter("dateTo", typeof(DateTime?))]
    public class D_Productsalesreport
    {
        [DwColumn("Product", "Name", "ProductName")]
        public string Productname { get; set; }

        [SqlCompute("sum(SalesOrderDetail.orderqty) as TotalSalesqty")]
        public int? Totalsalesqty { get; set; }

        [SqlCompute("sum(SalesOrderDetail.linetotal) as TotalSaleroom")]
        public decimal? Totalsaleroom { get; set; }

    }

}