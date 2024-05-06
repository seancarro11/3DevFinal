[System.Serializable]

public class CheesePickup
{
    public string moniker;
    public int count;

    public CheesePickup(string itemName, int itemCount)
    {
        moniker = itemName;
        count = itemCount;

    }
}
