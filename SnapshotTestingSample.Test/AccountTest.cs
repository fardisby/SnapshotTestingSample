using Newtonsoft.Json;
using Snapshooter.Xunit;
using SnapshotTestingSample.Entity;
using SnapshotTestingSample.Services;

namespace SnapshotTestingSample.Test
{
    public class AccountTest
    {
        [Fact]
        public void CreateAccountWithoutSnapshot_ShouldReturnValidAccountJson()
        {
            //Arange
            var serviceClient = new AccountService();
            var accountid = Guid.Parse("1292F21C-8501-4771-A070-C79C7C7EF451");
            var accountName = "Saving Account for me";
            var localAccount = false;
            var currency = "USD";
            var country = "AUS";
            var active = true;

            //Act
            var resultJson = serviceClient.CreateAccount(accountid, accountName, localAccount, active, country, currency);
            var deserializedaccount = JsonConvert.DeserializeObject<Account>(resultJson);

            //Asert
            Assert.NotNull(deserializedaccount);
            Assert.Equal(accountid, deserializedaccount.AccounID);
            Assert.Equal(accountName, deserializedaccount.AccountName);
            Assert.Equal(localAccount, deserializedaccount.LocalAccount);
            Assert.Equal(active, deserializedaccount.Active);
            Assert.Equal(country, deserializedaccount.Country);
            Assert.Equal(currency, deserializedaccount.Currency);
        }



        [Fact]
        public void CreateAccount_ShouldReturnValidAccountJson()
        {
            //Arange
            var serviceClient = new AccountService();
            var accountid = Guid.Parse("1292F21C-8501-4771-A070-C79C7C7EF451");
            var accountName = "Saving Account for me";
            var localAccount = false;
            var currency = "USD";
            var country = "AUS";
            var active = true;

            //Act

            var resultJson = serviceClient.CreateAccount(accountid, accountName, localAccount, active, country, currency);

            //Assert
            Snapshot.Match(resultJson, matchOptions => matchOptions.IgnoreField("RegistrationDate"));
        }

        [Fact]
        public Task CreateAccount_ShouldReturnValidAccountJson_By_Verify()
        {
            //Arrang
            var serviceClient = new AccountService();
            var accountid = Guid.Parse("1292F21C-8501-4771-A070-C79C7C7EF451");
            var accountName = "Saving Account for me";
            var localAccount = false;
            var currency = "USD";
            var country = "AUS";
            var active = true;

            //Act
            var resultJson = serviceClient.CreateAccount(accountid, accountName, localAccount, active, country, currency);

            //Verify
            return Verify(resultJson);
        }
    }
}
