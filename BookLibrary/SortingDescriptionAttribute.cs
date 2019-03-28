using System;

namespace BookLibrary
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false, Inherited = false)]
    public class SortingDescriptionAttribute : Attribute
    {
        public string Text { get; set; }

        public SortingDescriptionAttribute(string text)
        {
            Text = text;
        }
    }
}