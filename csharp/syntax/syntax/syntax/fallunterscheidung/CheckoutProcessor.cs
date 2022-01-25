using System;

namespace syntax.fallunterscheidung
{
    public class CheckoutProcessor1
    {
        public void Checkout(Customer customer) {
            ClassifyCustomerCredit(customer,
                CheckoutWithCreditCard,
                CheckoutWithCash);
        }
 
        public void ClassifyCustomerCredit(
                Customer customer, 
                Action<Customer> hasCredit, 
                Action<Customer> hasNoCredit) {
            if(customer.Balance >= 1000.0) {
                hasCredit(customer);
            } else {
                hasNoCredit(customer);
            }
        }
 
        public void CheckoutWithCreditCard(Customer customer) {
            // ...
        }
 
        public void CheckoutWithCash(Customer customer) {
            // ...
        }
    }

    public class CheckoutProcessor
    {
        public void Checkout(Customer customer) {
            if (ClassifyCustomerCredit(customer)) {
                CheckoutWithCreditCard();
            }
            else {
                CheckoutWithCash();
            }
        }

        public bool ClassifyCustomerCredit(Customer customer) {
            return customer.Balance >= 1000.0;
        }

        public void CheckoutWithCreditCard() {
            // ...
        }

        public void CheckoutWithCash() {
            // ...
        }
    }
    
    public class CheckoutProcessor3
    {
        public void WhenCustomerHasCredit(Customer customer, Action onYes, Action onNo) {
            if (customer.NumberOfTransactions > 5) {
                onYes();
            }
            else {
                onNo();
            }
        }

        public void DoCheckout1(Customer customer) {
            WhenCustomerHasCredit(customer,
                onYes: () => {
                    // ...
                },
                onNo: () => {
                    // ...
                });
        }

        public void DoCheckout(Customer customer) {
            var credibility = GetCustomerCredibility(customer);
            switch (credibility) {
                case Credibility.HasNoCredit:
                    // ...
                    break;
                case Credibility.HasCredit:
                    // ...
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Credibility GetCustomerCredibility(Customer customer) {
            return customer.NumberOfTransactions > 5
                ? Credibility.HasCredit
                : Credibility.HasNoCredit;
        }
    }

    public class Customer
    {
        public double Balance { get; set; }

        public int NumberOfTransactions { get; set; }
    }

    public enum Credibility
    {
        HasNoCredit,
        HasCredit
    }
}