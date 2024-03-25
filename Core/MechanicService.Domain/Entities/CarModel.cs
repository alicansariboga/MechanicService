﻿namespace MechanicService.Domain.Entities
{
    public class CarModel : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("BrandID")]
        public int BrandID { get; set; }
        public CarBrand CarBrand { get; set; }
        public string CarType { get; set; }
    }
}
