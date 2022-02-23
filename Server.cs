using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantProject3
{

    public class Server
    {
        const int n = 8;
        TableRequests requests = new TableRequests();
        int idx = 0;
        Cook cook = new Cook();
        public int Receive(int quantityChiken, int quantityEgg, string drink)
        {
            if (idx < n)
            {                  
                for (int i = 0; i < quantityChiken; i++)
                {
                    var chicken = new Chicken();
                    chicken.Obtain();
                    requests.Add(idx, chicken);                    
                }
                for (int i = 0; i < quantityEgg; i++)
                {
                    var egg = new Egg(); 
                    requests.Add(idx, new Egg());
                }
                requests.Add(idx, GetMenuDrink(drink));
                idx++;
                return idx - 1;
            }
            throw new Exception("We can't receive more than " + n + " orders");

        }
        public void Send()
        {
            cook.Process(requests);
        }
        public (string[], string) ServeAll()
        {
            string[] result = new string[n + 1];
            int index = 0;
           
            if (idx>0)
            {
                for (int i = 0; i < idx; i++)
                {
                    string text = "Customer " + i + " is served ";
                    int chickenCount = 0;
                    int eggCount = 0;
                    string drink = " ";

                    var customerOrders = requests[i];

                    for (int j = 0; j < customerOrders.Length; j++)
                    {
                        if (customerOrders[j]!=null)
                        {
                            if (customerOrders[j] is Chicken)
                            {                               
                                chickenCount++;
                            }

                            else if (customerOrders[j] is Egg)
                            {
                                eggCount++;
                            }
                            else
                            {
                                drink = customerOrders[j].GetType().Name;
                            }
                            customerOrders[j].Serve();
                        }
                        

                    }
                    if (chickenCount > 0)
                    {
                        text += " Chicken " + chickenCount;
                    }
                    if (eggCount > 0)
                    {
                        text += ", Egg " + eggCount;
                    }
                    if (!string.IsNullOrEmpty(drink))
                    {
                        text += ", " + drink;
                    }
                    if (chickenCount > 0 || eggCount > 0 || (!string.IsNullOrEmpty(drink) && !string.IsNullOrWhiteSpace(drink)))
                    {
                        result[index] = text;
                        index++;
                    }
                }               

                requests = new TableRequests();
                idx = 0;
                result[index] = "Please enjoy your meal!";
            }
            else
            {
                result[index] = "Please send all orders to cooker!";
            }
            
            return (result, Egg.quality.ToString());
        }
      

        private MenuItem GetMenuDrink(string str)
        {
            switch (str)
            {
                case "RC Cola":
                    return new RSCola();
                case "Lemonad":
                    return new Lemonad();
                case "Tea":
                    return new Tea();
                case "NotDrink":
                    return new NotDrink();
            }
            return new NotDrink();
        }

    }
}