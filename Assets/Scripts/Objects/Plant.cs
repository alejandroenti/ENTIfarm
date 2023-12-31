public class Plant
{
    private int plantId;
    private string plantName;
    private float growTime;
    private int stackQuantity;
    private float sellPrice;
    private float buyPrice;

    public Plant (int id_plant, string plantName, float growTime, int stackQuantity, float sellPrice, float buyPrice)
    {
        this.plantId = id_plant;
        this.plantName = plantName;
        this.growTime = growTime;
        this.stackQuantity = stackQuantity;
        this.sellPrice = sellPrice;
        this.buyPrice = buyPrice;
    }

    public int GetPlantID() => plantId;
    public string GetPlantName() => plantName;
    public float GetGrowTime() => growTime;
    public int GetStackQuantity() => stackQuantity;
    public float GetSellPrice() => sellPrice;
    public float GetBuyPrice() => buyPrice;

}
