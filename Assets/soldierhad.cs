using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierhad : MonoBehaviour
{
    //bool firstest = true;
    //List<GameObject> goodgoodblocks = new List<GameObject>();
    public bool test = false;
    public bool test2 = false;
    float speed = 7;
    public int retard;

    //GameObject target;
    public GameObject goodBlock;
    private GameObject Player;
    private Rigidbody rb;
    private Vector3 offset;

    public GameObject redtarget;

    public float X;
    public float Z;




    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target

    void Start()
    {
        target = GameObject.Find("Player (1)").transform;
        redtarget=GameObject.FindGameObjectWithTag("redsolidierclose");
        //rb = this.GetComponent<Rigidbody>();
        /*foreach (Transform child in transform)
        {


            child.GetComponent<Animator>().SetBool("moving", true);

        }*/
    }

    // Update is called once per frame
    void Update()
    {

        if (test)
        {
            // Move our position a step closer to the target.
            var step = 4 * Time.deltaTime; // calculate distance to move

            if (Vector3.Distance(target.position, transform.position) > X)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x , target.position.y, target.position.z -Z), step);
               GetComponent<Animator>().SetBool("moving", true);
                transform.LookAt(target.position);
            }
            else
            {
                GetComponent<Animator>().SetBool("moving", false);
            }

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                target.position *= -1.0f;
            }

            offset = transform.position - target.transform.position;
            transform.position = target.transform.position + offset;
        }

        if (test2)
        {
            transform.LookAt(redtarget.transform.position);
        }




    }

    
   

    // Update is called once per frame


}

/*void firstfn()
{
    goodgoodblocks = GameObject.Find("Player (1)").GetComponent<fighting>().goodgoodblocks;
    firstest = false;
}*/

