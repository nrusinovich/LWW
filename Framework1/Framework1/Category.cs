using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework1
{
    class Category
    {
        public string Name { get; set; }
        public Category(string name)
        {
            Name = name;
        }
        public List<string> content = new List<string>();
        public void AddItem(string item)
        {
            content.Add(item);
        }
    }
}
