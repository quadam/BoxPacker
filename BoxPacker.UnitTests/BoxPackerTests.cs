using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxPacker.UnitTests
{
    [TestClass]
    public class BoxPackerTests
    {
        private List<Article> InitArticles(IEnumerable<int> weights)
        {
            return weights.Select(w => new Article(w)).ToList();
        }

        [TestMethod]
        public void Test_BoxPacker_Pack()
        {
            var articles = InitArticles(new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 });
            int numBoxes = 4;

            var packer = new BoxPacker();

            var boxes = packer.Pack(articles, numBoxes);

            Assert.AreEqual(4, boxes.Count);
            Assert.IsTrue(boxes.Exists(b => b.TotalWeightInGrams == 1300));
            Assert.IsTrue(boxes.Exists(b => b.TotalWeightInGrams == 1400));
            Assert.IsTrue(boxes.Exists(b => b.TotalWeightInGrams == 1500));
            Assert.IsTrue(boxes.Exists(b => b.BoxItems.Count == 2));
            Assert.IsTrue(boxes.Exists(b => b.BoxItems.Count == 3));
        }

        [TestMethod]
        public void Test_BoxPacker_PackMany()
        {
            int articleCount = 500000;
            int boxCount = articleCount / 10;

            Random random = new Random();
            var articles = InitArticles(Enumerable.Range(0, articleCount).Select(_ => random.Next(100, 1000)));

            var packer = new BoxPacker();

            var boxes = packer.Pack(articles, boxCount);
        }

        [TestMethod]
        public void Test_BoxPacker_PackMore()
        {
            int articleCount = 1000000;
            int boxCount = articleCount / 10;

            Random random = new Random();
            var articles = InitArticles(Enumerable.Range(0, articleCount).Select(_ => random.Next(100, 1000)));

            var packer = new BoxPacker();

            var boxes = packer.Pack(articles, boxCount);
        }
    }
}
