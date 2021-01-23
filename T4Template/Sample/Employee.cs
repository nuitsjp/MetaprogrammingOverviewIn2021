using System;
using Commons;

namespace Sample
{
    public partial class Employee
    {
        [EqualsMember]
        public int Id { get; set; }
    }
}
