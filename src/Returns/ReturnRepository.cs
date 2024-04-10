using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Returns
{
    public class ReturnRepository
    {
        private List<IReturn> returns;
        public ReturnRepository()
        {
            returns = new List<IReturn>();
        }

        public void Add(IReturn newReturn)
        {
            returns.Add(newReturn);
        }

        public void Remove(IReturn removedReturn)
        {
            returns = returns.Where(o => !string.Equals(removedReturn.ReturnNumber, o.ReturnNumber)).ToList();
        }

        public List<IReturn> Get()
        {
            return returns;
        }

        /*
            This overloaded Get function is used to get the list of returns 
            for a specific customer. I iterate over the returns using the FindAll 
            method to filter out any order not matching the specified customer name.
        */
        public List<IReturn> Get(String customerName) {
            return returns.FindAll(
                delegate(IReturn returnItem) {
                    return returnItem.OriginalOrder.Customer.GetName().Equals(customerName);
                }
            );
        }
    }
}
