using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3_DependencyInjection.Services
{
    public class CounterService
    {
        protected internal ICounter Counter;
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
