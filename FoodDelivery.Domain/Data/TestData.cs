using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Data;

public static class TestData
{
    public static List<Category> Categories { get; } = new()
    {
        new Category
        {
            Id = 1,
            Name = "Пицца"
        },

        new Category
        {
            Id = 2,
            Name = "Бургеры"
        },

        new Category
        {
            Id = 3,
            Name = "Закуски"
        },

        new Category
        {
            Id = 4,
            Name = "Салаты"
        },

        new Category
        {
            Id = 5,
            Name = "Супы"
        },

        new Category
        {
            Id = 6,
            Name = "Паста"
        },

        new Category
        {
            Id = 7,
            Name = "Роллы"
        },

        new Category
        {
            Id = 8,
            Name = "Десерты"
        },

        new Category
        {
            Id = 9,
            Name = "Напитки"
        },

        new Category
        {
            Id = 10,
            Name = "Завтраки"
        }
    };

    public static List<Restaurant> Restaurants { get; } = new()
    {
        new Restaurant
        {
            Id = 1,
            Name = "Додо Пицца",
            Address = "просп. Ленина, 1",
            Rating = 4.8,
            OpeningTime = new TimeOnly(10, 0),
            ClosingTime = new TimeOnly(23, 0)
        },

        new Restaurant
        {
            Id = 2,
            Name = "Burger King",
            Address = "ул. Тухачевского, 80",
            Rating = 4.6,
            OpeningTime = new TimeOnly(9, 0),
            ClosingTime = new TimeOnly(22, 0)
        },

        new Restaurant
        {
            Id = 3,
            Name = "Tanuki",
            Address = "ул. Коммунистическая, 17",
            Rating = 4.9,
            OpeningTime = new TimeOnly(11, 0),
            ClosingTime = new TimeOnly(23, 30)
        },

        new Restaurant
        {
            Id = 4,
            Name = "Salad Bar",
            Address = "ул. Гагарина, 66",
            Rating = 4.3,
            OpeningTime = new TimeOnly(9, 0),
            ClosingTime = new TimeOnly(21, 0)
        },

        new Restaurant
        {
            Id = 5,
            Name = "Мушмула",
            Address = "ул. Галактионовская, 133",
            Rating = 4.6,
            OpeningTime = new TimeOnly(10, 0),
            ClosingTime = new TimeOnly(22, 0)
        },

        new Restaurant
        {
            Id = 6,
            Name = "Дари Дури",
            Address = "ул. Дачная, 12",
            Rating = 4.4,
            OpeningTime = new TimeOnly(8, 0),
            ClosingTime = new TimeOnly(22, 0)
        },

        new Restaurant
        {
            Id = 7,
            Name = "Surf Coffee",
            Address = "ул. Полевая, 28",
            Rating = 4.8,
            OpeningTime = new TimeOnly(8, 0),
            ClosingTime = new TimeOnly(21, 0)
        },

        new Restaurant
        {
            Id = 8,
            Name = "Чипа Лучо",
            Address = "ул. Ново-Садовая, 228",
            Rating = 4.2,
            OpeningTime = new TimeOnly(10, 0),
            ClosingTime = new TimeOnly(23, 0)
        },

        new Restaurant
        {
            Id = 9,
            Name = "Белотурка",
            Address = "ул. Молодогвардейская,127",
            Rating = 4.8,
            OpeningTime = new TimeOnly(7, 0),
            ClosingTime = new TimeOnly(20, 0)
        },

        new Restaurant
        {
            Id = 10,
            Name = "Gellert",
            Address = "ул. Владимирская, 38",
            Rating = 4.0,
            OpeningTime = new TimeOnly(10, 0),
            ClosingTime = new TimeOnly(22, 0)
        }
    };

