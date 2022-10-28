using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tugas4MCC71.Models
{
    public class ViewModelDivision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Division_Id { get; set; }
        public List<SelectListItem> Divisions { get; set; }
    }
}
