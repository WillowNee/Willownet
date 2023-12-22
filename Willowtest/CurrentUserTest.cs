﻿using System.Transactions;
using Willownet.BL.Auth;
using Willownet.DAL.Models;
using Willowtest.Helpers;

namespace Willowtest
{
    public class CurrentUserTest : BaseTest
    {
        [Test]
        public async Task BaseCurrentUserTest()
        {
            using (TransactionScope scope = Helper.CreateTransactionScope())
            {
                await CreateAndAuthUser();

                bool isLoggedIn = await this.currentUser.IsLoggedIn();
                Assert.True(isLoggedIn);

                // reset session
                webCookie.Delete(AuthConstants.SessionCookieName);
                sessionBL.ResetSessionCache();

                isLoggedIn = await this.currentUser.IsLoggedIn();
                Assert.True(isLoggedIn);

                webCookie.Delete(AuthConstants.RememberMeCookieName);
                webCookie.Delete(AuthConstants.SessionCookieName);
                sessionBL.ResetSessionCache();

                isLoggedIn = await this.currentUser.IsLoggedIn();
                Assert.False(isLoggedIn);
            }
        }

        public async Task<int> CreateAndAuthUser()
        {
            string email = Guid.NewGuid().ToString() + "@test.com";

            // create user
            int userId = await authBL.CreateUser(
                new UserModel
                {
                    Email = email,
                    Password = "Qwerty4&qwerty"
                });

            return await authBL.Authenticate(email, "Qwerty4&qwerty", true);
        }
    }
}
