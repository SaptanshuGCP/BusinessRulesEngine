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

    public class GeneratePackingSlipRule : IRule
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

    public class GenerateDupPkgSlipRule : IRule
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

    public class CommissionPaymentRule : IRule
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

    public class ActivateMembershipRule : IRule
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

    public class UpgradeMembershipRule : IRule
    {
        public bool IsRuleProcessed { get; set; }
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("Membership upgraded.");
                RuleName = Rules.UPGRD_MEMBERSHIP.ToString();
                IsRuleProcessed = true;
            }
            catch
            {
                IsRuleProcessed = false;
            }
        }
    }

    public class EmailOwnerRule : IRule
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

    public class AddVideoRule : IRule
    {
        public bool IsRuleProcessed { get; set; }
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            try
            {
                Console.WriteLine("First Aid Video added to the packing slip.");
                RuleName = Rules.ADD_VIDEO.ToString();
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
            _rules.Add(new GeneratePackingSlipRule());
            _rules.Add(new CommissionPaymentRule());
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
            _rules.Add(new GenerateDupPkgSlipRule());
            _rules.Add(new CommissionPaymentRule());
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
            _rules.Add(new ActivateMembershipRule());
            _rules.Add(new EmailOwnerRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }
    public class UpgradeMembershipOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            _rules.Add(new UpgradeMembershipRule());
            _rules.Add(new EmailOwnerRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }

    public class ProcessVideoOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            _rules.Add(new AddVideoRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }
}
