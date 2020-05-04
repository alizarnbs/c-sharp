using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD_Tasks.Models;
using Newtonsoft.Json.Linq;

namespace CRUD_Tasks.Pages
{
    public class EditTaskModel : PageModel
    {
        [BindProperty]
        public Task _task { get; set; }
        public static string _title { get; set; }
        private string filePath = "/Users/ali.zar/Projects/CRUD_Tasks/CRUD_Tasks/Data/tasks.json";
        public void OnGet(string title)
        {
            _title = title;
        }

        public void OnPost()
        {
            try
            {
                var json = System.IO.File.ReadAllText(filePath);
                var jObject = JObject.Parse(json);
                JArray taskArray = jObject.GetValue("tasks") as JArray;
                foreach (var task in taskArray.Where(t => t["title"].Value<string>() == _title))
                {
                    task["description"] = _task.description;
                    task["status"] = _task.status;
                    task["priority"] = _task.priority;
                }

                jObject["tasks"] = taskArray;
                string newJson = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(filePath, newJson);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
