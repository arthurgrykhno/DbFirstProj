using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DbFirstProj.Services.BusinessLogic.Attributes
{
    public class NumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string input = value.ToString();
                for (int i = 0; i < input.Length; i++)
                {
                    if (!Char.IsDigit(input[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
