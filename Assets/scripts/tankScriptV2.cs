using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankScriptV2 : MonoBehaviour
{
    //bool firstest = true;
    //List<GameObject> goodgoodblocks = new List<GameObject>();
    public bool test = false;
    float speed = 4;
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


            Vector3 dir1 = (new Vector3(goodBlock.transform.position.x, transform.position.y, transform.position.z) - transform.position).normalized;
            Vector3 dir2 = (new Vector3(transform.position.x  - retard, transform.position.y, goodBlock.transform.position.z+2) - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dir1);


            if (Vector3.Distance(transform.position, new Vector3(goodBlock.transform.position.x, transform.position.y, transform.position.z)) > 0.5f)
            {
                targetRotation = Quaternion.RotateTowards(
               transform.rotation,
               targetRotation,
               360 * Time.fixedDeltaTime);

                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * speed * Time.fixedDeltaTime);
                GetComponent<Rigidbody>().MoveRotation(targetRotation);
            }

            else
            {
                if (Vector3.Distance(transform.position, new Vector3(transform.position.x - retard, transform.position.y, goodBlock.transform.position.z+2 )) > 2f)
                {

                    Debug.Log("tank fel else taw  tank fel else ta ");

                    targetRotation = Quaternion.LookRotation(target.transform.position);

                    targetRotation = Quaternion.RotateTowards(
                   transform.rotation,
                   targetRotation,
                   360 * Time.fixedDeltaTime);
                    GetComponent<Rigidbody>().MoveRotation(targetRotation);

                    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir2 * speed * Time.fixedDeltaTime);
                    //GetComponent<Rigidbody>().MoveRotation(targetRotation);
                    // transform.LookAt(target.transform.position);
                }


                else
                {

                    Debug.Log("tank fel else taw ");
                    dir1 = Vector3.zero;
                    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * speed * Time.fixedDeltaTime);

                    // GetComponent<Rigidbody>().MoveRotation(targetRotation);
                    transform.LookAt(target.transform.position);




                    GameObject.Find("Player (1)").GetComponent<fightingV2>().fightIsStarted = true;


                    //GetComponent<Rigidbody>().MoveRotation(targetRotation);
                }
            }

            /*if (Vector3.Distance(transform.position, new Vector3(transform.position.x, transform.position.y, goodBlock.transform.position.z)) > 0.5f)
            {
                dir1 = (new Vector3(transform.position.x, transform.position.y, goodBlock.transform.position.z) - transform.position).normalized;
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * speed * Time.fixedDeltaTime);
                GetComponent<Rigidbody>().MoveRotation(targetRotation);
            }*/








            //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + dir1 * 7 * Time.fixedDeltaTime);
            //GetComponent<Rigidbody>().MoveRotation(targetRotation);
        }


    }

}
