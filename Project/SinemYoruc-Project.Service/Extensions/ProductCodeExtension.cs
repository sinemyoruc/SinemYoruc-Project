using System;

namespace SinemYoruc_Project
{
    public class ProductCodeExtension<T>
    {
        public string GetProductCode()
        {
            Random rnd = new Random();
            int num, num2;
            char ch;
            string productCode = null;
            for (int i = 0; i < 6; i++)
            {
                num = rnd.Next(1, 9);
                num2 = rnd.Next(65, 91);
                ch = Convert.ToChar(num2);
                productCode += num.ToString() + ch.ToString();
            }
            return productCode;

        }
    }
}
