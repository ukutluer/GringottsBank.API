using GringottsBank.Core.Entities.Abstract;

namespace GringottsBank.Entities.AccountTransaction
{
    public class AccountTransaction : MongoDbEntity
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
