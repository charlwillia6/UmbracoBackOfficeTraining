using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;
using Umbraco.Web;

namespace EditorCourse.App_Code
{
    public class installer : ApplicationEventHandler
    {
        protected const string WorkshopSectionAlias = "workshops";

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //create the table if it does not exist
            var db = applicationContext.DatabaseContext.Database;
            if (db.TableExist("workshop") == false)
            {
                //table creation
                db.CreateTable<Workshop>(true);

                //test data creation
                WorkshopApiController ap = new WorkshopApiController();
                ap.PostSave(new Workshop() { Name = "Umbraco webinar", Date = DateTime.Now.AddDays(20), Description = "Learn all about Umbraco in this online webinar" });
                ap.PostSave(new Workshop() { Name = "Umbraco forms seminar", Date = DateTime.Now.AddDays(60), Description = "A full day forms seminar on Umbraco Forms" });
                ap.PostSave(new Workshop() { Name = "Umbraco hackerthon", Date = DateTime.Now.AddDays(100), Description = "Come and fix your favorite CMS and become a pull request king" });
            }

            // Gets a reference to the section if the section is already added
            Section section = applicationContext.Services.SectionService.GetByAlias(WorkshopSectionAlias);
            if (section != null) return;

            //Add a Workshop Section
            applicationContext.Services.SectionService.MakeNew("Workshops", WorkshopSectionAlias, "icon-hammer");


        }
    }
}