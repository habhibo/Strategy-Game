using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_f : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                //Select stage    
                if (Vector3.Distance(transform.position, hit.transform.position) < 1.2f)
                {
                    //Player.GetComponent<buildLand>().CreateLand2(transform.position);
                    transform.position = transform.position + new Vector3(10, 0, 0);

                }
                
            }
        }

    }

    

}
