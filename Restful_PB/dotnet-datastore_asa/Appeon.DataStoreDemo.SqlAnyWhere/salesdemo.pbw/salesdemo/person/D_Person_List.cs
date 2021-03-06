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
    [DataWindow("d_person_list", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM Person.Person \r\n "
                  +"Where Person.Person.persontype = :personType")]
    #endregion
    [DwParameter("personType", typeof(string))]
    [DwSort("businessentityid A")]
    [DwKeyModificationStrategy(UpdateSqlStrategy.DeleteThenInsert)]
    [UpdateWhereStrategy(UpdateWhereStrategy.KeyColumns)]
    [Table("Person", Schema = "Person")]
    public class D_Person_List
    {
        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "businessentityid")]
        [Key]
        public int Businessentityid { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwChild("Persontype", "Typedesc", typeof(D_Dddw_Persontype), AutoRetrieve = true)]
        [DwColumn("Person.Person", "persontype")]
        public string Persontype { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "namestyle")]
        public bool Namestyle { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "title")]
        [StringLength(8)]
        public string Title { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "firstname")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "middlename")]
        [StringLength(50)]
        public string Middlename { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "lastname")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "suffix")]
        [StringLength(10)]
        public string Suffix { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "emailpromotion")]
        public int Emailpromotion { get; set; }

        [PropertySave(SaveStrategy.Ignore)]
        [DwColumn("Person.Person", "modifieddate", TypeName = "timestamp")]
        public DateTime Modifieddate { get; set; }

    }

}