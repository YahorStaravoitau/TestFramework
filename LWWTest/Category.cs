using System.Collections.Generic;

namespace LWWTest
{
    public class Category
    {
        public string Name { get; set; }
        public Category(string name)
        {
            Name = name;
        }
        public List<Element> elements = new List<Element>();

        public void AddElement(Element e)
        {
            elements.Add(e);
        }
    }
}