    public static List<Customer> Customers { get; } = new()
    {
        new Customer
        {
            Id = 1,
            LastName = "Мэдисон",
            FirstName = "Илья",
            Patronymic = "Сергеевич",
            Phone = "+79990000001",
            DeliveryAddress = "Самара, ул. Ленина, д. 1"
        },

        new Customer
        {
            Id = 2,
            LastName = "Зырянов",
            FirstName = "Кирилл",
            Patronymic = null,
            Phone = "+79990000002",
            DeliveryAddress = "Самара, ул. Пушкина, д. 10"
        },

        new Customer
        {
            Id = 3,
            LastName = "Ван дер Сар",
            FirstName = "Эдвин",
            Patronymic = null,
            Phone = "+79990000003",
            DeliveryAddress = "Самара, ул. Гагарина, д. 15"
        },

        new Customer
        {
            Id = 4,
            LastName = "Бобков",
            FirstName = "Геннадий",
            Patronymic = "Андреевич",
            Phone = "+79990000004",
            DeliveryAddress = "Самара, ул. Мира, д. 20"
        },

        new Customer
        {
            Id = 5,
            LastName = "Кузнецов",
            FirstName = "Дмитрий",
            Patronymic = "Алексеевич",
            Phone = "+79990000005",
            DeliveryAddress = "Самара, ул. Советская, д. 5"
        },

        new Customer
        {
            Id = 6,
            LastName = "Гриффин",
            FirstName = "Пётр",
            Patronymic = null,
            Phone = "+79990000006",
            DeliveryAddress = "Самара, ул. Центральная, д. 8"
        },

        new Customer
        {
            Id = 7,
            LastName = "Соколова",
            FirstName = "Ольга",
            Patronymic = "Викторовна",
            Phone = "+79990000007",
            DeliveryAddress = "Москва, ул. Школьная, д. 12"
        },

        new Customer
        {
            Id = 8,
            LastName = "Петров",
            FirstName = "Денис",
            Patronymic = "Игоревич",
            Phone = "+79990000008",
            DeliveryAddress = "Самара, ул. Молодёжная, д. 7"
        },

        new Customer
        {
            Id = 9,
            LastName = "Морозова",
            FirstName = "Екатерина",
            Patronymic = "Сергеевна",
            Phone = "+79990000009",
            DeliveryAddress = "Самара, ул. Новая, д. 18"
        },

        new Customer
        {
            Id = 10,
            LastName = "Александров",
            FirstName = "Николай",
            Patronymic = "Ильич",
            Phone = "+79990000010",
            DeliveryAddress = "Самара, ул. Садовая, д. 25"
        }
    };

    public static List<Dish> Dishes { get; } = new()
    {
        new Dish
        {
            Id = 1,
            Name = "Пицца Пепперони",
            WeightGrams = 500,
            Price = 750m,
            CategoryId = 1,
            Category = Categories[0]
        },

        new Dish
        {
            Id = 2,
            Name = "Пицца 4 сыра",
            WeightGrams = 550,
            Price = 650m,
            CategoryId = 1,
            Category = Categories[0]
        },

        new Dish
        {
            Id = 3,
            Name = "Бургер с рваной говядиной",
            WeightGrams = 300,
            Price = 650m,
            CategoryId = 2,
            Category = Categories[1]
        },

        new Dish
        {
            Id = 4,
            Name = "Чизбургер",
            WeightGrams = 320,
            Price = 500m,
            CategoryId = 2,
            Category = Categories[1]
        },

        new Dish
        {
            Id = 5,
            Name = "Картофель фри",
            WeightGrams = 150,
            Price = 220m,
            CategoryId = 3,
            Category = Categories[2]
        },

        new Dish
        {
            Id = 6,
            Name = "Цезарь с курицей",
            WeightGrams = 280,
            Price = 420m,
            CategoryId = 4,
            Category = Categories[3]
        },

        new Dish
        {
            Id = 7,
            Name = "Борщ",
            WeightGrams = 350,
            Price = 380m,
            CategoryId = 5,
            Category = Categories[4]
        },

        new Dish
        {
            Id = 8,
            Name = "Паста Карбонара",
            WeightGrams = 400,
            Price = 590m,
            CategoryId = 6,
            Category = Categories[5]
        },

        new Dish
        {
            Id = 9,
            Name = "Роллы Филадельфия",
            WeightGrams = 250,
            Price = 680m,
            CategoryId = 7,
            Category = Categories[6]
        },

        new Dish
        {
            Id = 10,
            Name = "Чизкейк",
            WeightGrams = 180,
            Price = 300m,
            CategoryId = 8,
            Category = Categories[7]
        },

        new Dish
        {
            Id = 9,
            Name = "Капучино",
            WeightGrams = 300,
            Price = 450m,
            CategoryId = 9,
            Category = Categories[8]
        },

        new Dish
        {
            Id = 10,
            Name = "Сырники",
            WeightGrams = 250,
            Price = 350m,
            CategoryId = 10,
            Category = Categories[9]
        }
    };

