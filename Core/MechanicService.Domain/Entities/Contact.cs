﻿namespace MechanicService.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Isread { get; set; }
        public DateTime SendDate { get; set; }
    }
}
