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
    [DataWindow("d_person_filter", DwStyle.Default)]
    public class D_Person_Filter
    {
        [DwChild("Persontype", "Typedesc", typeof(D_Dddw_Persontype))]
        [DwColumn("persontype")]
        public string Persontype { get; set; }

    }

}