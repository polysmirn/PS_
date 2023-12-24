using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.ObjectModel;


namespace TestProject2
{

    public class Test1
    {

        Mock<IDbRepos> context;
        HallService service;

        [SetUp]
        public void Setup()
        {
            context = MockDBRepos.GetMock();
            service = new HallService(context.Object);
        }


        [Test]
        public void CreateHall_Success()//добавление
        {
            var halls = new ObservableCollection<Hall>()
            {
                new Hall
                {
                    Id=4,
                    Name="Hall4",
                    Description="Bad",
                    Price_for_hour=1100
                    
                    
                }
            };
            var result = service.AddHall(halls[0]);
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.That(result.Id, Is.EqualTo(halls[0].Id));
            
        }

   
        [Test]
        public void UpdateHall_WithValidHall_ShouldNotThrowException()
        {
            
            var mockDbRepos = MockDBRepos.GetMock();
            var hallService = new HallService(mockDbRepos.Object);
            var existingHall = new Hall
            {
                Id = 1,
                Name = "Updated Hall",
                Description = "Updated Description",
                Price_for_hour = 2000
            };


            NUnit.Framework.Assert.DoesNotThrow(() => hallService.UpdateHall(existingHall));
        }
        [Test]
        public void GetHall_ShouldReturnNull() 
        {
            
            var mockDbRepos = MockDBRepos.GetMock();
            var hallService = new HallService(mockDbRepos.Object);
            int invalidId = 2;
            
            var result = hallService.GetHall(invalidId);
            
            NUnit.Framework.Assert.IsNull(result);
        }
        [Test]
        public void DeleteHall_ShouldDeleteAndSave()
        {
            
            var mockDbRepos = MockDBRepos.GetMock();
            var hallService = new HallService(mockDbRepos.Object);
            int existingId = 1;

            hallService.DeleteHall(existingId);

            mockDbRepos.Verify(m => m.Halls.Delete(existingId), Times.Once);
            mockDbRepos.Verify(m => m.Save(), Times.Once);
        }
        [Test]
        public void GetHalls_ShouldReturnNonEmptyList()
        {
            
            var mockDbRepos = MockDBRepos.GetMock();
            var hallService = new HallService(mockDbRepos.Object);

            
            var result = hallService.GetHalls();


            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.IsInstanceOf<List<Hall>>(result);
            NUnit.Framework.Assert.Greater(result.Count, 0);
        }

    }
}


    