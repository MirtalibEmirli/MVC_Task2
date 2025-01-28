using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;

namespace MVC_Task2.Components
{
    public class SliderViewComponent:ViewComponent
    {
        List<string> items = new List<string>()
        {
            "https://www.hostinger.co.uk/tutorials/wp-content/uploads/sites/2/2019/03/freelancer-1024x502.png",
            "https://www.hostinger.com/tutorials/wp-content/uploads/sites/2/2019/03/best-freelance-websites-3.png",
            "https://media.istockphoto.com/id/1415537841/photo/asian-graphic-designer-working-in-office-artist-creative-designer-illustrator-graphic-skill.jpg?s=612x612&w=0&k=20&c=Cot30JpGiYsAA0SdsNtusecbHTKu_fyMBi1BT5i8GyY=",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSg83_c8zkUyHZS620lMMbZapm6V6R3eEfy8w&s",
            "https://clockify.me/learn/wp-content/uploads/2023/04/Freelance-websites-cover.jpg",
            "https://bitbytesoft.com/wp-content/uploads/2022/05/Best-Freelance-Websites.jpg",
            "https://cdn.prod.website-files.com/5ec7dad2e6f6295a9e2a23dd/62585032f7041f0f9bbd55f9_Best-Freelance-Websites.jpg"
        };        
        public IViewComponentResult Invoke()
        {
            return View(items);  
        }

    }
}
