using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public interface IDataTable<TItem>
    {
        void AddSelectedItem(TItem item);

        void RemoveSelectedItem(TItem item);

        void SelectAllItems();

        void ClearSelectedItems();
    }
}