    public static List<Order> Orders { get; } = new()
    {
        new Order
        {
            Id = 1,
            CustomerId = 1,
            Customer = Customers[0],
            RestaurantId = 1,
            Restaurant = Restaurants[0],
            CreatedAt = new DateTime(2026, 9, 1, 12, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 1, 12, 35, 0),
            TotalAmount = 1400m
        },

        new Order
        {
            Id = 2,
            CustomerId = 2,
            Customer = Customers[1],
            RestaurantId = 1,
            Restaurant = Restaurants[0],
            CreatedAt = new DateTime(2026, 9, 2, 13, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 2, 13, 50, 0),
            TotalAmount = 2050m
        },

        new Order
        {
            Id = 3,
            CustomerId = 3,
            Customer = Customers[2],
            RestaurantId = 2,
            Restaurant = Restaurants[1],
            CreatedAt = new DateTime(2026, 9, 3, 14, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 3, 14, 25, 0),
            TotalAmount = 950m
        },

        new Order
        {
            Id = 4,
            CustomerId = 4,
            Customer = Customers[3],
            RestaurantId = 2,
            Restaurant = Restaurants[1],
            CreatedAt = new DateTime(2026, 9, 4, 15, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 4, 15, 45, 0),
            TotalAmount = 1220m
        },

        new Order
        {
            Id = 5,
            CustomerId = 5,
            Customer = Customers[4],
            RestaurantId = 3,
            Restaurant = Restaurants[2],
            CreatedAt = new DateTime(2026, 9, 5, 16, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 5, 16, 30, 0),
            TotalAmount = 1360m
        },

        new Order
        {
            Id = 6,
            CustomerId = 6,
            Customer = Customers[5],
            RestaurantId = 3,
            Restaurant = Restaurants[2],
            CreatedAt = new DateTime(2026, 9, 6, 17, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 6, 17, 40, 0),
            TotalAmount = 1270m
        },

        new Order
        {
            Id = 7,
            CustomerId = 7,
            Customer = Customers[6],
            RestaurantId = 4,
            Restaurant = Restaurants[3],
            CreatedAt = new DateTime(2026, 9, 7, 18, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 7, 18, 20, 0),
            TotalAmount = 970m
        },

        new Order
        {
            Id = 8,
            CustomerId = 8,
            Customer = Customers[7],
            RestaurantId = 5,
            Restaurant = Restaurants[4],
            CreatedAt = new DateTime(2026, 9, 8, 19, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 8, 19, 55, 0),
            TotalAmount = 1150m
        },

        new Order
        {
            Id = 9,
            CustomerId = 9,
            Customer = Customers[8],
            RestaurantId = 6,
            Restaurant = Restaurants[5],
            CreatedAt = new DateTime(2026, 9, 9, 10, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 9, 10, 15, 0),
            TotalAmount = 590m
        },

        new Order
        {
            Id = 10,
            CustomerId = 10,
            Customer = Customers[9],
            RestaurantId = 1,
            Restaurant = Restaurants[0],
            CreatedAt = new DateTime(2026, 9, 10, 11, 0, 0),
            DeliveredAt = new DateTime(2026, 9, 10, 11, 30, 0),
            TotalAmount = 1050m
        }
    };

