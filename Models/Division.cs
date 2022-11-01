using System.ComponentModel.DataAnnotations;
using Tugas4MCC71.Base;

namespace Tugas4MCC71.Models
{
    public class Division : BaseModel
    {
        public Division(int Division_Id, string Name)
        {
            this.Division_Id = Division_Id;
            this.Name = Name;
        }
        public Division()
        {

        }
        [Key]
        public int Division_Id { get; set; }
        public string Name { get; set; }
    }
}
