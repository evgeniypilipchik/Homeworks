using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Homework_6
{
    class CreditCard
    {
        public string bankAccount;
        public double balance;

        public CreditCard(string bankAccount, double balance)
        {
            this.bankAccount = bankAccount;
            this.balance = balance;
        }

        public CreditCard() { }

        public void DepositMoney()
        {
            double deposit = 0;
            string sumOfDeposit;
            bool result = false;

            while (result == false)
            {
                Console.WriteLine("Введите числовое значение суммы пополнения, руб.\n");
                sumOfDeposit = Console.ReadLine();
                Console.WriteLine();
                result = double.TryParse(sumOfDeposit, out deposit);
            }

            balance += Math.Abs(deposit);
        }
        public void CashOutMoney()
        {
            double cash = 0;
            string sumOfCash;
            bool result = false;

            while (result == false)
            {
                Console.WriteLine("Введите числовое значение суммы списания, руб.\n");
                sumOfCash = Console.ReadLine();
                Console.WriteLine();
                result = double.TryParse(sumOfCash, out cash);

                if (balance < cash)
                {
                    Console.WriteLine("Недостаточно средств\n");
                    result = false;
                }
            }

            balance -= Math.Abs(cash);
        }

        public void CreditCardStatus()
        {
            Console.WriteLine($"Номер счёта: {bankAccount}\n" +
                              $"Остаток средств: {balance:F2} руб.\n");
        }
        public void TransferMoney(CreditCard targetCard)
        {
            double amount = 0;
            string sumOfTransfer;
            bool result = false;

            while (result == false)
            {
                Console.WriteLine("Введите числовое значение суммы перевода, руб.\n");
                sumOfTransfer = Console.ReadLine();
                Console.WriteLine();
                result = double.TryParse(sumOfTransfer, out amount);

                if (balance < amount)
                {
                    Console.WriteLine("Недостаточно средств\n");
                    result = false;
                }

            }

            balance -= Math.Abs(amount);
            targetCard.balance += Math.Abs(amount);

        }
    }
}
