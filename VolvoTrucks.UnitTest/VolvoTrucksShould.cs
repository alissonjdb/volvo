using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoTrucks.Domain.Contract;
using VolvoTrucks.Repository.Model;

namespace VolvoTrucks.UnitTest
{
    [TestClass]
    public class VolvoTrucksShould
    {

        private Mock<ITruckBusiness> _truckMockBusiness;

        [TestInitialize]
        public  void SetUp()
        {
            _truckMockBusiness = new Mock<ITruckBusiness>();
        }

        [TestMethod]
        public void TestGetById()
        {
            //Arrange
            var expectedId = 1;
            var mockedDataTruck = new Truck() { Id= 1, ManufactureYear = 2019, ModelYear = 2019, TruckModelId = 1};

            //Act
            _truckMockBusiness.Setup(m=> m.GetById(expectedId)).Returns(Task.FromResult(mockedDataTruck));
            
            //Assert
            Assert.IsTrue(mockedDataTruck.Id == expectedId);
        }

        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            var expectedTruckList = new List<Truck>();
            expectedTruckList.Add(new Truck() { Id = 1, ManufactureYear = 2019, ModelYear = 2019, TruckModelId = 1 });
            expectedTruckList.Add(new Truck() { Id = 2, ManufactureYear = 2019, ModelYear = 2020, TruckModelId = 2 });

            //Act
            var truck = _truckMockBusiness.Setup(m => m.Getall()).Returns(Task.FromResult(expectedTruckList));

            //Assert
            Assert.IsTrue(expectedTruckList.Count > 0);
        }

        [TestMethod]
        public void TestGetAllModels()
        {
            //Arrange
            var expectedTruckModels = new List<TruckModel>(); ;
            expectedTruckModels.Add(new TruckModel() { Id = 1, Name = "FH"});
            expectedTruckModels.Add(new TruckModel() { Id = 2, Name = "FM"});

            //Act
            var truck = _truckMockBusiness.Setup(m => m.GetAllModels()).Returns(expectedTruckModels);

            //Assert
            Assert.IsTrue(expectedTruckModels.Count > 0);
        }

        [TestMethod]
        public void TestSave()
        {
            //Arrange
            var mockedDataTruck = new Truck() { Id = 0, ManufactureYear = 2019, ModelYear = 2019, TruckModelId = 1 };

            //Act
            var truck = _truckMockBusiness.Setup(m => m.Save(mockedDataTruck));

            //Assert
            //Assert = no exception
        }

        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            var mockedDataTruck = new Truck() { Id = 1, ManufactureYear = 2019, ModelYear = 2019, TruckModelId = 1 };

            //Act
            var truck = _truckMockBusiness.Setup(m => m.Update(mockedDataTruck));

            //Assert
            //Assert = no exception
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            var mockedDataTruck = new Truck() { Id = 1, ManufactureYear = 2019, ModelYear = 2019, TruckModelId = 1 };

            //Act
            var truck = _truckMockBusiness.Setup(m => m.Delete(mockedDataTruck));

            //Assert
            //Assert = no exception
        }
    }
}
