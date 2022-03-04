using GringottsBank.Core.Entities.Abstract;

namespace GringottsBank.Entities.User
{
    public class User : MongoDbEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
