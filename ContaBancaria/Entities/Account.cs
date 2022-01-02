using System;
using System.Globalization;
using ContaBancaria.Entities.Exceptions;
namespace ContaBancaria.Entities
{
    internal class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new DomainException("Erro no saque! Saldo insuficiente.");
            }
            if (amount > WithdrawLimit)
            {
                throw new DomainException("Erro no saque! Limite de saque excedido.");
            }

            Balance -= amount;
        }

        public override string ToString()
        {
            return $"Saldo atual: {Balance.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
