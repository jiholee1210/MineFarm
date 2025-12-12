using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    SortedDictionary<int, int> weapon = new();
    SortedDictionary<int, int> gloves = new();
    SortedDictionary<int, int> shoes = new();
    SortedDictionary<int, int> accs = new();

    int gold = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("Gold: " + gold);
    }
}
