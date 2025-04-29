using NUnitTest.Models;

namespace NUnitTest.Interfaces
{
    public interface IJuiceHandler
    {
        void CreateNewJuice(Order order);
        Juice GetJuice();
    }
}
