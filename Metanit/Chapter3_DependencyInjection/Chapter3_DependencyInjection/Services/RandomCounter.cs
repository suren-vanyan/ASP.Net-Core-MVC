using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3_DependencyInjection.Services
{
    public class RandomCounter : ICounter
    {
        static Random random = new Random();
        private int _value;
        public RandomCounter()
        {
            _value = random.Next(0, 1000000);
        }
        public int Value => _value;
    }
}
