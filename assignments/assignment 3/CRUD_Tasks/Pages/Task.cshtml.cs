using System;
using System.Collections.Generic;
using System.Linq;
using CRUD_Tasks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace CRUD_Tasks.Pages
{
    public class TaskModel : PageModel
    {
        [BindProperty]
        public Task _task { get; set; }
        public List<Task> TaskList = new List<Task>();
        private string filePath = "/Users/ali.zar/Projects/CRUD_Tasks/CRUD_Tasks/Data/tasks.json";

        public void OnGet()
        {
            var json = System.IO.File.ReadAllText(filePath);
            try
            {
                var jObject = JObject.Parse(json);
                if (jObject != null)
                {
                    JArray taskArray = jObject.GetValue("tasks") as JArray;
                    foreach (var item in taskArray)
                    {
                        Task task = new Task();
                        task.title = item["title"].ToString();
                        task.description = item["description"].ToString();
                        task.status = item["status"].ToString();
                        task.priority = item["priority"].ToString();
                        TaskList.Add(task);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OnGetDelete(string title)
        {
            var json = System.IO.File.ReadAllText(filePath);
            try
            {
                var jObject = JObject.Parse(json);
                JArray taskArray = jObject.GetValue("tasks") as JArray;
                var taskToDelete = taskArray.FirstOrDefault(t => t["title"].Value<string>() == title);
                taskArray.Remove(taskToDelete);
                jObject["tasks"] = taskArray;
                string newJson = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(filePath, newJson);
                OnGet();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OnPost()
        {
            try
            {
                string newObject = "{'title': '" + _task.title
                    + "', 'description' : '" + _task.description
                    + "', 'status': '" + _task.status
                    + "', 'priority': '" + _task.priority + "'}";


                var json = System.IO.File.ReadAllText(filePath);
                var jObject = JObject.Parse(json);
                var taskArray = jObject.GetValue("tasks") as JArray;
                taskArray.Add(JObject.Parse(newObject));
                jObject["tasks"] = taskArray;
                string newJson = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(filePath, newJson);
                OnGet();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
