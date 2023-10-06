using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    private bool mooving = false;
    RaycastHit hit;
    private Vector3 realHitPoint;
    List<GameObject> blocks = new List<GameObject>();
    GameObject[] array;
    bool nout = true;
    // Start is called before the first frame update
    void Start()
    {
        array = GameObject.FindGameObjectsWithTag("cube");
        foreach (GameObject obj in array)
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);



            // Vector3 mousePos = Input.mousePosition.;
            // Debug.Log(mousePos);


            /*Debug.Log("dkhal aaasba");
            direction = (hit.point - transform.position);
            transform.position = transform.position + direction * speed * Time.deltaTime;*/

            // a = a + 0.00000001f * Time.deltaTime;
            // transform.position = Vector3.Lerp(transform.position, hit.point, a);
            mooving = true;
            transform.LookAt(hit.point);
            realHitPoint = new Vector3(hit.point.x, 0.2f, hit.point.z);











        }
        /*foreach (GameObject obj in blocks)
        {   

            if(Vector3.Distance(obj.transform.position, realHitPoint) <2)
            {
                nout = true;
                break;
            }
            
        }*/

        if (mooving == true)
        {
            if (nout)
            {
                transform.position = Vector3.MoveTowards(transform.position, realHitPoint, 0.2f);
                if (Vector3.Distance(transform.position, realHitPoint) < 0.3f)
                {
                    mooving = false;
                    nout = true; ;
                }
            }
            else
            {
                mooving = false;
            }


        }
    }
}
