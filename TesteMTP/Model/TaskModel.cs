using System.ComponentModel.DataAnnotations;
using TesteMTP.Enum;

namespace TesteMTP.Model
{
    public class TaskModel
    {
        [Key]
        public int idTask { get; set; }
        public string strDescription { get; set; }
        public StatusEnum idStatus { get; set; }
        public DateTime dtTask { get; set; }
        public DateTime dtCreation {  get; set; }
        public DateTime dtModification { get; set; }
    }
}
