using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private string plantName;
    private float growTime;
    private int stackQuantity;
    private float sellPrice;
    private float buyPrice;

    public Plant (string plantName, float growTime, int stackQuantity, float sellPrice, float buyPrice)
    {
        this.plantName = plantName;
        this.growTime = growTime;
        this.stackQuantity = stackQuantity;
        this.sellPrice = sellPrice;
        this.buyPrice = buyPrice;
    }
}
