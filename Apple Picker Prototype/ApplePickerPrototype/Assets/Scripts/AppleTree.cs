using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Declare our class fields
    //Prefab for instantiating apples
    public GameObject applePrefab;
    //Speed at which the Apple Tree moves in meters/second
    public float speed = 5f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 30f;
    //Change that the AppleTree will change directions
    public float chanceToChangeDirections = 0.0045f;
    //Rate at which our apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    //Use this for initialization

    void Start()
    {
        //Drop apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }
    }

    public float AppleTreeSpeed()
    {
        return speed;
    }

    void FixedUpdate()
    {
        //Change direction randomly
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change direction
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
}
