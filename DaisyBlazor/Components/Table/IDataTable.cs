using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public interface IDataTable
    {
        void AddSelectedItem(object item);

        void RemoveSelectedItem(object item);

        void SelectAllItems();

        void ClearSelectedItems();
    }
}
