using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGenerator.Metaprogramming
{
    public abstract class BaseTemplate
    {
        public static readonly int DefaultCapacity = 2048;

        public static int Capacity { get; set; } = DefaultCapacity;

        public string? Namespace { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Accessibility { get; set; }
        public List<string> Members { get; set; } = new();

        protected StringBuilder GenerationEnvironment { get; } = new(Capacity);

        public abstract string TransformText();

        public void Write(string text)
        {
            GenerationEnvironment.Append(text);
        }

        public class ToStringInstanceHelper
        {
            public string ToStringWithCulture(object objectToConvert)
            {
                return (string)objectToConvert;
            }
        }

        public ToStringInstanceHelper ToStringHelper { get; } = new();
    }
}
