using GardenConsoleAPI.Business;
using GardenConsoleAPI.Business.Contracts;
using GardenConsoleAPI.Data.Models;
using GardenConsoleAPI.DataAccess;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;



namespace GardenConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestPlantsDbContext dbContext;
        private IPlantsManager plantsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestPlantsDbContext();
            this.plantsManager = new PlantsManager(new PlantsRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddPlantAsync_ShouldAddNewPlant()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);
            var dbPlant = this.dbContext.Plants.FirstOrDefault(p => p.CatalogNumber == newPlant.CatalogNumber);
           

            // Assert
            Assert.NotNull(dbContext);
            Assert.AreEqual(newPlant.CatalogNumber, dbPlant.CatalogNumber);
            Assert.AreEqual(newPlant.Name, dbPlant.Name);
            Assert.AreEqual(newPlant.PlantType, dbPlant.PlantType);
            Assert.AreEqual(newPlant.FoodType, dbPlant.FoodType);
            Assert.AreEqual(newPlant.Quantity, dbPlant.Quantity);
            Assert.AreEqual(newPlant.IsEdible, dbPlant.IsEdible);
        }

        //Negative test
        [Test]
        public async Task AddPlantAsync_TryToAddPlantWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = new string('a',500),
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
           var ex = Assert.ThrowsAsync<ValidationException>(() => plantsManager.AddAsync(newPlant));
           var actual=dbContext.Plants.FirstOrDefault(p => p.CatalogNumber == newPlant.CatalogNumber);

            Assert.IsNull(actual);
           Assert.That(ex?.Message, Is.EqualTo("Invalid plant!"));

        }

        [Test]
        public async Task DeletePlantAsync_WithValidCatalogNumber_ShouldRemovePlantFromDb()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);

            // Act
            await plantsManager.DeleteAsync(newPlant.CatalogNumber);
            var dbPlant = this.dbContext.Plants.FirstOrDefault(p => p.CatalogNumber == newPlant.CatalogNumber);

            // Assert
            Assert.Null(dbPlant);
            
        }

        [Test]
        public async Task DeletePlantAsync_TryToDeleteWithNullOrWhiteSpaceCatalogNumber_ShouldThrowException()
        {
            // Arrange

            // Act
            var exception = Assert.ThrowsAsync<ArgumentException>(() => plantsManager.DeleteAsync(null));

            // Assert
            Assert.NotNull(exception);
            Assert.That(exception.Message, Is.EqualTo("Catalog number cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenPlantsExist_ShouldReturnAllPlants()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);

            // Act
            var allPlants = await plantsManager.GetAllAsync();

            // Assert
            Assert.NotNull(allPlants);
            Assert.That(allPlants.Count(), Is.EqualTo(1));
            
        }

        [Test]
        public async Task GetAllAsync_WhenNoPlantsExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => plantsManager.GetAllAsync());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No plant found."));
        }

        [Test]
        public async Task SearchByFoodTypeAsync_WithExistingFoodType_ShouldReturnMatchingPlants()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);

            // Act
            var dbContext = await plantsManager.SearchByFoodTypeAsync(newPlant.FoodType);
            var result = dbContext.Single();

            // Assert
            Assert.That(result.CatalogNumber, Is.EqualTo(newPlant.CatalogNumber));
            Assert.That(result.Name, Is.EqualTo(newPlant.Name));
            Assert.That(result.PlantType, Is.EqualTo(newPlant.PlantType));
            Assert.That(result.FoodType, Is.EqualTo(newPlant.FoodType));
            Assert.That(result.Quantity, Is.EqualTo(newPlant.Quantity));
            Assert.That(result.IsEdible, Is.EqualTo(newPlant.IsEdible));
        }

        [Test]
        public async Task SearchByFoodTypeAsync_WithNonExistingFoodType_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);

            // Act
            var foodType = "Flies";
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => plantsManager.SearchByFoodTypeAsync(foodType));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No plant found with the given food type."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidCatalogNumber_ShouldReturnPlant()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);

            // Act
            var result = await plantsManager.GetSpecificAsync(newPlant.CatalogNumber);

            // Assert
            Assert.That(result.CatalogNumber, Is.EqualTo(newPlant.CatalogNumber));
            Assert.That(result.Name, Is.EqualTo(newPlant.Name));
            Assert.That(result.PlantType, Is.EqualTo(newPlant.PlantType));
            Assert.That(result.FoodType, Is.EqualTo(newPlant.FoodType));
            Assert.That(result.Quantity, Is.EqualTo(newPlant.Quantity));
            Assert.That(result.IsEdible, Is.EqualTo(newPlant.IsEdible));

        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidCatalogNumber_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);

            // Act
            var invalidCatalongNumber = "ABCD123";
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => plantsManager.GetSpecificAsync(invalidCatalongNumber));

            // Assert
            Assert.That(exception.Message, Is.EqualTo($"No plant found with catalog number: {invalidCatalongNumber}"));
        }

        [Test]
        public async Task UpdateAsync_WithValidPlant_ShouldUpdatePlant()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);
            newPlant.Name = "Blue Rose";
            await plantsManager.UpdateAsync(newPlant);
            var result = await plantsManager.GetSpecificAsync(newPlant.CatalogNumber);

            // Assert
            Assert.That(result.CatalogNumber, Is.EqualTo(newPlant.CatalogNumber));
            Assert.That(result.Name, Is.EqualTo(newPlant.Name));
            Assert.That(result.PlantType, Is.EqualTo(newPlant.PlantType));
            Assert.That(result.FoodType, Is.EqualTo(newPlant.FoodType));
            Assert.That(result.Quantity, Is.EqualTo(newPlant.Quantity));
            Assert.That(result.IsEdible, Is.EqualTo(newPlant.IsEdible));
        }

        [Test]
        public async Task UpdateAsync_WithInvalidPlant_ShouldThrowValidationException()
        {
            // Arrange
            var newPlant = new Plant
            {
                CatalogNumber = "ABCD1234EFGH",
                Name = "Pink Rose",
                PlantType = "Rose",
                FoodType = "sun",
                Quantity = 5,
                IsEdible = false

            };

            // Act
            await plantsManager.AddAsync(newPlant);
            newPlant.Name = new string('a', 500);

            // Act

            // Assert
            Assert.ThrowsAsync<ValidationException>(() => plantsManager.UpdateAsync(newPlant));
        }
    }
}
