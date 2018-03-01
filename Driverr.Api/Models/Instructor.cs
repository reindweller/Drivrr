using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Driverr.Api.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid StateId { get; set; }
        public virtual State State { get; set; }
        public Guid? SuburbId { get; set; }
        public virtual Suburb Suburb { get; set; }
        //public string PostCode { get; set; }
        public string Address { get; set; }
        public string School { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Info { get; set; }
        //public byte[] ProfilePic { get; set; }
        public double Price { get; set; }
        public string Language { get; set; }
    }

    public class InstructorViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        public Guid StateId { get; set; }
        public string State { get; set; }
        public Guid SuburbId { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string School { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Info { get; set; }
        //public byte[] ProfilePic { get; set; }
        public double Price { get; set; }
        public string Language { get; set; }

        public IFormFile ProfilePic { get; set; }
    }
}
