using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SnapObjects.Data;
using DWNet.Data;

namespace Appeon.DataStoreDemo.SqlAnywhere
{
    [DataWindow("d_productphoto", DwStyle.Grid)]
    [Table("ProductPhoto", Schema = "Production")]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Production.ProductPhoto\" ) @(_COLUMNS_PLACEHOLDER_) ) ORDER(NAME=\"Production.ProductPhoto.ModifiedDate\" ASC=no)")]
    #endregion
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyAndConcurrencyCheckColumns)]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    public class D_Productphoto
    {
        [Key]
        [Identity]
        [DwColumn("ProductPhoto", "ProductPhotoID")]
        public int Productphotoid { get; set; }

        [ConcurrencyCheck]
        [DwColumn("ProductPhoto", "LargePhotoFileName")]
        public string Largephotofilename { get; set; }

        [ConcurrencyCheck]
        [SqlDefaultValue("(getdate())")]
        [DwColumn("ProductPhoto", "ModifiedDate")]
        public DateTime Modifieddate { get; set; }

    }

}