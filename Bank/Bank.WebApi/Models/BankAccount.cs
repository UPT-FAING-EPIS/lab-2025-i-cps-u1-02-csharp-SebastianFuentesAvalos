namespace Bank.WebApi.Models
{
    /// <summary>
    /// Representa una cuenta bancaria.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName = string.Empty;
        private double m_balance;

        /// <summary>
        /// Constructor privado para serialización.
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Inicializa una nueva instancia de BankAccount.
        /// </summary>
        /// <param name="customerName">Nombre del cliente.</param>
        /// <param name="balance">Saldo inicial.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Saldo actual de la cuenta.
        /// </summary>
        public double Balance { get { return m_balance; }  }

        /// <summary>
        /// Debita una cantidad de la cuenta.
        /// </summary>
        /// <param name="amount">Cantidad a debitar.</param>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount");
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance -= amount;
        }

        /// <summary>
        /// Acredita una cantidad a la cuenta.
        /// </summary>
        /// <param name="amount">Cantidad a acreditar.</param>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}