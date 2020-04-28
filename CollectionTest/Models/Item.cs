using System.Collections.Generic;

namespace CollectionTest.Models
{
    public class ItemGroup: List<Item>
    {
        public string Name { get; set; }
        public ItemGroup(string name, IEnumerable<Item> items) : base(items)
        {
            Name = name;
        }
    }

    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int Padding { get; set; }
    }
}