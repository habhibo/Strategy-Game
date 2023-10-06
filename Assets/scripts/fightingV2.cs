using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingV2 : MonoBehaviour
{
    private Rigidbody m_Rb;
    Animator anim;
    float speed = 8;
    public GameObject[] newblocks;
    List<GameObject> blocks = new List<GameObject>();
    bool firsttest = true;
    public bool secondtest = true;
    public GameObject basered;
    public GameObject goodBlock;
    List<GameObject> goodblocks = new List<GameObject>();

    GameObject[] soldierred;
    GameObject[] soldierblue;
    GameObject soldierclose;

    bool moveSoldier = false;

    GameObject tank;

    public GameObject Winobj;
    public GameObject Looseobj;


    bool moveTank = false;

    public bool fightIsStarted = false;

    int retard = 0;

    public List<GameObject> goodgoodblocks = new List<GameObject>();

    int counter = 0;
    int counterred = 0;
    int counterblue = 0;

    GameObject[] soldiers;


    bool win = false;
    bool loose = false;

    bool gameEnded = false;

    float min = 3.8f;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();




    }
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        //m_CameraPos = followCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if () {
        //gameObject.GetComponent<player_controle>().freeMooving = false; ;
        //}
    }


    private void FixedUpdate()
    {


        if (gameObject.GetComponent<player_controle>().freeMooving == false)
        {
            if (firsttest)
            {
                Initialization();
            }

            if (secondtest)
            {
                firstStep();
            }

            Vector3 dir = (new Vector3(goodBlock.transform.position.x, transform.position.y, transform.position.z) - transform.position).normalized;



            if (dir == Vector3.zero)
            {
                anim.SetBool("moving", false);
                return;
            }
            anim.SetBool("moving", true);
            Quaternion targetRotation = Quaternion.LookRotation(dir);



            targetRotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                360 * Time.fixedDeltaTime);

            if (Vector3.Distance(transform.position, new Vector3(goodBlock.transform.position.x, transform.position.y, transform.position.z)) > 0.5f)
            {

                m_Rb.MovePosition(m_Rb.position + dir * speed * Time.fixedDeltaTime);
                m_Rb.MoveRotation(targetRotation);
            }
            if (Vector3.Distance(transform.position, new Vector3(transform.position.x, transform.position.y, goodBlock.transform.position.z)) > 0.5f)
            {
                dir = (new Vector3(transform.position.x, transform.position.y, goodBlock.transform.position.z) - transform.position).normalized;
                m_Rb.MovePosition(m_Rb.position + dir * speed * Time.fixedDeltaTime);
                m_Rb.MoveRotation(targetRotation);
            }
            else
            {
                dir = Vector3.zero;
                m_Rb.MovePosition(m_Rb.position + dir * speed * Time.fixedDeltaTime);
                m_Rb.MoveRotation(targetRotation);
                transform.LookAt(soldierclose.transform.position);
            }




            /*    Vector3 dir1 = (new Vector3(goodBlock.transform.position.x-4, soldiers[0].transform.position.y, goodBlock.transform.position.z -4) - soldiers[0].transform.position).normalized;

            soldiers[0].GetComponent<Rigidbody>().MovePosition(soldiers[0].GetComponent<Rigidbody>().position + dir1 * 7 * Time.fixedDeltaTime);
            soldiers[0].GetComponent<Rigidbody>().MoveRotation(targetRotation);*/

            if (moveSoldier)
            {
                MoveSoldier();
            }


            if (moveTank)
            {
                MoveTank();
            }





            if (Vector3.Distance(transform.position, soldierclose.transform.position) < 25)
            {
                if (fightIsStarted)
                {

                    foreach (GameObject sold in soldierred)
                    {
                        if (sold != null)
                        {
                            sold.transform.LookAt(transform.position);
                            sold.GetComponent<Animator>().SetBool("moving", false);
                            sold.GetComponent<Animator>().SetBool("shooting", true);
                        }
                    }
                    anim.SetBool("shooting", true);

                    startfight();
                }
            }

            if (gameEnded)
            {
                SpecialEndFunction();
            }




        }

    }

    void MoveTank()
    {
        tank.GetComponent<tankScriptV2>().retard = retard;
        tank.GetComponent<tankScriptV2>().goodBlock = goodgoodblocks[0];
        tank.GetComponent<tankScriptV2>().test = true;

        moveTank = false;
    }


    void MoveSoldier()
    {
        foreach (GameObject sold in soldiers)
        {
            if ((goodgoodblocks.Count) - 1 == counter)
            {
                Debug.Log("counter is :" + counter);
                Debug.Log("goodgoodblocks.Count :" + goodgoodblocks.Count);
                counter = 0;
                retard = retard + 1;
                counter = 0;
            }
            else
            {
                counter++;
            }

            Debug.Log("counter is 2ND :" + counter);
            sold.GetComponent<soldierhadV2>().retard = retard;
            Debug.Log("counter is 2ND :" + counter);
            sold.GetComponent<soldierhadV2>().goodBlock = goodgoodblocks[counter];
            sold.GetComponent<soldierhadV2>().test = true;

        }
        moveSoldier = false;
    }
    void Initialization()
    {
        newblocks = gameObject.GetComponent<player_controle>().newBlocksArray;
        blocks = gameObject.GetComponent<player_controle>().blocks;
        firsttest = false;
    }

    void startfight()
    {
        fightIsStarted = false;
        InvokeRepeating("realstratfight1", 1.0f, 6f);
        InvokeRepeating("realstratfight2", 1.0f, 1.5f);
    }



    void SpecialEndFunction()
    {


        if (win)
        {
            Winobj.SetActive(true);

            Debug.Log("dkhal");
        }

        if (loose)
        {
            Looseobj.SetActive(true);
            Debug.Log("dkhal");
        }

        gameEnded = false;
    }
    void realstratfight1()
    {
        if (soldierblue.Length > counterblue)
        {
            Destroy(soldierblue[counterblue]);

            counterblue++;

        }
        else
        {
            Destroy(tank);
            //yield return new WaitForSeconds(5);
            gameEnded = true;
            loose = true;
            //yield return new WaitForSeconds(5);
            //SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }

    void realstratfight2()
    {
        if (soldierred.Length > counterred)
        {

            Destroy(soldierred[counterred]);

            counterred++;
        }
        else
        {
            //yield return new WaitForSeconds(5);
            gameEnded = true;
            win = true;
            //SceneManager.LoadScene(sceneBuildIndex: 2);
        }

    }

    void firstStep()
    {

        /* foreach (GameObject obj in blocks)
         {
             foreach(GameObject obj2 in newblocks)
             {
                 if (Vector3.Distance(obj.transform.position, obj2.transform.position) < 4.1)
                 {
                     goodblocks.Add(obj2);

                 }
             }
         }

        foreach(GameObject obj in goodblocks)
         {
             if (Vector3.Distance(obj.transform.position, basered.transform.position) < min)
             {
                 goodBlock = obj;

                 min = Vector3.Distance(obj.transform.position, basered.transform.position);
             }
         }

         foreach (GameObject obj in newblocks)
         {
             if (Vector3.Distance(obj.transform.position, basered.transform.position) < min)
             {
                 goodBlock = obj;

                 min = Vector3.Distance(obj.transform.position, basered.transform.position);
             }
         }
         goodgoodblocks.Add(goodBlock);
        0in newblocks)
         {
             if (obj.transform.position.x==goodBlock.transform.position.x)
             {
                 goodgoodblocks.Add(obj);
             }
         }*/

        foreach (GameObject obj in newblocks)
        {
            if (obj.transform.position.z < min)
            {
                goodBlock = obj;

                min = obj.transform.position.z;
            }
        }

        goodgoodblocks.Add(goodBlock);

        Debug.Log("good block is :" + goodBlock.transform.position);

        foreach (GameObject obj in newblocks)
        {


            if (((obj.transform.position.z - goodBlock.transform.position.z) == 0) && obj.transform.position != goodBlock.transform.position)
            {
                goodgoodblocks.Add(obj);

                Debug.Log("dist : " + (obj.transform.position.x - goodBlock.transform.position.x));
            }
        }


        Debug.Log("tset taw taw : " + goodgoodblocks[0]);

        foreach (GameObject obj in goodgoodblocks)
        {

            Debug.Log("taw taw : " + obj.transform.position);
        }



        Debug.Log("good blocks :" + goodgoodblocks.Count);
        secondtest = false;
        soldiers = GameObject.FindGameObjectsWithTag("soldiers");
        soldierred = GameObject.FindGameObjectsWithTag("redsolider");
        soldierblue = GameObject.FindGameObjectsWithTag("bluesoldier");
        soldierclose = GameObject.FindGameObjectWithTag("redsolidierclose");
        tank = GameObject.FindGameObjectWithTag("tank");

        moveSoldier = true;
        moveTank = true;
    }
}
