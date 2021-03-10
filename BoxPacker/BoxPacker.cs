using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxPacker
{
    public class BoxPacker
    {
        public List<Box> Pack(List<Article> articles, int numBoxes)
        {
            if (numBoxes < 1)
            {
                throw new ArgumentException($"Expected numBoxes at least 1. Received: {numBoxes}");
            }

            var boxes = Enumerable.Range(0, numBoxes).Select(i => new IdentifiableBox(i)).ToList();

            if (articles == null || articles.Count < 1)
            {
                return boxes.ConvertAll(b => (Box)b);
            }

            var articleCopyList = articles.OrderByDescending(a => a.WeightInGrams).ToList();
            var sortedSet = new SortedSet<IdentifiableBox>(boxes, new IdentifiableBoxComparer());

            foreach (var article in articleCopyList)
            {
                var minimumWeightBox = sortedSet.Take(1).ElementAt(0);
                sortedSet.Remove(minimumWeightBox);
                minimumWeightBox.AddItem(article);
                sortedSet.Add(minimumWeightBox);
            }

            return boxes.ConvertAll(b => (Box)b);
        }
    }
}
