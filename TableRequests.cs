using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantProject3
{
    public class TableRequests
    {
        const int n = 8;
        const int m = 100000;
        IItemInterface[,] menuItems = new IItemInterface[n, m];
        int mindex = 0;
        public void Add(int customer, IItemInterface i)
        {
            if (mindex == m-1)
                mindex = 0;

            menuItems[customer, mindex] = i;
            mindex++;
        }


        public IItemInterface[] this[IItemInterface i] {get => GetMenuItems(i);}
        public IItemInterface[] this[int i] {get => GetMenuItemsCustomer(i);}
       
        public IItemInterface[] GetMenuItems(IItemInterface item)
        {
            IItemInterface[] items = new IItemInterface[m*8];
            int idx = 0;
            for (int i = 0; i < n; i++) { 
                for(int j=0; j<m; j++)
                {
                    if (menuItems[i, j] != null)
                    {
                        if (menuItems[i, j].GetType() == item.GetType())
                        {
                            items[idx] = menuItems[i, j];
                            idx++;
                        }
                    }
                }
            }
            return items;
            
        }
        public IItemInterface[] GetMenuItemsCustomer(int index)
        {
            IItemInterface[] items = new IItemInterface[m*8];
            int idx = 0;
            for (int i = 0; i < n; i++) {
                if (i == index)
                {
                    for (int j=0; j<m; j++)
                    {                    
                        items[idx] = menuItems[i, j];
                        idx++;
                    }
                }
            }
            return items;            
        }

    }

    public interface IItemInterface
    {
        void Obtain();
        void Serve();
        Type GetType();
    }

}
