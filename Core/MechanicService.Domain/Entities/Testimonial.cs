﻿namespace MechanicService.Domain.Entities
{
    public class Testimonial : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAppear { get; set; }
    }
}
