using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{

    public interface IApplicationConfig : IEntity<Guid>
    {
        string AppName { get; set; }
    }

    public class ApplicationConfig : IApplicationConfig
    {
        //[Key, Required]
        //public int Id { get; set; }
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string AppName { get; set; }

    }

}
