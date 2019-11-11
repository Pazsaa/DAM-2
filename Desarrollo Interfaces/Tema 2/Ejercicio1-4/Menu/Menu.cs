using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Menu
{
    public class Menu
    {
        public Menu(IEnumerable<string> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyList<string> Items { get; }

        public int selectedIndex { get; private set; } = -1; // no selection
        public string selectedOpt => selectedIndex != -1 ? Items[selectedIndex] : null;

        public void moveUp() => selectedIndex = Math.Max(selectedIndex - 1, 0);
        public void moveDown() => selectedIndex = Math.Min(selectedIndex + 1, Items.Count - 1);
    }
}
