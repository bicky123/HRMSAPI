namespace HRMS.Business.Queries.Results
{
    public class CommanResult<T> where T : class
    {
        public T Result { get; set; }
        public List<string> Messages { get; set; }
        public CommanResult(T result, List<string> messages)
        {
            Result = result;
            Messages = messages;
        }
    }
}
