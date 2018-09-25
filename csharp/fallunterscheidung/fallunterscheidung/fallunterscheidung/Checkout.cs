using System;

namespace fallunterscheidung
{
    public class Checkout
    {
        public enum Credibility
        {
            HasNoCredit,
            HasCredit
        };


        public Credibility GetCustomerCredibility(Customer customer) {
            return customer.NumberOfTransactions > 5 
                ? Credibility.HasCredit 
                : Credibility.HasNoCredit;
        }

        public void WhenCustomerHasCredit(Customer customer, Action onYes, Action onNo) {
            if (customer.NumberOfTransactions > 5) {
                onYes();
            }
            else {
                onNo();
            }
        }
        
        public void DoCheckout1() {
            var customer = new Customer();
            WhenCustomerHasCredit(customer,
                onYes: () => {
                    // ...
                },
                onNo: () => {
                    // ...
                });
        }

        public void DoCheckout() {
            var customer = new Customer();
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
    }

    public class Customer
    {
        public int NumberOfTransactions { get; set; }
    }
}