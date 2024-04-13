namespace MechanicService.Persistence.Context
{
    public class MechanicServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-4M0OQRD\SQLEXPRESS;Database=MechanicService;User Id=pixxaer;Password=453885;Encrypt=false;TrustServerCertificate=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationCar> ReservationCars { get; set; }
        public DbSet<ReservationPerson> ReservationPersons { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<LocationCity> LocationCities { get; set; }
        public DbSet<LocationDistrict> LocationDistricts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Araba Model
            modelBuilder.Entity<CarModel>()
                .HasOne(p => p.CarBrand)
                .WithMany(b => b.CarModels)
                .HasForeignKey(p => p.BrandID);

            // Rezervasyonlar
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ReservationCar)
                .WithMany()
                .HasForeignKey(r => r.RezCarID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ReservationPerson)
                .WithMany()
                .HasForeignKey(r => r.RezPersonID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ReservationService)
                .WithMany()
                .HasForeignKey(r => r.RezServiceID);

            
            modelBuilder.Entity<ReservationCar>()
                .HasOne(rc => rc.CarModel)
                .WithMany()
                .HasForeignKey(rc => rc.ModelID);

            // Sehir Ilce
            modelBuilder.Entity<LocationDistrict>()
                .HasOne(p => p.LocationCity)
                .WithMany(b => b.LocationDistricts)
                .HasForeignKey(p => p.CityID);
        }
    }
}
