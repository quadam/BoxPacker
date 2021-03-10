using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BoxPacker
{
    internal class IdentifiableBoxComparer : IComparer<IdentifiableBox>
    {
        public int Compare([DisallowNull] IdentifiableBox x, [DisallowNull] IdentifiableBox y)
        {
            var diff = x.TotalWeightInGrams - y.TotalWeightInGrams;

            return diff == 0 ? Convert.ToInt32(x.Id - y.Id) : diff;
        }
    }
}
