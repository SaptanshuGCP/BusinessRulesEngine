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

    public class GeneratePackingSlip : IRule
    {
        public bool ProcessRule()
        {
            Console.WriteLine("Packing slip generated.");
            return true;
        }
    }

    public class CommissionPayment : IRule
    {
        public bool ProcessRule()
        {
            Console.WriteLine("Commission payment generated.");
            return true;
        }
    }

    public class OrderPayment
    {
        List<IRule> _ruleList;
        public OrderPayment(List<IRule> rules)
        {
            rules = _ruleList;
        }
        public bool ProcessPaymentRules()
        {
            bool ruleProcessed = false;
            foreach (IRule rule in _ruleList)
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

    public class PhysicalOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public bool ProcessOrder()
        {
            _rules.Add(new GeneratePackingSlip());
            _rules.Add(new CommissionPayment());
            OrderPayment order = new OrderPayment(_rules);
            return order.ProcessPaymentRules();
        }
    }

    public class BookOrder : IOrder
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
