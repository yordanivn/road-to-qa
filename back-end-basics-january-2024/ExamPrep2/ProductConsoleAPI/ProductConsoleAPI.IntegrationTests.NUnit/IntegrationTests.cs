using Microsoft.EntityFrameworkCore;
using ProductConsoleAPI.Business;
using ProductConsoleAPI.Business.Contracts;
using ProductConsoleAPI.Data.Models;
using ProductConsoleAPI.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace ProductConsoleAPI.IntegrationTests.NUnit
{
    public  class IntegrationTests
    {
        private TestProductsDbContext dbContext;
        private IProductsManager productsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestProductsDbContext();
            this.productsManager = new ProductsManager(new ProductsRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddProductAsync_ShouldAddNewProduct()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            var dbProduct = await this.dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == newProduct.ProductCode);

            Assert.NotNull(dbProduct);
            Assert.AreEqual(newProduct.ProductName, dbProduct.ProductName);
            Assert.AreEqual(newProduct.Description, dbProduct.Description);
            Assert.AreEqual(newProduct.Price, dbProduct.Price);
            Assert.AreEqual(newProduct.Quantity, dbProduct.Quantity);
            Assert.AreEqual(newProduct.OriginCountry, dbProduct.OriginCountry);
            Assert.AreEqual(newProduct.ProductCode, dbProduct.ProductCode);
        }

        //Negative test
        [Test]
        public async Task AddProductAsync_TryToAddProductWithInvalidCredentials_ShouldThrowException()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = -1m,
                Quantity = 100,
                Description = "Anything for description"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await productsManager.AddAsync(newProduct));
            var actual = await dbContext.Products.FirstOrDefaultAsync(c => c.ProductCode == newProduct.ProductCode);

            Assert.IsNull(actual);
            Assert.That(ex?.Message, Is.EqualTo("Invalid product!"));

        }

        [Test]
        public async Task DeleteProductAsync_WithValidProductCode_ShouldRemoveProductFromDb()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);
            await productsManager.DeleteAsync(newProduct.ProductCode);

            var dbProduct = await this.dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == newProduct.ProductCode);

            // Act

            // Assert
            Assert.Null(dbProduct);
        }

        [Test]
        public async Task DeleteProductAsync_TryToDeleteWithNullOrWhiteSpaceProductCode_ShouldThrowException()
        {
            // Arrange
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);


            // Act
            var exception=Assert.ThrowsAsync<ArgumentException>(() => productsManager.DeleteAsync(null));

            // Assert
            Assert.NotNull(exception);
            Assert.That(exception.Message, Is.EqualTo("Product code cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenProductsExist_ShouldReturnAllProducts()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            // Act
            var allProducts = await productsManager.GetAllAsync();

            // Assert
            Assert.That(allProducts.Count(), Is.EqualTo(1));
            Assert.NotNull(allProducts);
        }

        [Test]
        public async Task GetAllAsync_WhenNoProductsExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange
 
            // Act
            var allProducts = Assert.ThrowsAsync<KeyNotFoundException>(() =>  productsManager.GetAllAsync());

            // Assert
            
            Assert.That(allProducts.Message,Is.EqualTo("No product found."));
        }

        [Test]
        public async Task SearchByOriginCountry_WithExistingOriginCountry_ShouldReturnMatchingProducts()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            // Act
            var result=await productsManager.SearchByOriginCountry(newProduct.OriginCountry);
            var dbContext = result.Single();

            // Assert
            Assert.NotNull(result);
            Assert.That(dbContext.OriginCountry, Is.EqualTo(newProduct.OriginCountry));
            Assert.That(dbContext.ProductName, Is.EqualTo(newProduct.ProductName));
            Assert.That(dbContext.ProductCode, Is.EqualTo(newProduct.ProductCode));
            Assert.That(dbContext.Price, Is.EqualTo(newProduct.Price));
            Assert.That(dbContext.Quantity, Is.EqualTo(newProduct.Quantity));
            Assert.That(dbContext.Description, Is.EqualTo(newProduct.Description));
        }

        [Test]
        public async Task SearchByOriginCountryAsync_WithNonExistingOriginCountry_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            // Act
            var searchCountry = "Spain";
            var result = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.SearchByOriginCountry(searchCountry));


            // Assert
            Assert.That(result.Message, Is.EqualTo("No product found with the given first name."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidProductCode_ShouldReturnProduct()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            // Act
            var result = await productsManager.GetSpecificAsync(newProduct.ProductCode);


            // Assert
            Assert.NotNull(result);
            Assert.That(result.OriginCountry, Is.EqualTo(newProduct.OriginCountry));
            Assert.That(result.ProductName, Is.EqualTo(newProduct.ProductName));
            Assert.That(result.ProductCode, Is.EqualTo(newProduct.ProductCode));
            Assert.That(result.Price, Is.EqualTo(newProduct.Price));
            Assert.That(result.Quantity, Is.EqualTo(newProduct.Quantity));
            Assert.That(result.Description, Is.EqualTo(newProduct.Description));
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidProductCode_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            // Act
            var wrongProductCode = "AB121";
            var result = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.GetSpecificAsync(wrongProductCode));


            // Assert
            Assert.That(result.Message, Is.EqualTo($"No product found with product code: {wrongProductCode}"));
        }
   

        [Test]
        public async Task UpdateAsync_WithValidProduct_ShouldUpdateProduct()
        {
           // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);
            newProduct.OriginCountry = "Spain";
            await productsManager.UpdateAsync(newProduct);

            
            // Act
            var result = await productsManager.SearchByOriginCountry(newProduct.OriginCountry);
            var dbContext = result.Single();

            // Assert
            Assert.NotNull(result);
            Assert.That(dbContext.OriginCountry, Is.EqualTo(newProduct.OriginCountry));
            Assert.That(dbContext.ProductName, Is.EqualTo(newProduct.ProductName));
            Assert.That(dbContext.ProductCode, Is.EqualTo(newProduct.ProductCode));
            Assert.That(dbContext.Price, Is.EqualTo(newProduct.Price));
            Assert.That(dbContext.Quantity, Is.EqualTo(newProduct.Quantity));
            Assert.That(dbContext.Description, Is.EqualTo(newProduct.Description));

        }

        [Test]
        public async Task UpdateAsync_WithInvalidProduct_ShouldThrowValidationException()
        {
            // Arrange

            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            newProduct.OriginCountry = new string('A', 500);
           
            //var result=Assert.ThrowsAsync<ValidationException>(() => productsManager.UpdateAsync(newProduct));
            
            Assert.ThrowsAsync<ValidationException>(() => productsManager.UpdateAsync(newProduct));
            
            
        }
    }
}
