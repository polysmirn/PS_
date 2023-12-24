using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public static class MockDBRepos
    {
        public static Mock<IDbRepos> GetMock()
        {
            var mock = new Mock<IDbRepos>();
           
            var HallMock = MockHallRepository.GetMock();
          

         
            mock.Setup(m => m.Halls).Returns(() => HallMock.Object);
          
            // не тестируем запись в бд
            mock.Setup(m => m.Save()).Returns(() => { return 1; });
            return mock;
        }
    }
}
