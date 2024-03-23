namespace DaisyBlazor
{
    public interface ITable<TItem>
    {
        bool Hover { get; set; }
        
        void AddSelectedItem(TItem item);

        void RemoveSelectedItem(TItem item);

        void SelectAllItems();

        void ClearSelectedItems();
    }
}
