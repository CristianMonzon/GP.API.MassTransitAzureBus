namespace GP.LIB.Messages.Implementation
{
    public class Result<T>
    {
        public bool IsOK { get; set; }
        public bool IsError { get { return !IsOK; } }
        public T Value { get; set; }
        public string? ErrorMessage { get; set; }
        public Exception? Exception { get; set; }

        public Result()
        {
            IsOK = false;
        }

        public Result(bool isOk, T value, string errorMessage) {
            IsOK = isOk;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public void SetOK(T value)
        {
            IsOK = true;
            Value = value;
            ErrorMessage = null;
            Exception = null;
        }

        public void SetError(string errorMessage)
        {
            IsOK = false;            
            ErrorMessage = errorMessage;
            Exception = new Exception(errorMessage);
        }

        public void SetError(Exception ex)
        {
            IsOK = false;
            ErrorMessage = ex.Message;
            Exception = ex;
        }
    }
}
