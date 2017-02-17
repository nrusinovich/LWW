using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework1
{
   class Journal
    {
        public string Name { get; set; }
        public Journal(string name)
        {
           Name = name;
        }
        public List<Category> menuContent = new List<Category>();
        public void AddMenuItem(Category category)
        {
            menuContent.Add(category);
        }
        
    }
}
