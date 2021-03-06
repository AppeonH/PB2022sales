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
    [DataWindow("d_person", DwStyle.Default)]
    #region DwSelectAttribute  
    [DwSelect("PBSELECT( VERSION(400) TABLE(NAME=\"Person.Person\" ) @(_COLUMNS_PLACEHOLDER_) WHERE(    EXP1 =\"Person.Person.BusinessEntityID\"   OP =\"=\"    EXP2 =\":ai_id\" ) ) ARG(NAME = \"ai_id\" TYPE = number)")]
    #endregion
    [DwParameter("ai_id", typeof(double?))]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [Table("Person", Schema = "Person")]
    public class D_Person
    {
        [DwColumn("Person.Person", "businessentityid")]
        [Key]
        public int Businessentityid { get; set; } = 0;

        [DwChild("Persontype", "Typedesc", typeof(D_Dddw_Persontype), AutoRetrieve = true)]
        [DwColumn("Person.Person", "persontype")]
        public string Persontype { get; set; }

        [DwColumn("Person.Person", "namestyle")]
        public bool Namestyle { get; set; }

        [DwColumn("Person.Person", "title")]
        [StringLength(8)]
        public string Title { get; set; }

        [DwColumn("Person.Person", "firstname")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [DwColumn("Person.Person", "middlename")]
        [StringLength(50)]
        public string Middlename { get; set; }

        [DwColumn("Person.Person", "lastname")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [DwColumn("Person.Person", "suffix")]
        [StringLength(10)]
        public string Suffix { get; set; }

        [DwColumn("Person.Person", "emailpromotion")]
        public int Emailpromotion { get; set; }

        [SqlDefaultValue("current server timestamp")]
        [DwColumn("Person.Person", "modifieddate", TypeName = "timestamp")]
        public DateTime Modifieddate { get; set; }

    }

}