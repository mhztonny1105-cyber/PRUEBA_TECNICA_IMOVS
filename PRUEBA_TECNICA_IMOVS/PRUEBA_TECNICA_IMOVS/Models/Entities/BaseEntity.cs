using System;
using System.ComponentModel.DataAnnotations;


namespace CompanyManagement.Api.Models.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}