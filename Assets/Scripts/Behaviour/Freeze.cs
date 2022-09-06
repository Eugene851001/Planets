using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Behaviour
{
    public class Freeze : IThinker
    {
        public Enemy Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public void Think()
        {
            Context.DAzimut = 0;
            Context.DZenit = 0;
        }
    }
}
