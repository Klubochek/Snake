using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SnakeTail : MonoBehaviour
{
    public TextMeshProUGUI tMPro;
    public int score;
    private int indexOfTail=0;
    public Object fg;
    public float radius; // радиус элеменат змейки;
    public GameObject snakeTail;
    public Transform snakeTrasform;
    public List<Transform> transforms = new List<Transform>();//Позиция всех хвостов
    public List<Vector3> positions = new List<Vector3>();// позиции для перемещения с дилеем(включая голову змеи)
    void Start()
    {
        positions.Add(snakeTrasform.position);
        AddTail();
        AddTail();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (snakeTrasform.position - positions.First()).magnitude;

        if (distance > radius * 2) 
        {
            Vector3 direction = ((Vector3)snakeTrasform.position - positions[0]).normalized;

            positions.Insert(0, positions[0]+direction*(radius*2));
            positions.Remove(positions.Last());
            distance -= radius * 2;
        }
        for (int i=0; i < transforms.Count; i++) 
        {
            transforms[i].position = Vector3.Lerp(positions[i + 1], positions[i],distance/(radius*2));
        }
    }
    public void AddTail() 
    {
        indexOfTail++;
        GameObject newTail = Instantiate(snakeTail, positions.Last(), Quaternion.identity);
        Transform newSnakePart = newTail.transform;
        transforms.Add(newSnakePart);
        positions.Add(newSnakePart.position);
        newTail.name = $"Tail{indexOfTail}";

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            print("if1");
            FoodGenerator foodGen = fg.GetComponent<FoodGenerator>();
            Destroy(collision.gameObject);
            AddTail();
            foodGen.GenerateFood();
            score++;
            tMPro.text = $"SCORE:{score}";
        }
        else if (collision.gameObject.name != "Tail1" && collision.gameObject.name != "Tail2" && collision.gameObject.name != "Tail3")
        {
            print("if2");
            SceneManager.LoadScene(0);
        }

        else if (collision.gameObject.tag == "Tile")
        {
            print("if3");
            SceneManager.LoadScene(0);
        }
    }

}
