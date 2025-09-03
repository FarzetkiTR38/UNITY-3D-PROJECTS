using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(menuName = "Items/Seed")]
public class SeedData : ItemData
{


    public int daysToGrow;

    public ItemData cropToYield;


    public GameObject seedling;

}
