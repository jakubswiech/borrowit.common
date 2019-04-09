using System;

namespace BorrowIt.Common.Extensions
{
    public static class StringExtensions
    {
        public static void ValidateNullOrEmptyString(this string value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"{propertyName ?? nameof(value)}");
            }
        }
    }
}