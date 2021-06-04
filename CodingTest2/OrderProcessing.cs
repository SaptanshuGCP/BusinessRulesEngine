using System;
using System.Collections.Generic;

namespace CodingTest2
{

    public class OrderProcessing
    {
        IOrder _order;

        public OrderProcessing(IOrder order)
        {
            _order = order;
        }

        public List<String> ProcessOrder()
        {
            _order.ProcessOrder();
            return _order.RulesProcessed;
        }
    }
    public enum Rules
    {
        GEN_PKG_SLIP,
        GEN_DUP_PKG_SLIP,
        COMM_PAYMENT,
        ACT_MEMBERSHIP,
        UPGRD_MEMBERSHIP,
        EMAIL_OWNER,
        ADD_VIDEO
    }

    public interface IOrder
    {
        List<String> RulesProcessed { get; set; }
        void ProcessOrder();
    }

    public interface IRule
    {
        bool IsRuleProcessed { get; set; }
        string RuleName { get; set; }
        void ProcessRule();
    }

    public class GeneratePackingSlip : IRule
    {
        public bool IsRuleProcessed { get; set; }
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Packing slip generated.");
                RuleName = Rules.GEN_PKG_SLIP.ToString();
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
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Duplicate Packing slip generated.");
                RuleName = Rules.GEN_DUP_PKG_SLIP.ToString();
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
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Commission payment generated.");
                RuleName = Rules.COMM_PAYMENT.ToString();
                IsRuleProcessed = true;
            }
            catch
            {
                IsRuleProcessed = false;
            }
        }
    }

    public class ActivateMembership : IRule
    {

        public bool IsRuleProcessed { get; set; }
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Membership activated.");
                RuleName = Rules.ACT_MEMBERSHIP.ToString();
                IsRuleProcessed = true;
            }
            catch
            {
                IsRuleProcessed = false;
            }
        }
    }

    public class EmailOwner : IRule
    {
        public bool IsRuleProcessed { get; set; }
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Email sent.");
                RuleName = Rules.EMAIL_OWNER.ToString();
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
        public List<String> ProcessPaymentRules()
        {
            List<string> rulesProcessed = new List<string>();
            foreach (IRule rule in _ruleList)
            {
                rule.ProcessRule();
                if (rule.IsRuleProcessed)
                {
                    rulesProcessed.Add(rule.RuleName);
                }
            }
            return rulesProcessed;
        }
    }

    public class PhysicalProductOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
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
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            _rules.Add(new GenerateDuplicatePackingSlip());
            _rules.Add(new CommissionPayment());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }

    public class MembershipOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            _rules.Add(new ActivateMembership());
            _rules.Add(new EmailOwner());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }
}
