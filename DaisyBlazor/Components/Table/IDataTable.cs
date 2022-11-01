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
