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
    [DataWindow("d_subcategorysalesreport_d", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("select @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"from Sales.SalesOrderDetail SalesOrderDetail \r\n "
                  +"inner join Sales.SalesOrderHeader SalesOrderHeader on SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID \r\n "
                  +"inner join Production.Product Product on SalesOrderDetail.ProductID = Product.ProductID \r\n "
                  +"inner join Production.ProductSubcategory ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID \r\n "
                  +"where SalesOrderHeader.Status in(1,2,5) and \r\n "
                  +"(ProductSubcategory.ProductSubcategoryID = :subCategoryId) and \r\n "
                  +"(left(convert(varchar(10), SalesOrderHeader.OrderDate, 112), 6) =:salesMonth ) \r\n "
                  +"group by ProductSubcategory.Name")]
    #endregion
    [DwParameter("subCategoryId", typeof(double?))]
    [DwParameter("salesMonth", typeof(string))]
    public class D_Subcategorysalesreport_D
    {
        [DwColumn("ProductSubcategory", "Name", "SubcategoryName")]
        public string Subcategoryname { get; set; }
        
        [SqlCompute("sum(SalesOrderDetail.orderqty) as TotalSalesqty")]
        public int? Totalsalesqty { get; set; }
        
        [SqlCompute("sum(SalesOrderDetail.linetotal) as TotalSaleroom")]
        public decimal? Totalsaleroom { get; set; }
        
    }
    
}