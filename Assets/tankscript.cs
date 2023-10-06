using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankscript : MonoBehaviour
{
    //bool firstest = true;
    //List<GameObject> goodgoodblocks = new List<GameObject>();
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 movement;

    public Transform target;
    public Vector3 lookposition;
    public bool test = false;

    public bool test2 = false;

    public GameObject redtarget;



    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player (1)").transform;
        redtarget = GameObject.FindGameObjectWithTag("redsolidierclose");


    }

    // Update is called once per frame
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (test)
        {
            //transform.LookAt(target.position);

                var step = 30 * Time.deltaTime; // calculate distance to move

                if (Vector3.Distance(target.position, transform.position) > 4)
                {
                //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                //rb. = Vector3.MoveTowards(transform.position, target.position, step);
                Vector3 vect = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, target.position.z - transform.position.z).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(vect);
                
                targetRotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                360 * Time.fixedDeltaTime);
                rb.MovePosition(rb.position + vect * 5 * Time.fixedDeltaTime);
                 rb.MoveRotation(targetRotation); 
                }


                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, target.position) < 0.001f)
                {
                    // Swap the position of the cylinder.
                    target.position *= -1.0f;
                }

               
            }
        if (test2)
        {
            transform.LookAt(redtarget.transform.position);
        }

    }







    /* Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

             if (movement == Vector3.zero)
             {
                 anim.SetBool("moving", false);
                 return;
             }
 anim.SetBool("moving", true);
 Quaternion targetRotation = Quaternion.LookRotation(movement);



 targetRotation = Quaternion.RotateTowards(
     transform.rotation,
     targetRotation,
     360 * Time.fixedDeltaTime);

 m_Rb.MovePosition(m_Rb.position + movement * speed * Time.fixedDeltaTime);
 m_Rb.MoveRotation(targetRotation);*/

}

