using System.ComponentModel.DataAnnotations;

namespace Tugas4MCC71.Models
{
    public class Division
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
