using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantProject3
{
    public abstract class Drink : MenuItem
    {
        public override void Obtain()
        {
            base.Obtain();
        }
        public override void Serve()
        {
            base.Serve();
        }

    }
}
