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
    [DataWindow("d_subreport_filter_gc", DwStyle.Default)]
    public class D_Subreport_Filter_Gc
    {
        [DwChild("Productcategoryid", "Name", typeof(D_Dddw_Category), AutoRetrieve = true)]
        [DwColumn("categoryid")]
        public double? Categoryid { get; set; }

        [DwChild("Productsubcategoryid", "Name", typeof(D_Dddw_Subcategory), AutoRetrieve = true)]
        [DwColumn("subcategoryid")]
        public double? Subcategoryid { get; set; }

        [DwColumn("year")]
        public string Year { get; set; }

        [DwColumn("Annual")]
        public string Annual { get; set; }

    }

}