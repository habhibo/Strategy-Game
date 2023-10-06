using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    List<GameObject> blocks = new List<GameObject>();
    GameObject[] array;
    // Start is called before the first frame update
    void Start()
    {
        array= GameObject.FindGameObjectsWithTag("cube");
        foreach(GameObject obj in array)
        {
            blocks.Add(obj);
        }
        array = GameObject.FindGameObjectsWithTag("gold");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);

        }
        array = GameObject.FindGameObjectsWithTag("radar");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
        }
        array = GameObject.FindGameObjectsWithTag("army");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
        }
        array = GameObject.FindGameObjectsWithTag("electricity");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
        }
        
        foreach (GameObject obj in blocks)
        {
            Destroy(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
