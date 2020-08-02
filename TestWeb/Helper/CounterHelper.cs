using System;
using System.Collections.Generic;
using TestWeb.Models;

namespace TestWeb.Helper
{
    public class CounterHelper
    {
        static object obj = new object();

        public static bool Countresult(Client client, List<Transaction> transactionList, Transaction transaction)
        {
            if (obj == null)
            {
                obj = new object();
            }

            lock (obj)
            {
                if (transaction.type == 1)
                {
                    client.Amount += transaction.Amount;
                    transaction.Date = DateTime.Now;
                    transactionList.Add(transaction);

                    return true;
                }

                if (transaction.type == 0 && client.Amount - transaction.Amount >= 0)
                {
                    client.Amount -= transaction.Amount;
                    transaction.Date = DateTime.Now;
                    transactionList.Add(transaction);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}