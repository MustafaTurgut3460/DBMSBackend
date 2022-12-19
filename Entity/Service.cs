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
        public int DeviceId { get; set; }

        [StringLength(100)]
        public string ServiceTitle { get; set; }

        [StringLength(500)]
        public string ServiceDesc { get; set; }

        [StringLength(50)]
        public string DeviceStatus { get; set; }

        [StringLength(50)]
        public string Time { get; set; }
        public int EmployeeId { get; set; }
    }
}