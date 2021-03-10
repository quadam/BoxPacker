using System;
using System.Collections.Generic;
using System.Text;

namespace BoxPacker
{
    public class Box
    {
        private List<Article> _boxItems;

        public List<Article> BoxItems
        {
            get
            {
                return _boxItems;
            }
        }

        public int TotalWeightInGrams { get; private set; }

        public Box()
        {
            _boxItems = new List<Article>();
            TotalWeightInGrams = 0;
        }

        public void AddItem(Article article)
        {
            _boxItems.Add(article);
            TotalWeightInGrams += article.WeightInGrams;
        }
    }
}
