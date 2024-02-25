using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private string inTheCloud = "y";

    
    void Start()
    {
        if (transform.position.y < 3.5)
        {
            inTheCloud = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    
    void Update()
    {
        if(inTheCloud == "y")
        {
            GetComponent<Transform>().position = Cloud.cloudXPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inTheCloud = "n";
            Cloud.spawned = "n";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == gameObject.tag)
        {
            Cloud.spawnPos = transform.position;
            Cloud.newFruit = "y";
            Cloud.whichFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }

}
