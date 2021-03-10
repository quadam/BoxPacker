using System;
using System.Collections.Generic;
using System.Text;

namespace BoxPacker
{
    internal class IdentifiableBox : Box
    {
        public long Id { get; set; }

        public IdentifiableBox(long id) : base()
        {
            Id = id;
        }
    }
}
