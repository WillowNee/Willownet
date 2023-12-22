using System.Transactions;
using Willowtest.Helpers;

namespace Willowtest
{
    public class TokenTest : BaseTest
    {
        [Test]
        public async Task BaseTokenTest()
        {
            using (TransactionScope scope = Helper.CreateTransactionScope())
            {
                var tokenId = await this.userTokenDAL.Create(10);
                var userid = await this.userTokenDAL.Get(tokenId);
                Assert.That(userid, Is.EqualTo(10));
            }
        }
    }
}
