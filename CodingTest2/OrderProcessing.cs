using System;
using System.Collections.Generic;

namespace CodingTest2
{

    /// <summary>
    /// Generic class to process a specific order.
    /// </summary>
    public class OrderProcessing
    {
        /// <summary>
        /// Instance of the Order
        /// </summary>
        IOrder _order;

        public OrderProcessing(IOrder order)
        {
            _order = order;
        }

        /// <summary>
        /// Processes the specific order passed in the constructor and stored in _order
        /// </summary>
        /// <returns>List of rules processed as part of the order</returns>
        public List<String> ProcessOrder()
        {
            _order.ProcessOrder();
            return _order.RulesProcessed;
        }
    }
    
    /// <summary>
    /// List of rules
    /// </summary>
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
        string RuleName { get; set; }
        void ProcessRule();
    }

    /// <summary>
    /// The rule for generating packing slip
    /// </summary>
    public class GeneratePackingSlipRule : IRule
    {
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            Console.WriteLine("Packing slip generated.");
            //After the rule is processed, the rule name is assigned signifying that the rule execution successful.
            RuleName = Rules.GEN_PKG_SLIP.ToString();
        }
    }

    /// <summary>
    /// The rule for generating duplicate packing slip for the royalty department.
    /// </summary>
    public class GenerateDupPkgSlipRule : IRule
    {
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            Console.WriteLine("Duplicate Packing slip generated.");
            //After the rule is processed, the rule name is assigned signifying that the rule execution successful.
            RuleName = Rules.GEN_DUP_PKG_SLIP.ToString();
        }
    }

    /// <summary>
    /// The rule for generating commission payment.
    /// </summary>
    public class CommissionPaymentRule : IRule
    {
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            Console.WriteLine("Commission payment generated.");
            //After the rule is processed, the rule name is assigned signifying that the rule execution successful.
            RuleName = Rules.COMM_PAYMENT.ToString();
        }
    }

    /// <summary>
    /// The rule for activating membership.
    /// </summary>
    public class ActivateMembershipRule : IRule
    {
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            Console.WriteLine("Membership activated.");
            //After the rule is processed, the rule name is assigned signifying that the rule execution successful.
            RuleName = Rules.ACT_MEMBERSHIP.ToString();
        }
    }

    /// <summary>
    /// The rule for upgrading membership.
    /// </summary>
    public class UpgradeMembershipRule : IRule
    {
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            Console.WriteLine("Membership upgraded.");
            //After the rule is processed, the rule name is assigned signifying that the rule execution successful.
            RuleName = Rules.UPGRD_MEMBERSHIP.ToString();
        }
    }

    /// <summary>
    /// The rule for sending email to the owner.
    /// </summary>
    public class EmailOwnerRule : IRule
    {
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            Console.WriteLine("Email sent.");
            //After the rule is processed, the rule name is assigned signifying that the rule execution successful.
            RuleName = Rules.EMAIL_OWNER.ToString();
        }
    }

    /// <summary>
    /// The rule for adding First Aid Video
    /// </summary>
    public class AddVideoRule : IRule
    {
        public string RuleName { get; set; }
        public void ProcessRule()
        {
            Console.WriteLine("First Aid Video added to the packing slip.");
            //After the rule is processed, the rule name is assigned signifying that the rule execution successful.
            RuleName = Rules.ADD_VIDEO.ToString();
        }
    }

    /// <summary>
    /// This class is for processing the rules. Based on the order being processes, the corresponding list of
    /// rules will be sent in the constructor
    /// </summary>
    public class OrderPayment
    {
        List<IRule> _ruleList;
        public OrderPayment(List<IRule> rules)
        {
            _ruleList = rules;
        }
        
        /// <summary>
        /// Processes the payment rules based on the list of rules sent in the paramter.
        /// </summary>
        /// <returns>List of rule names which are processed</returns>
        public List<String> ProcessPaymentRules()
        {
            List<string> rulesProcessed = new List<string>();
            foreach (IRule rule in _ruleList)
            {
                rule.ProcessRule();
                //Empty rule name would suggest that there was an issue processing the rule
                if (!String.IsNullOrEmpty(rule.RuleName))
                {
                    rulesProcessed.Add(rule.RuleName);
                }
            }
            return rulesProcessed;
        }
    }

    /// <summary>
    /// Class to process physical order.
    /// </summary>
    public class PhysicalProductOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            //Add the relavant rules to the list to be passed to processing.
            _rules.Add(new GeneratePackingSlipRule());
            _rules.Add(new CommissionPaymentRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }

    /// <summary>
    /// Class to process book order
    /// </summary>
    public class BookOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            //Add the relavant rules to the list to be passed to processing.
            _rules.Add(new GenerateDupPkgSlipRule());
            _rules.Add(new CommissionPaymentRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }

    /// <summary>
    /// Class to process membership
    /// </summary>
    public class MembershipOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            //Add the relavant rules to the list to be passed to processing.
            _rules.Add(new ActivateMembershipRule());
            _rules.Add(new EmailOwnerRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }
    
    /// <summary>
    /// Class to upgrade membership
    /// </summary>
    public class UpgradeMembershipOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            //Add the relavant rules to the list to be passed to processing.
            _rules.Add(new UpgradeMembershipRule());
            _rules.Add(new EmailOwnerRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }

    /// <summary>
    /// Class to process Video order.
    /// </summary>
    public class ProcessVideoOrder : IOrder
    {
        List<IRule> _rules = new List<IRule>();
        public List<String> RulesProcessed { get; set; }
        public void ProcessOrder()
        {
            //Add the relavant rules to the list to be passed to processing.
            _rules.Add(new AddVideoRule());
            OrderPayment order = new OrderPayment(_rules);
            RulesProcessed = order.ProcessPaymentRules();
        }
    }
}
