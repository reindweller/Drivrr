using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Driverr.Api.Models
{
    public class Suburb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid StateId { get; set; }
        public virtual State State { get; set; }

        public string PostCode { get; set; }
    }



}
