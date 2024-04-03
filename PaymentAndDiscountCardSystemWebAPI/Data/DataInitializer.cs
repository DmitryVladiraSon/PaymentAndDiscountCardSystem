using PaymentAndDiscountCardSystemDAL.Repositories.ProductRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Products;

namespace PaymentAndDiscountCardSystemWebAPI.Data
{
    public class DataInitializer
    {
        private readonly IProductRepository _productRepository;

        public DataInitializer(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void InitializeProducts(int countProducts)
        {

            for (int i = 0; i < countProducts; i++)
            {
                _productRepository.Create(new ProductDTO
                {
                    Name = $"Product {i + 1}",
                    Description = "Product's description",
                    Count = 10 + i,
                    Price = 10000 + i * 1000
                });
            }

            //    _productRepository.Create(new ProductViewModel { Name = "Ноутбук ASUS", Description = "15.6 дюймов, Intel Core i5, 8 ГБ ОЗУ, 512 ГБ SSD", Count = 10, Price = 55000 });
            //    _productRepository.Create(new ProductViewModel { Name = "Смартфон Samsung Galaxy S21", Description = "6.2 дюйма, Exynos 2100, 8 ГБ ОЗУ, 128 ГБ", Count = 20, Price = 70000 });
            //    _productRepository.Create(new ProductViewModel { Name = "Телевизор LG 55SM8600", Description = "55 дюймов, 4K, Smart TV, WebOS", Count = 5, Price = 65000 });
            //    _productRepository.Create(new ProductViewModel { Name = "Наушники Apple AirPods Pro", Description = "Беспроводные, с шумоподавлением", Count = 50, Price = 20000 });
            //    _productRepository.Create(new ProductViewModel { Name = "Фотокамера Canon EOS R6", Description = "Зеркальная, 20 Мп, 4K видео", Count = 3, Price = 250000 });
            //    _productRepository.Create(new ProductViewModel { Name = "Кондиционер Midea MAP12S1TBL", Description = "12000 БТУ/ч, энергетический класс A+++", Count = 8, Price = 35000 });
            //    _productRepository.Create(new ProductViewModel { Name = "Стиральная машина Bosch WAT28468RU", Description = "8 кг, 1400 об/мин, энергетический класс A+++", Count = 12, Price = 38000 });
            //    _productRepository.Create(new ProductViewModel { Name = "Микроволновая печь Panasonic NN-ST67KSBPQ", Description = "27 л, 1000 Вт, инверторный нагрев", Count = 25, Price = 15000 });


        }
    }
}
