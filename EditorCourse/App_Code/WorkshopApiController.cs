using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

/// <summary>
/// Summary description for WorkshopController
/// </summary> 
[PluginController("Workshop")]
public class WorkshopApiController : UmbracoAuthorizedJsonController
{
    public Workshop PostSave(Workshop workshop) {
        if (workshop.Id > 0)
            DatabaseContext.Database.Update(workshop);
        else
        {
            workshop.Date = DateTime.Now;
            DatabaseContext.Database.Save(workshop);
        }
            

        return workshop;
    }

    public int DeleteById(int id) {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        return db.Delete<Workshop>(id);     
    }

    
    public Workshop GetById(int id) {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        var query = new Sql().Select("*").From("workshop").Where<Workshop>(x => x.Id == id);

        return db.Fetch<Workshop>(query).FirstOrDefault();
    }

    public IEnumerable<Workshop> GetByName(string name) {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        var query = new Sql().Select("*").From("workshop").Where("name LIKE '%" + name +"%'");
        return db.Fetch<Workshop>(query);
    }

    public IEnumerable<Workshop> GetAll()
    {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        var query = new Sql().Select("*").From("workshop");

        return db.Fetch<Workshop>(query);
    }
}