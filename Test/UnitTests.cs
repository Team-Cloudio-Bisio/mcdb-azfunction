using NUnit.Framework;
using minecraftsaas.DB;

namespace minecraftsaas.Test {

    [TestFixture]
    public class UnitTests {

        [Test, Order(1)]
        public async Task ARegisterTest() {
            DBUserContext context = new DBUserContext(Environment.GetEnvironmentVariable("DBConnectionString"));

            User user = new User {
                username = "test@email.it",
                userPassword = "test"
            };

            var result = await context.InsertUser(user);

            Assert.IsNotNull(result, "error");
            Assert.AreEqual(result, 1);
        }

        [Test, Order(2)]
        public async Task BLoginTest() {
            DBUserContext context = new DBUserContext(Environment.GetEnvironmentVariable("DBConnectionString"));

            User user = new User {
                username = "test@email.it",
                userPassword = "test"
            };

            var result = await context.LoginUser(user);

            Assert.IsNotNull(result, "error");
            Assert.True(result);
        }

        [Test, Order(2)]
        public async Task CRemoveUser() {
            DBUserContext context = new DBUserContext(Environment.GetEnvironmentVariable("DBConnectionString"));

            User user = new User {
                username = "test@email.it",
                userPassword = "test"
            };

            var result = await context.DeleteUser(user.username);

            Assert.IsNotNull(result, "error");
            Assert.AreEqual(result, 1);
        }
    }
}