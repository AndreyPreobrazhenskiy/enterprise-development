using FoodDelivery.Domain.Data;
using FoodDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Infrastructure.EfCore;

/// <summary>
/// Контекст базы данных приложения FoodDelivery
/// </summary>
public class FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Категории блюд
    /// </summary>
    public DbSet<Category> Categories => Set<Category>();

    /// <summary>
    /// Клиенты
    /// </summary>
    public DbSet<Customer> Customers => Set<Customer>();

    /// <summary>
    /// Блюда
    /// </summary>
    public DbSet<Dish> Dishes => Set<Dish>();

    /// <summary>
    /// Рестораны
    /// </summary>
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();

    /// <summary>
    /// Заказы
    /// </summary>
    public DbSet<Order> Orders => Set<Order>();

    /// <summary>
    /// Позиции заказов
    /// </summary>
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(e => e.Customer).WithMany().HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Restaurant).WithMany().HasForeignKey(e => e.RestaurantId).OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(e => e.Items).WithOne().HasForeignKey(oi => oi.OrderId).OnDelete(DeleteBehavior.Cascade);
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeliveredAt).HasColumnType("timestamp without time zone");
            entity.Ignore(e => e.TotalAmount);
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Restaurant).WithMany(r => r.Dishes).HasForeignKey(e => e.RestaurantId).OnDelete(DeleteBehavior.Restrict);
            entity.Property(e => e.Price).HasPrecision(18, 2);
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(TestData.Categories.Select(c => new { c.Id, c.Name }));
        modelBuilder.Entity<Customer>().HasData(TestData.Customers.Select(c => new { c.Id, c.LastName, c.FirstName, c.Patronymic, c.Phone, c.DeliveryAddress }));
        modelBuilder.Entity<Restaurant>().HasData(TestData.Restaurants.Select(r => new { r.Id, r.Name, r.Address, r.Rating, r.OpeningTime, r.ClosingTime }));
        modelBuilder.Entity<Dish>().HasData(TestData.Dishes.Select(d => new { d.Id, d.Name, d.WeightGrams, d.Price, d.CategoryId, d.RestaurantId }));
        modelBuilder.Entity<Order>().HasData(TestData.Orders.Select(o => new { o.Id, o.CustomerId, o.RestaurantId, o.CreatedAt, o.DeliveredAt }));
        modelBuilder.Entity<OrderItem>().HasData(TestData.OrderItems.Select(oi => new { oi.Id, oi.OrderId, oi.DishId, oi.Quantity }));
    }
}