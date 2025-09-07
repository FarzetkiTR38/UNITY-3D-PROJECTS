using Unity.VisualScripting;
using UnityEngine;

public class CropBehaviour : MonoBehaviour
{


    SeedData seedToGrow;

    [Header("Stages of Life")]

    public GameObject seed;
    public GameObject wilted;
    private GameObject seedling;
    private GameObject harvestable;

    int growth;
    int maxGrowth;

    int maxHealth = GameTimestamp.HoursToMinutes(48);
    int health;

    public enum CropState
    {
        Seed, Seedling, Harvestable, Wilted
    }

    public CropState cropState;

    public void Plant(SeedData seedToGrow)
    {
        this.seedToGrow = seedToGrow;

        seedling = Instantiate(seedToGrow.seedling, transform);


        ItemData cropToYield = seedToGrow.cropToYield;

        harvestable = Instantiate(cropToYield.gameModel, transform);

        int hoursToGrow = GameTimestamp.DaysToHours(seedToGrow.daysToGrow);

        maxGrowth = GameTimestamp.HoursToMinutes(hoursToGrow);

        if (seedToGrow.regrowable)
        {
            print("regrowable true olduğu için regrowableharvestbehaviour eklendi plant içindeki if çalıştı");
            RegrowableHarvestBehaviour regrowableHarvest = harvestable.GetComponent<RegrowableHarvestBehaviour>();
            regrowableHarvest.SetParent(this);

        }


        SwitchState(CropState.Seed);
    }


    public void Grow()
    {
        growth++;

        if(health < maxHealth)
        {
            health++;
        }

        if (growth >= maxGrowth / 2 && cropState == CropState.Seed)
        {
            SwitchState(CropState.Seedling);
        }

        if (growth >= maxGrowth && cropState == CropState.Seedling)
        {
            SwitchState(CropState.Harvestable);

        }

    }

    public void Wither()
    {
        health--;

        if (health <= 0 && cropState != CropState.Seed)
        {
            SwitchState(CropState.Wilted);
        }
    }

    private void SwitchState(CropState stateToSwitch)
    {

        seed.SetActive(false);
        seedling.SetActive(false);
        harvestable.SetActive(false);
        wilted.SetActive(false);

        switch (stateToSwitch)
        {
            case CropState.Seed:
                seed.SetActive(true);
                print("switchstate fnc çalıştı en baştaki case");
                break;

            case CropState.Seedling:
                seedling.SetActive(true);
                print("switchstate fnc çalıştı ortadaki case");

                health = maxHealth;
                break;

            case CropState.Harvestable:
                harvestable.SetActive(true);

                if (!seedToGrow.regrowable)
                {
                    print("regrowable false olduğu için destroy edildi harvestable objesi");
                    harvestable.transform.parent = null;
                    Destroy(gameObject);
                }


                print("switchstate fnc çalıştı en sondaki case");
                break;

            case CropState.Wilted:
                wilted.SetActive(true);
                break;
        }

        cropState = stateToSwitch;


    }


    public void Regrow()
    {
        int hoursToRegrow = GameTimestamp.DaysToHours(seedToGrow.daysToRegrow);
        growth = maxGrowth - GameTimestamp.HoursToMinutes(hoursToRegrow);

        SwitchState(CropState.Seedling);

        print("regrow fnc çalıştı");
    }
}
