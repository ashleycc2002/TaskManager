using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainn1
{
    [Table("Tasks", Schema = "dbo")]
    // [MetadataType(typeof(TaskMetaData))]
    public partial class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDecreacion { get; set; }
        public string Estado { get; set; }
        public int Prioridad { get; set; }


    }

}




