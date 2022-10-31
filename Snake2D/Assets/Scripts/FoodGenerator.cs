using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject apple;
    void Start()
    {
        GenerateFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateFood()
    {
        Vector3 newPos=Vector3.zero ;
        newPos.Set(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        Instantiate(apple, newPos, Quaternion.identity);
    }
}
