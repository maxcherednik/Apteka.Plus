namespace Apteka.Plus.CashRegister
{
    public static class OperatorFactory
    {
        public static IOperator CreateInstance()
        {
            return new Operator();
        }

        private class Operator : IOperator
        {
            public string Name { get; set; }

            public string Password { get; set; }
        }
    }
}
