using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> content = new List<ItemData>();

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField]
    private Transform inventorySlotsParent;

    [SerializeField]
    private Sprite transparentTexture;


    private void Start ()
    {
        inventoryPanel.SetActive(false);
        RefreshContent();
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            RefreshContent();
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        if (GetContentCount() > GetInventorySlotCount())
        {
            content.RemoveAt(inventorySlotsParent.childCount);
        }
    }

    public void AddItem (ItemData item)
    {
        content.Add(item);
        RefreshContent();
    }

    public void CloseInventory ()
    {
        inventoryPanel.SetActive(false);
    }

    public int GetContentCount ()
    {
        return content.Count;
    }

    public int GetInventorySlotCount ()
    {
        return inventorySlotsParent.childCount;
    }

    private void RefreshContent ()
    {
        //for (int i = 0; i < content.Count; i++)
        //{
        //    inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visual;
        //}

        for (int i = 0; i < GetInventorySlotCount(); i++)
        {
            if (i < GetContentCount())
            {
                inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visual;
            } else
            {
                inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentTexture;
            }
            
        }
    }
}
