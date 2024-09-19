namespace Scripts.Systems.ItemSystem;

interface IItemContainer {
    Item AddItem(Item item);
    void RemoveItem(Item item);
    void RemoveAt(int index);
    void Swap(int indexOne, int indexTwo);
    bool HasItem(Item item);
}
