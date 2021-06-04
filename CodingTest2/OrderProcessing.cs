using System;
using System.Collections.Generic;

namespace CodingTest2
{

    public interface IOrder
    {
        bool RulesProcessed { get; set; }
        void ProcessOrder();
    }

    public interface IRule
    {
        bool IsRuleProcessed { get; set; }
        void ProcessRule();
    }

    public class GeneratePackingSlip : IRule
    {
        public bool IsRuleProcessed { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Packing slip generated.");
                IsRuleProcessed = true;
            }
            catch
            {
                IsRuleProcessed = false;
            }
        }
    }

    public class GenerateDuplicatePackingSlip : IRule
    {

        public bool IsRuleProcessed { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Duplicate Packing slip generated.");
                IsRuleProcessed = true;
            }
            catch
            {
                IsRuleProcessed = false;
            }
        }
    }

    public class CommissionPayment : IRule
    {
        public bool IsRuleProcessed { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Commission payment generated.");
                IsRuleProcessed = true;
            }
            catch
            {
                IsRuleProcessed = false;
            }
        }
    }

    public class OrderPayment
    {
        List<IRule> _ruleList;
        public OrderPayment(List<IRule> rules)
        {
            _ruleList = rules;
        }
        public bool ProcessPaymentRules()
        {
            foreach (IRule rule in _ruleList)
            {
                rule.ProcessRule();
                if (!rule.IsRuleProcessed)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class PhysicalProductOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public bool RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            _rules.Add(new GeneratePackingSlip());
            _rules.Add(new CommissionPayment());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }

    public class BookOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public bool RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            _rules.Add(new GenerateDuplicatePackingSlip());
            _rules.Add(new CommissionPayment());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }
}
