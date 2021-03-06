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
    [DataWindow("d_dddw_salesterritory", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Sales.SalesTerritory\" )  TABLE(NAME=\"Person.CountryRegion\" ) @(_COLUMNS_PLACEHOLDER_) JOIN (LEFT=\"Person.CountryRegion.CountryRegionCode\"    OP =\"=\"RIGHT=\"Sales.SalesTerritory.CountryRegionCode\" ))")]
    #endregion
    public class D_Dddw_Salesterritory
    {
        [Identity]
        [SqlDefaultValue("autoincrement")]
        [DwColumn("Sales.SalesTerritory", "TerritoryID")]
        public int Salesterritory_Territoryid { get; set; }

        [DwColumn("Sales.SalesTerritory", "Name")]
        [StringLength(50)]
        public string Salesterritory_Name { get; set; }

        [DwColumn("Sales.SalesTerritory", "CountryRegionCode")]
        [StringLength(3)]
        public string Salesterritory_Countryregioncode { get; set; }

        [DwColumn("Sales.SalesTerritory", "Group")]
        [StringLength(50)]
        public string Salesterritory_Group { get; set; }

        [DwColumn("Person.CountryRegion", "Name")]
        [StringLength(50)]
        public string Countryregion_Name { get; set; }

    }

}