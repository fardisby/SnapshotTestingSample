using Newtonsoft.Json;
using SnapshotTestingSample.Entity;

namespace SnapshotTestingSample.Services
{
    public class AccountService
    {
        public string CreateAccount(Guid accountID,
            string accountName,
            bool localAccount,
            bool active,
            string country,
            string currency)
        {
            var newAccount = new Account
            {
                AccounID = accountID,
                AccountName = accountName,
                LocalAccount = localAccount,
                Active = active,
                Country = country,
                Currency = currency
            };

            return JsonConvert.SerializeObject(newAccount);

        }
    }
}
