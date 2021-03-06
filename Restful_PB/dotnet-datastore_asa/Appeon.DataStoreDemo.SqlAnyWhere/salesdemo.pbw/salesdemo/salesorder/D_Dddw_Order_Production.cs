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
    [DataWindow("d_dddw_order_production", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Production.Product\" )  TABLE(NAME=\"Production.ProductCategory\" )  TABLE(NAME=\"Production.ProductModel\" )  TABLE(NAME=\"Production.ProductSubcategory\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Production.ProductModel.ProductModelID\"    OP =\"=\"RIGHT=\"Production.Product.ProductModelID\" )    JOIN (LEFT=\"Production.ProductSubcategory.ProductCategoryID\"    OP =\"=\"RIGHT=\"Production.ProductCategory.ProductCategoryID\" )    JOIN (LEFT=\"Production.ProductSubcategory.ProductSubcategoryID\"    OP =\"=\"RIGHT=\"Production.Product.ProductSubcategoryID\" )WHERE(    EXP1 =\"\\\"Production\\\".\\\"Product\\\".\\\"FinishedGoodsFlag\\\"\"   OP =\"=\"    EXP2 =\"1\"    LOGIC =\"and\" ) WHERE(    EXP1 =\"\\\"Production\\\".\\\"Product\\\".\\\"ProductID\\\"\"   OP =\"in\" NEST = PBSELECT( VERSION(400) TABLE(NAME=\"Sales.SpecialOfferProduct\" ) COLUMN(NAME=\"Sales.SpecialOfferProduct.ProductID\"))) ) ORDER(NAME=\"Production.Product.ProductID\" ASC=yes )")]
    #endregion
    [DwSort("product_productnumber A")]
    public class D_Dddw_Order_Production
    {
        [DwColumn("Production.Product", "Name")]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [DwColumn("Production.Product", "ProductNumber")]
        [StringLength(25)]
        public string Product_Productnumber { get; set; }

        [DwColumn("Production.Product", "Color")]
        [StringLength(15)]
        public string Product_Color { get; set; }

        [DwColumn("Production.Product", "ListPrice")]
        public decimal Product_Listprice { get; set; }

        [DwColumn("Production.Product", "Size")]
        [StringLength(5)]
        public string Product_Size { get; set; }

        [DwColumn("Production.Product", "ProductSubcategoryID")]
        public int? Product_Productsubcategoryid { get; set; }

        [DwColumn("Production.Product", "ProductModelID")]
        public int? Product_Productmodelid { get; set; }

        [DwColumn("Production.ProductCategory", "Name")]
        [StringLength(50)]
        public string Productcategory_Name { get; set; }

        [DwColumn("Production.ProductSubcategory", "ProductCategoryID")]
        public int Productsubcategory_Productcategoryid { get; set; }

        [DwColumn("Production.ProductSubcategory", "Name")]
        [StringLength(50)]
        public string Productsubcategory_Name { get; set; }

        [DwColumn("Production.ProductModel", "Name")]
        [StringLength(50)]
        public string Productmodel_Name { get; set; }

        [SqlDefaultValue("autoincrement")]
        [DwColumn("Production.Product", "ProductID")]
        public int Product_Productid { get; set; }

    }

}