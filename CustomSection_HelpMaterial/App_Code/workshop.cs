using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

/// <summary>
/// Summary description for Ingredient
/// </summary>
/// 

[TableName("workshop")]
[PrimaryKey("id", autoIncrement = true)]
[DataContract(Name="workshop", Namespace = "")]
public class Workshop
{
    [DataMember(Name="id")]
    [Column("id")]
    [PrimaryKeyColumn(Name = "PK_structure")]
    public int Id { get; set; }

    [Column("name")]
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [Column("description")]
    [DataMember(Name = "description")]
    public string Description { get; set; }

    [Column("date")]
    [DataMember(Name = "date")]
    [NullSetting(NullSetting = NullSettings.Null)]
    public DateTime Date { get; set; }

    [Column("location")]
    [DataMember(Name = "location")]
    [NullSetting(NullSetting = NullSettings.Null)]
    public string Location { get; set; }
}