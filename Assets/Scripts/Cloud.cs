using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cloud : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawned = "n";
    static public Vector2 cloudXPosition;
    static public Vector2 spawnPos;
    static public string newFruit = "n";
    static public int whichFruit = 0;
    public TextMeshProUGUI score;
    public int mundo;
    void Start()
    {

    }

    void Update()
    {
        spawnFruit();
        replaceFruit();

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector2(-2, 0);
        }

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector2(2, 0);
        }

        if ((!Input.GetKey("a")) && (!Input.GetKey("d")))
        {
            GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
        }

        cloudXPosition = transform.position;
        score.text = "Score " + mundo;
    }

    void spawnFruit()
    {
        if(spawned == "n")
        {
            StartCoroutine(spawnTimer());
            spawned = "y";
        }
    }
    void replaceFruit()
    {
        if (newFruit == "y")
        {
            newFruit = "n";
            Instantiate(fruitObj[whichFruit + 1], spawnPos, fruitObj[0].rotation);
            mundo++;
        }
    }
 

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(0.75f);
        Instantiate(fruitObj[Random.Range(0, 3)], transform.position, fruitObj[0].rotation);
    }
}
