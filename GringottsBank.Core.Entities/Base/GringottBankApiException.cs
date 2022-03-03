namespace GringottsBank.Core.Entities.Base
{

    [System.Serializable]
    public class GringottsBankApiException : System.Exception
    {
        public GringottsBankApiException() { }
        public GringottsBankApiException(string message) : base(message) { }
        public GringottsBankApiException(string message, System.Exception inner) : base(message, inner) { }
        protected GringottsBankApiException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
