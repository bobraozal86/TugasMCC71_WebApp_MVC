using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tugas4MCC71.Models
{
    public class Department
    {
        public Department(int Id, string Name, int Division_Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Division_Id = Division_Id;
        }
        public Department()
        {

        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Division")]
        public int Division_Id { get; set; }
        public Division Division { get; set; }
    }
}
