using Microsoft.AspNetCore.Razor.TagHelpers;
using MVC_Task2.Entities.Concretes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MVC_Task2.TagHelpers
{
    [HtmlTargetElement("user-list")]
    public class UserListTagHelper : TagHelper

    {
        public List<User> Users { get; set; }
        public UserListTagHelper()
        {
            var data = Read();
            Users = JsonSerializer.Deserialize<List<User>>(data);   
        }

        private const string formatName = "sort";

        [HtmlAttributeName(formatName)]   
        public string sortFormat { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
           
            StringBuilder sb = new();
            if (sortFormat == null || sortFormat.ToLower() == "a-z")
            {
                var sortedList = Users.OrderBy(u=>u.FirstName).ToList();    
                foreach (var item in sortedList)
                {
                    
                    sb.AppendFormat("<h3><a  href='/user/details/{0}'>{1}</a ></h3>", item.Id, item.FirstName);
                }
            }
            else { 
                var sortedList = Users.OrderByDescending(u=>u.FirstName);
                foreach (var item in sortedList)
                {
                    sb.AppendFormat("<h3><a href='/user/details/{0}>{1}</a></h3>",item.Id,item.FirstName);
                }
            }
            output.Content.SetHtmlContent(sb.ToString());
        }

        public string Read()
        {
            string path = @"Helpers\users.json";
            string json = System.IO.File.ReadAllText(path);
            return json;
        }
    }
}
