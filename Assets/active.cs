using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player (1)");
        Player.GetComponent<arrow_pointer>().test = true;
        Player.GetComponent<arrow_pointer>().test1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
