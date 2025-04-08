using System.Threading.Channels;
using System.Xml.Linq;

namespace Homework_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CreditCard> creditCards = new List<CreditCard>
            {
                new CreditCard("123456789", 1568.32),
                new CreditCard("987654321", 1954.88),
                new CreditCard("921436587", 1395.46)
            };

            creditCards[0].CreditCardStatus();
            creditCards[1].CreditCardStatus();
            creditCards[2].CreditCardStatus();

            int selectedCard = 0;

            while (selectedCard != 1 && selectedCard != 2 && selectedCard != 3)
            {
                Console.WriteLine("Выберите номер счёта:\n" +
                                  $"1. {creditCards[0].bankAccount};\n" +
                                  $"2. {creditCards[1].bankAccount};\n" +
                                  $"3. {creditCards[2].bankAccount}.\n");
                selectedCard = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            string selectedOperation = "";

            while (selectedOperation != "1" && selectedOperation != "2" && selectedOperation != "3" && selectedOperation != "4")
            {
                Console.WriteLine("Выберите операцию:\n" +
                                  "1. Пополнение счёта;\n" +
                                  "2. Снятие средств;\n" +
                                  "3. Информация по карточке;\n" +
                                  "4. Перевод с карты на карту.\n");
                selectedOperation = Console.ReadLine();
                Console.WriteLine();
            }

            if (selectedOperation == "1")
            {
                creditCards[selectedCard - 1].DepositMoney();
                creditCards[selectedCard - 1].CreditCardStatus();
            }
            else if (selectedOperation == "2")
            {
                creditCards[selectedCard - 1].CashOutMoney();
                creditCards[selectedCard - 1].CreditCardStatus();
            }
            else if (selectedOperation == "3")
            {
                creditCards[selectedCard - 1].CreditCardStatus();

            }
            else if (selectedOperation == "4")
            {
                int selectedTargetCard = 0;

                while (selectedTargetCard != 1 && selectedTargetCard != 2 && selectedTargetCard != 3)
                {
                    Console.WriteLine("Выберите номер счёта:\n" +
                                      $"1. {creditCards[0].bankAccount}{(creditCards[0] == creditCards[selectedCard - 1] ? " - Активная карта" : "")};\n" +
                                      $"2. {creditCards[1].bankAccount}{(creditCards[1] == creditCards[selectedCard - 1] ? " - Активная карта" : "")};\n" +
                                      $"3. {creditCards[2].bankAccount}{(creditCards[2] == creditCards[selectedCard - 1] ? " - Активная карта" : "")}.\n");
                    selectedTargetCard = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (creditCards.ElementAtOrDefault(selectedTargetCard - 1) == null)
                    {
                        Console.WriteLine("Такого счёта нет");

                        continue;
                    }
                    else if (creditCards[selectedTargetCard - 1] == creditCards[selectedCard - 1])
                    {
                        Console.WriteLine("Вы не можете выбрать активную карту, выберите другую\n");
                        selectedTargetCard = 0;
                        Console.WriteLine();
                    }

                }

                creditCards[selectedCard - 1].TransferMoney(creditCards[selectedTargetCard - 1]);
                creditCards[selectedCard - 1].CreditCardStatus();
                creditCards[selectedTargetCard - 1].CreditCardStatus();

            }

        }
    }
}
