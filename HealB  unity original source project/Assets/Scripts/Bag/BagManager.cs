using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{

    static BagManager instance;

    public BagList myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;

    public Player player;
    public Item currentItem;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    //public static void UpdateItemInfo(string itemDescription)
    //{
    //    instance.itemInformation.text = itemDescription;
    //}

    public static void UpdateItem(Item selectedItem)
    {
        instance.currentItem = selectedItem;
        instance.itemInformation.text = selectedItem.ItemDescription;
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform); /*.position, Quaternion.identity*/
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.ItemHeld.ToString();
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for(int i=0; i< instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }

    public void UseButton()
    {
        if (currentItem.ItemHeld > 0)
        {
            if (currentItem.itemName == "Apple")
            {
                player.HealthLevel += 1;
            }
            else if (currentItem.itemName == "Fish")
            {
                player.HealthLevel += 3;
            }
            else if (currentItem.itemName == "Banana")
            {
                player.HealthLevel += 1;
            }
            else if (currentItem.itemName == "Beef")
            {
                player.HealthLevel += 2;
            }
            else if (currentItem.itemName == "Cola")
            {
                player.HealthLevel -= 2;
                //player.extra_steps = 1;
            }
            else if (currentItem.itemName == "Crisps")
            {
                player.HealthLevel -= 1;
            }
            else if (currentItem.itemName == "Bubble tea")
            {
                player.HealthLevel -= 3;
            }
            //else if (currentItem.itemName == "water")
            //{
            //    player.HealthLevel = 2;
            //}
            //else if (currentItem.itemName == "Shoes")
            //{
            //    player.HealthLevel += 2;
            //    player.extra_steps = 1;
            //}
            currentItem.ItemHeld -= 1;
            RefreshItem();
        }
    }

    //public int CheckItem(string itemName)
    //{
    //    int value;

    //    switch (itemName)
    //    {
    //        case "Apple":
    //            value = 1;
    //            break;
    //        case "Banana":
    //            value = 1;
    //            break;
    //        case "Beef":
    //            value = 3;
    //            break;
    //        default:
    //            value = 0;
    //            break;
    //    }

    //    return value;
    //}
}


