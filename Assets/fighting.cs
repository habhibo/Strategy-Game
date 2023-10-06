using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fighting : MonoBehaviour
{
    private Rigidbody m_Rb;
    Animator anim;
    float speed = 8;
    public GameObject[] newblocks;
    List<GameObject> blocks = new List<GameObject>();
    bool firsttest=true;
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
    

    bool moveTank= false;

    public bool fightIsStarted=false;

    int retard = 0;

    public List<GameObject> goodgoodblocks = new List<GameObject>();

    int counter = 0;
    int counterred = 0;
    int counterblue = 0;

    GameObject[] soldiers;


    bool toMainmenu = false;


    bool win=false;
    bool loose = false;
        
    bool gameEnded =  false;

    float seconds = 0;

    float X = 4;
    float Z = 4;

    bool nowX = true;
    bool nowY = false;

    bool iswin = false;
    bool isloose = false;



    bool fffstartfight = true;

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
            /*if (firsttest)
            {
                Initialization();
            }*/

            if (secondtest)
            {
                firstStep();
            }

           

            if (moveSoldier)
            {
                MoveSoldier();
            }


            if (moveTank)
            {
                MoveTank();
            }

            
          


            if (Vector3.Distance(transform.position, soldierclose.transform.position) < 20 )
            {
                fightIsStarted = true;

                foreach (GameObject sold in soldiers)
                {
                    foreach (Transform child in sold.transform)
                    {
                        if (child != null)
                        {

                            //sold.transform.LookAt(transform.position);

                            child.GetComponent<Animator>().SetBool("shooting", true);
                            child.GetComponent<soldierhad>().test2 = true;
                        }
                    }

                }

                foreach (GameObject sold in soldierred)
                {
                    
                    
                        if (sold != null)
                        {
                            //sold.transform.LookAt(transform.position);

                            sold.GetComponent<Animator>().SetBool("shooting", true);
                            sold.transform.LookAt(transform.position);

                        }
                    

                }



                anim.SetBool("shooting", true);
                if (fffstartfight)
                {

                    startfight();
                }
                if (tank != null)
                {
                    tank.GetComponent<tankscript>().test2 = true;
                }


            }
            else
            {
                fightIsStarted = false;

                foreach (GameObject sold in soldiers)
                {
                    foreach (Transform child in sold.transform)
                    {
                        if (child != null)
                        {
                            //sold.transform.LookAt(transform.position);

                            child.GetComponent<Animator>().SetBool("shooting", false);
                            child.GetComponent<soldierhad>().test2 = false;
                        }
                    }

                }
                foreach (GameObject sold in soldierred)
                {
                    
                    
                        if (sold != null)
                        {
                            //sold.transform.LookAt(transform.position);

                            sold.GetComponent<Animator>().SetBool("shooting", false);
                            
                        }
                    

                }
                anim.SetBool("shooting", false);

                tank.GetComponent<tankscript>().test2 = false;

            }


            if (gameEnded)
            {
                SpecialEndFunction();
            }


            if (win)
            {
                seconds += Time.deltaTime;

                if (seconds > 3)
                {
                    Winobj.SetActive(true);
                    toMainmenu = true;
                    seconds = 0;
                    win = false;

                    iswin = true;
                }

                
            }




            if (loose)
            {
                seconds += Time.deltaTime;

                if (seconds > 3)
                {
                    Looseobj.SetActive(true);
                    toMainmenu = true;
                    seconds = 0;
                    loose = false;
                    isloose = true;
                }


            }

            if (toMainmenu) {

                seconds += Time.deltaTime;

                if (seconds > 2 && isloose)
                {
                    SceneManager.LoadScene(sceneBuildIndex: 0);
                }

                if (seconds > 2 && iswin)
                {
                    SceneManager.LoadScene(sceneBuildIndex: 1);
                }
            }
            


        }


    }

    void MoveTank()
    {
       
        tank.GetComponent<tankscript>().test = true;

        moveTank = false;
    }


    void MoveSoldier()
    {
        
        foreach (GameObject sold in soldiers)
        {
            foreach (Transform child in sold.transform)
            {
                child.GetComponent<soldierhad>().test = true;
                child.GetComponent<soldierhad>().X = X;
                child.GetComponent<soldierhad>().Z = Z;

                if (nowX)
                {
                    X = X + 0.7f;
                    nowX = false;
                }
                else
                {
                    if (nowY)
                    {
                        Z = Z + 1;
                    }
                    else
                    {
                        Z = Z - 2;
                    }
                    
                    nowX = true;
                    //if(nowY)
                }
                


            }

        }






        moveSoldier = false;
    }
    /*void Initialization()
    {
        newblocks = gameObject.GetComponent<player_controle>().newBlocksArray;
        blocks = gameObject.GetComponent<player_controle>().blocks;
        firsttest = false;
    }
    */
    void startfight()
    {
        fffstartfight = false;
        if (fightIsStarted)
        {
            InvokeRepeating("realstratfight1", 1.0f, 6f);
            InvokeRepeating("realstratfight2", 1.0f, 1.5f);
        }
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
        if (fightIsStarted)
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
        
    }

    void realstratfight2()
    {
        if (fightIsStarted)
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
       
      
    }

    void firstStep()
    {
        /*

        foreach (GameObject obj in newblocks)
        {
            if (obj.transform.position.x > min)
            {
                goodBlock = obj;

                min = obj.transform.position.x;
            }
        }

        goodgoodblocks.Add(goodBlock);

        Debug.Log("good block is :" + goodBlock.transform.position);

        foreach (GameObject obj in newblocks)
         {
            

            if (((obj.transform.position.x - goodBlock.transform.position.x) ==0) && obj.transform.position!= goodBlock.transform.position)
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



        Debug.Log("good blocks :" + goodgoodblocks.Count);*/
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
