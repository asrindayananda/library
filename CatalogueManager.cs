using System;
using System.Linq;
using System.Collections.Generic;
using Project_2.Exceptions;

namespace Project_2.Catalogue
{
    public static class CatalogueManager
    {
        private static List<Item> _CatalogueItems = new List<Item>();
        public static List<Item> CatalogueItems
        {
            get { return _CatalogueItems; }
        }

        public static void Add(Item item)
        {
            if (_CatalogueItems.AsEnumerable().SingleOrDefault(it => it.CompareTo(item) == 0) != null)
                throw new ItemExistsException();

            _CatalogueItems.Add(item);
        }

        public static Item[] FindByTitle(string title)
        {
            List<Item> matchList = new List<Item>();

            foreach (Item i in _CatalogueItems)
            {
                if (i.Title.Contains(title))
                    matchList.Add(i);
            }

            return matchList.ToArray();
        }
    }
}
