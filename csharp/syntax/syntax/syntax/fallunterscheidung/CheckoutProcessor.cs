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
    if(ClassifyCustomerCredit(customer)) {
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

    public class Customer
    {
        public double Balance { get; set; }
    }
}