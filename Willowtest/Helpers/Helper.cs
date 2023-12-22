using System.Transactions;

namespace Willowtest.Helpers
{
    // Common configuration
    public static class Helper
    {
        public static TransactionScope CreateTransactionScope (int seconds = 1)
        {
            return new TransactionScope(
                TransactionScopeOption.Required,
                new TimeSpan(0, 0, seconds),
                TransactionScopeAsyncFlowOption.Enabled
                );
        }
    }
}
