using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Service
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DeviceIds { get; set; }

        [StringLength(50)]
        public string DeviceStatus { get; set; }

        [StringLength(50)]
        public string Time { get; set; }
        public int EmployeeId { get; set; }
    }
}