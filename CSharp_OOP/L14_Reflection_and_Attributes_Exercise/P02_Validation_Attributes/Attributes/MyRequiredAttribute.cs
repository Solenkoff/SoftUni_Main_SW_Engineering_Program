﻿namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string str = (string)obj;

            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