    public static List<OrderItem> OrderItems { get; } = new()
    {
        new OrderItem
        {
            Id = 1,
            OrderId = 1,
            DishId = 1,
            Dish = Dishes[0],
            Quantity = 1,
            Price = 750m
        },

        new OrderItem
        {
            Id = 2,
            OrderId = 1,
            DishId = 2,
            Dish = Dishes[1],
            Quantity = 1,
            Price = 650m
        },

        new OrderItem
        {
            Id = 3,
            OrderId = 2,
            DishId = 1,
            Dish = Dishes[0],
            Quantity = 1,
            Price = 750m
        },

        new OrderItem
        {
            Id = 4,
            OrderId = 2,
            DishId = 2,
            Dish = Dishes[1],
            Quantity = 2,
            Price = 650m
        },

        new OrderItem
        {
            Id = 5,
            OrderId = 3,
            DishId = 3,
            Dish = Dishes[2],
            Quantity = 1,
            Price = 650m
        },

        new OrderItem
        {
            Id = 6,
            OrderId = 3,
            DishId = 5,
            Dish = Dishes[4],
            Quantity = 1,
            Price = 220m
        },

        new OrderItem
        {
            Id = 7,
            OrderId = 4,
            DishId = 4,
            Dish = Dishes[3],
            Quantity = 2,
            Price = 500m
        },

        new OrderItem
        {
            Id = 8,
            OrderId = 4,
            DishId = 5,
            Dish = Dishes[4],
            Quantity = 1,
            Price = 220m
        },

        new OrderItem
        {
            Id = 9,
            OrderId = 5,
            DishId = 6,
            Dish = Dishes[5],
            Quantity = 1,
            Price = 420m
        },

        new OrderItem
        {
            Id = 10,
            OrderId = 5,
            DishId = 9,
            Dish = Dishes[8],
            Quantity = 1,
            Price = 680m
        },

        new OrderItem
        {
            Id = 11,
            OrderId = 6,
            DishId = 9,
            Dish = Dishes[8],
            Quantity = 1,
            Price = 680m
        },

        new OrderItem
        {
            Id = 12,
            OrderId = 6,
            DishId = 10,
            Dish = Dishes[9],
            Quantity = 1,
            Price = 300m
        },

        new OrderItem
        {
            Id = 13,
            OrderId = 7,
            DishId = 7,
            Dish = Dishes[6],
            Quantity = 1,
            Price = 380m
        },

        new OrderItem
        {
            Id = 14,
            OrderId = 7,
            DishId = 8,
            Dish = Dishes[7],
            Quantity = 1,
            Price = 590m
        },

        new OrderItem
        {
            Id = 15,
            OrderId = 8,
            DishId = 3,
            Dish = Dishes[2],
            Quantity = 1,
            Price = 650m
        },

        new OrderItem
        {
            Id = 16,
            OrderId = 8,
            DishId = 4,
            Dish = Dishes[3],
            Quantity = 1,
            Price = 500m
        },

        new OrderItem
        {
            Id = 17,
            OrderId = 9,
            DishId = 8,
            Dish = Dishes[7],
            Quantity = 1,
            Price = 590m
        },

        new OrderItem
        {
            Id = 18,
            OrderId = 10,
            DishId = 1,
            Dish = Dishes[0],
            Quantity = 1,
            Price = 750m
        },

        new OrderItem
        {
            Id = 19,
            OrderId = 10,
            DishId = 5,
            Dish = Dishes[4],
            Quantity = 1,
            Price = 220m
        }
    };

    // связка orderitems с orders
    static TestData()
    {
        foreach (var order in Orders)
        {
            order.Items = OrderItems
                .Where(item => item.OrderId == order.Id)
                .ToList();
        }
    }
}

