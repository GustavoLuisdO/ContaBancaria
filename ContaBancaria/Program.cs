using System;
using System.Globalization;
using ContaBancaria.Entities;
using ContaBancaria.Entities.Exceptions;

namespace ContaBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Entre com os dados da conta");

                Console.Write("Número: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Titular: ");
                string holder = Console.ReadLine();
                Console.Write("Saldo: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Limite de Saque: ");
                double whitdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(number, holder, balance, whitdrawLimit);

                Console.Write("\nInsira o valor para sacar: ");
                double whitdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                account.Withdraw(whitdraw);

                Console.WriteLine($"\n{account}");
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado! {ex.Message}");
            }
        }
    }
}
