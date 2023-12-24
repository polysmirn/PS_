using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public static class MockHallRepository
    {
        public static List<Hall> halls = new List<Hall>()
        {
            new Hall()
            { Id=1,
               Name="Hall1",
               Description="Nice",
               Price_for_hour=1200,
            }
        };
        public static Mock<IRepository<Hall>> GetMock()
        {
            var mock=new Mock<IRepository<Hall>>();
            mock.Setup(m=>m.GetList()).Returns(()=>halls);
            mock.Setup(m => m.GetItem(It.IsAny<int>())).Returns((int id) => halls.FirstOrDefault(o => o.Id == id));
            mock.Setup(m => m.Update(It.IsAny<Hall>())).Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>())).Callback(() => { return; });
            mock.Setup(m => m.Create(It.IsAny<Hall>())).Callback((Hall hall) => { halls.Add(hall); });

            return mock;

        }
    }
}
