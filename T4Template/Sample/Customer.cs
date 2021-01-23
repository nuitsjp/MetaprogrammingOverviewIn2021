using System;
using Commons;

namespace Sample
{
    public partial class Customer
    {
        [EqualsMember]
        public int Code { get; set; }
    }
}