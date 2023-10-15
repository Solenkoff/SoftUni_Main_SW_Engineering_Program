namespace Gym.Utilities
{
    using System;

    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

    }
}
