namespace Rhino.Etl.Tests.Fibonacci.Bulk
{
    using Core;
    using Errors;
    using Output;

    public class BulkInsertFibonacciToDatabaseFromConnectionStringSettings : EtlProcess
    {
        private readonly int max;
        private readonly Should should;

        public BulkInsertFibonacciToDatabaseFromConnectionStringSettings(int max, Should should)
        {
            this.max = max;
            this.should = should;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected override void Initialize()
        {
            Register(new FibonacciOperation(max));
            if (should == Should.Throw)
                Register(new ThrowingOperation());
            Register(new FibonacciBulkInsertFromConnectionStringSettings());
        }
    }
}