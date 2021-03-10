using System;
using System.Collections.Generic;
using System.Text;

namespace BoxPacker
{
    public class Article
    {
        public int WeightInGrams
        {
            get;
            private set;
        }

        public Article(int weight)
        {
            if (weight < 100 || weight > 1000)
            {
                throw new ArgumentException("Weight can only be between 100 and 1000 grams");
            }

            WeightInGrams = weight;
        }
    }
}
