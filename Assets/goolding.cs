using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goolding : MonoBehaviour
{

    public Rigidbody projectile;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 1.0f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LaunchProjectile()
    {

        if (GameObject.Find("Player (1)").GetComponent<player_controle>().electunit > 0)
        {
            Rigidbody instance = Instantiate(projectile);
            projectile.transform.position = transform.position;

            //instance.velocity = new Vector3(3,3,3);
            instance.AddForce(4, 4, 4);
        }



    }

  
}
