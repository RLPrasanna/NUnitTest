using NUnitTest.Interfaces;
using NUnitTest.Models;

namespace NUnitTest.Handlers
{
    public class JuiceHandler: IJuiceHandler
    {
        protected Juice juice;

        public JuiceHandler()
        {
            juice = new Juice();
        }

        public void CreateNewJuice(Order order)
        {
            if (order.NoOfPeople == 0)
            {
                throw new ArgumentException("No of people cannot be zero");
            }
            if (order.NoOfPeopleNotInterested > order.NoOfPeople)
            {
                throw new ArgumentException("No of people not interested cannot be greater than no of people");
            }
            juice.NoOfGlasses = order.NoOfPeople - order.NoOfPeopleNotInterested;
            juice.NoOfFruits = juice.NoOfGlasses * 2;
            juice.Flavor = "Orange";
            juice.Color = "Orange";
        }

        public Juice GetJuice()
        {
            return juice;
        }
    }
}
