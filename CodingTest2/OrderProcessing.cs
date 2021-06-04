using System;
using System.Collections.Generic;

namespace CodingTest2
{

    public interface IOrder
    {
        bool ProcessOrder();
    }

    public interface IRule
    {
        bool ProcessRule();
    }

    public class PhysicalOrder : IOrder
    {
        public List<IRule> rules { get; set; }
        public bool ProcessOrder()
        {
            bool ruleProcessed = false;
            foreach (IRule rule in rules)
            {
                ruleProcessed = rule.ProcessRule();
                if (!ruleProcessed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
