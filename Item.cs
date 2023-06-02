namespace Bossfight
{
    public class Item
    {
        public string ItemType { get; }
        public Item()
        {
            ItemType = RandomItemType();
        }
        private string RandomItemType()
        {
            var itemtypes = new string[3] { "StaminaPotion", "HealthPotion", "StrengthPotion" };
            return itemtypes[RandomIndex(itemtypes.Length)];
        }
        private int RandomIndex(int length)
        {
            var num = new Random();
            return num.Next(0, length);
        }
    }
}