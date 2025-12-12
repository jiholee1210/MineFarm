using System.Collections.Generic;
using UnityEngine;

public class NormalDungeon : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform telPos;

    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private Transform stonesParent;

    HashSet<(int x, int y)> stones = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 Interact()
    {
        GenStones();
        return telPos.position;
    }

    private void GenStones()
    {
        DestroyStones();
        
        int count = 10;

        while (count > 0)
        {
            int x = Random.Range(-4, 4);
            int y = Random.Range(-3, 3);
            if(stones.Count > 0)
            {
                if(stones.Contains((x, y))) continue;
            }
            GameObject stoneObj = Instantiate(stonePrefab, stonesParent);
            stoneObj.transform.localPosition = new Vector3(x, y, 0);
            stones.Add((x, y));
            count--;
        }
    }

    private void DestroyStones()
    {
        foreach(Transform stone in stonesParent)
        {
            Destroy(stone.gameObject);
        }
        stones.Clear();
    }
}
