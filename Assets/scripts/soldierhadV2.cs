using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierhadV2 : MonoBehaviour
{//bool firstest = true;
    //List<GameObject> goodgoodblocks = new List<GameObject>();
    public bool test = false;
    float speed = 7;
    public int retard;

    GameObject target;
    public GameObject goodBlock;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("redsolidierclose");


    }

    // Update is called once per frame
    void Update()
    {
        /*if(GameObject.Find("Player (1)").GetComponent<fighting>().secondtest == false)
        {
            if (firstest == true) { 
            firstfn();
            }
        }*/



        if (test)
        {
            foreach (Transform child in transform)
            {


                child.GetComponent<Animator>().SetBool("moving", true);

            }

            Vector3 dir1 = (new Vector3(goodBlock.transform.position.x - retard, transform.position.y, goodBlock.transform.position.z ) - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dir1);


            if (Vector3.Distance(transform.position, new Vector3(goodBlock.transform.position.x - retard, transform.position.y, goodBlock.transform.position.z )) > 0.5f)
            {
                targetRotation = Quaternion.RotateTowards(
               transform.rotation,
               targetRotation,
               360 * Time.fixedDeltaTime);

                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * speed * Time.fixedDeltaTime);
                GetComponent<Rigidbody>().MoveRotation(targetRotation);
            }
            /*if (Vector3.Distance(transform.position, new Vector3(transform.position.x, transform.position.y, goodBlock.transform.position.z)) > 0.5f)
            {
                dir1 = (new Vector3(transform.position.x, transform.position.y, goodBlock.transform.position.z) - transform.position).normalized;
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * speed * Time.fixedDeltaTime);
                GetComponent<Rigidbody>().MoveRotation(targetRotation);
            }*/
            else
            {
                dir1 = Vector3.zero;
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * speed * Time.fixedDeltaTime);

                GetComponent<Rigidbody>().MoveRotation(targetRotation);

                foreach (Transform child in transform)
                {
                    child.GetComponent<Animator>().SetBool("moving", false);
                    child.transform.LookAt(target.transform.position);
                    child.GetComponent<Animator>().SetBool("shooting", true);

                }

                //GetComponent<Rigidbody>().MoveRotation(targetRotation);
            }







            //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * 7 * Time.fixedDeltaTime);
            //  GetComponent<Rigidbody>().MoveRotation(targetRotation);
        }


    }

    /*void firstfn()
    {
        goodgoodblocks = GameObject.Find("Player (1)").GetComponent<fighting>().goodgoodblocks;
        firstest = false;
    }*/
}
