using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public enum InvetoryItem
    {
        Torch,
        Seeds,
    }

    private List<InvetoryItem> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<InvetoryItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Contains(InvetoryItem item)
    {
        return items.Contains(item);
    }

    public void Add(InvetoryItem item)
    {
        items.Add(item);
    }
}
