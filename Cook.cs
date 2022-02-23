using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantProject3
{
    public class Cook
    {
        public void Process(TableRequests requests)
        {
            var chickens = requests[new Chicken()];
            for (int i = 0; i < chickens.Length; i++)
            {
                if (chickens[i]!= null)
                {
                    var ch = (Chicken)chickens[i];
                    ch.CutUp();
                    ch.Cook();
                }
            }

            var eggs = requests[new Egg()];
            for (int i = 0; i < eggs.Length; i++)
            {
                if (eggs[i]!= null)
                {
                    var ch = (Egg)eggs[i];
                    ch.Crack();
                    ch.DiscardShells();
                    ch.Cook();
                }
            }

        }

       

    }
}
