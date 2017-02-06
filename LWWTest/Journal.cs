using System.Collections.Generic;

namespace LWWTest
{
    public class Journal
    {
        public List<Category> category = new List<Category>();
        public string Name { get; set; }

        public Journal(string name)
        {
            Name = name;
        }

        public void AddCategory(Category cat)
        {
            category.Add(cat);
        }
    }
}