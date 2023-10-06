using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extend : MonoBehaviour
{
    private GameObject text;
    private GameObject Player;
    public GameObject primitiveLand;
    RaycastHit hit;
    Vector3 realHitPoint;
    public bool active;
    List<GameObject> blocks = new List<GameObject>();
    List<GameObject> newblocks = new List<GameObject>();
    List<GameObject> specialArray = new List<GameObject>();
    GameObject[] array;
    BoxCollider[] arrayBox;

    BoxCollider[] arrayBox1;
    List<GameObject> blocksinit = new List<GameObject>();

    public List<GameObject> blocksmx = new List<GameObject>();
    public List<GameObject> blockspx = new List<GameObject>();
    public List<GameObject> blockspz = new List<GameObject>();
    public List<GameObject> blocksmz = new List<GameObject>();

    GameObject[] newBlocksArray;
    public GameObject inv;
    GameObject[] blocksmed;


    GameObject currStd;
    GameObject currStd1;


    Vector3 comparing;
    int i=0;

    Vector3 toCompare;
    // Start is called before the first frame update

    void Start()
    {
        text = gameObject.transform.Find("Text (TMP)").gameObject;

        Player = GameObject.Find("Player (1)");
        array = GameObject.FindGameObjectsWithTag("cube");


        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
        }
        array = GameObject.FindGameObjectsWithTag("gold");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
            specialArray.Add(obj);

        }
        array = GameObject.FindGameObjectsWithTag("radar");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
            specialArray.Add(obj);
        }
        array = GameObject.FindGameObjectsWithTag("army");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
            specialArray.Add(obj);
        }
        array = GameObject.FindGameObjectsWithTag("electricity");
        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
            blocksinit.Add(obj);
            specialArray.Add(obj);
        }
        //primitiveLand = blocks[0];

        /*if (gameObject.tag == "extendpz")
        {
            foreach(GameObject obj in blockspz)
            {
                //inv.transform.position = transform.position + new Vector3(0, 4, i);
                //Instantiate(inv);
                //obj.GetComponent<MeshRenderer>().enabled = false;
                //blockspz.Add(inv);
            }
            



        }
        if (gameObject.tag == "extendpx")
        {
            for (int i = 8; i < 50; i = i + 4)
            {
                inv.transform.position = transform.position + new Vector3(i, 0, 0);
                Instantiate(inv);
                //inv.GetComponent<MeshRenderer>().enabled = false;
                blockspx.Add(inv);
            }

        }
        if (gameObject.tag == "extendmz")
        {
            for (int i = 8; i < 50; i = i + 4)
            {
                inv.transform.position = transform.position + new Vector3(0, 0, -i);
                Instantiate(inv);
                //inv.GetComponent<MeshRenderer>().enabled = false;
                blocksmz.Add(inv);
            }

        }
        if (gameObject.tag == "extendmx")
        {
            for (int i = 8; i < 50; i = i + 4)
            {
                inv.transform.position = transform.position + new Vector3(-i, 0, 0);
                Instantiate(inv);
                //inv.GetComponent<MeshRenderer>().enabled = false;
                blocksmx.Add(inv);
            }
            
        }*/


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, Player.transform.position) < 3.5)
        {
            text.SetActive(true);
            active = true;
        }

        if (Vector3.Distance(transform.position, Player.transform.position) > 3.5)
        {
            text.SetActive(false);
            active = false;
        }
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            //Select stage    
            if (text.active==true)
            {
                //Player.GetComponent<buildLand>().CreateLand2(transform.position);
                transform.position = transform.position + new Vector3(10, 0, 0);

            }

        }*/
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);


            
            realHitPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            if (Vector3.Distance(realHitPoint, transform.position) < 2)
            {
                if (active == true)
                {
                    transform.position = transform.position + new Vector3(5, 5, 5);
                }
            }

        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            //if (Physics.Raycast(ray, out hit))
            //{

                //Select stage    
                //realHitPoint = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
                //if (Vector3.Distance(transform.position, realHitPoint) <2.5f)
               // {
                     if (active == true)
                    {
                        calcul();
                        
                        if (gameObject.tag == "extendpz")
                        {
                            
                            //primitiveLand.transform.localScale = new Vector3(1, 1, 1);
                            
                            
                            foreach(GameObject obj in blockspz)
                            {
                                Debug.Log(obj.transform.position);
                                obj.transform.position = obj.transform.position + new Vector3(0,0,4);
                                Debug.Log(obj.transform.position);
                            }
                            transform.position = transform.position + new Vector3(0, 0, 4);
                            primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(0, 0, 4);

                            /*arrayBox = primitiveLand.GetComponents<BoxCollider>();


                            arrayBox[0].enabled = false;  //-z
                            arrayBox[1].enabled = true;  //+x
                            arrayBox[2].enabled = true; //+z
                            arrayBox[3].enabled = true; //-x

                            comparing = primitiveLand.transform.position + new Vector3(4,0,0);

                            foreach(GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[1].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, 4);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[2].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(-4, 0, 0);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[3].enabled = false;
                                }
                            }
                            comparing = primitiveLand.transform.position + new Vector3(4, 0, 0);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();


                                    
                                    arrayBox1[3].enabled = false; //-x
                                    
                                    arrayBox[1].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, 4);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[2].enabled = false;

                                    arrayBox1[0].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(-4, 0, 0);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[3].enabled = false;
                                    arrayBox1[1].enabled = false;
                                }
                            }*/





                            Instantiate(primitiveLand);
                            blocks.Add(primitiveLand);
                    GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;
                    Player.GetComponent<player_controle>().pos = -1;
                            Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                            Player.GetComponent<player_controle>().changingMoney = true;
                     

                        }
                        if (gameObject.tag == "extendpx")
                        {
                            
                            //primitiveLand.transform.localScale = new Vector3(1, 1, 1);
                            
                            foreach (GameObject obj in blockspx)
                            {
                                obj.transform.position = obj.transform.position + new Vector3(4, 0, 0);
                            }
                            transform.position = transform.position + new Vector3(4, 0, 0);
                            primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(4, 0, 0);

                            /*arrayBox = primitiveLand.GetComponents<BoxCollider>();


                            arrayBox[0].enabled = true;  //-z
                            arrayBox[1].enabled = true;  //+x
                            arrayBox[2].enabled = true; //+z
                            arrayBox[3].enabled = false; //-x

                            comparing = primitiveLand.transform.position + new Vector3(4, 0, 0);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[1].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, 4);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[2].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, -4);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[0].enabled = false;
                                }
                            }
                            comparing = primitiveLand.transform.position + new Vector3(4, 0, 0);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();



                                    arrayBox1[3].enabled = false; //-x

                                    arrayBox[1].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, 4);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[2].enabled = false;

                                    arrayBox1[0].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, -4);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[0].enabled = false;
                                    arrayBox1[2].enabled = false;
                                }
                            }*/

                            Instantiate(primitiveLand);

                    Debug.Log("primitive land :" + primitiveLand.transform.position);
;                                



                            blocks.Add(primitiveLand);
                    GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    //newblocks = GameObject.Find("Player (1)").GetComponent<player_controle>().newblocks;
                    //newblocks.Add(primitiveLand);
                    //GameObject.Find("Player (1)").GetComponent<player_controle>().newblocks.Add(primitiveLand);
                    
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;
                    


                    Player.GetComponent<player_controle>().pos = -1;
                            Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                            Player.GetComponent<player_controle>().changingMoney = true;
                         

                        }
                        if (gameObject.tag == "extendmz")
                        {
                            if (blocksmz.Count > 0)
                            {
                                transform.position = transform.position + new Vector3(0, 0, -4);
                                Destroy(blocksmz[0]);
                                blocksmz.RemoveAt(0);

                            }
                            else
                            {
                                Destroy(gameObject);
                             }



                   /* foreach (GameObject obj in blocksmz)
                            {
                                obj.transform.position = obj.transform.position + new Vector3(0, 0, -4);
                            }*/
                            //transform.position = transform.position + new Vector3(0, 0, -4);
                            //primitiveLand.transform.localScale = new Vector3(1, 1, 1);
                            primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(0, 0, -4);


                            /*arrayBox = primitiveLand.GetComponents<BoxCollider>();


                            arrayBox[0].enabled = true;  //-z
                            arrayBox[1].enabled = true;  //+x
                            arrayBox[2].enabled = false; //+z
                            arrayBox[3].enabled = true; //-x


                            comparing = primitiveLand.transform.position + new Vector3(4, 0, 0);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[1].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, -4);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[0].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(-4, 0, 0);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[3].enabled = false;
                                }
                            }
                            comparing = primitiveLand.transform.position + new Vector3(4, 0, 0);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();



                                    arrayBox1[3].enabled = false; //-x

                                    arrayBox[1].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, -4);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[0].enabled = false;

                                    arrayBox1[2].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(-4, 0, 0);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[3].enabled = false;
                                    arrayBox1[1].enabled = false;
                                }
                            }*/

                            Instantiate(primitiveLand);
                            blocks.Add(primitiveLand);
                    GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;
                    Player.GetComponent<player_controle>().pos = -1;
                            Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                            Player.GetComponent<player_controle>().changingMoney = true;
                            Debug.Log(blocks.Count);
                      
                        }
                        if (gameObject.tag == "extendmx")
                        {
                            foreach (GameObject obj in blocksmx)
                            {
                                obj.transform.position = obj.transform.position + new Vector3(-4, 0, 0);
                            }
                            transform.position = transform.position + new Vector3(-4, 0, 0);
                            //primitiveLand.transform.localScale = new Vector3(1, 1, 1);
                            primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(-4, 0, 0);
                            
                            /*arrayBox = primitiveLand.GetComponents<BoxCollider>();
                           
                            
                            arrayBox[0].enabled = true;  //-z
                            arrayBox[1].enabled = false;  //+x
                            arrayBox[2].enabled =true; //+z
                            arrayBox[3].enabled = true; //-x

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, -4);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[0].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, 4);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[2].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(-4, 0, 0);

                            foreach (GameObject obj in blocksinit)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox[3].enabled = false;
                                }
                            }
                            comparing = primitiveLand.transform.position + new Vector3(0, 0, -4);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();



                                    arrayBox1[2].enabled = false; //-x

                                    arrayBox[0].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(0, 0, 4);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[2].enabled = false;

                                    arrayBox1[0].enabled = false;
                                }
                            }

                            comparing = primitiveLand.transform.position + new Vector3(-4, 0, 0);

                            foreach (GameObject obj in blockspz)
                            {
                                if (Vector3.Distance(obj.transform.position, comparing) < 1)
                                {
                                    arrayBox1 = obj.GetComponents<BoxCollider>();
                                    arrayBox[3].enabled = false;
                                    arrayBox1[1].enabled = false;
                                }
                            }*/

                            Instantiate(primitiveLand);
                           
                            blocks.Add(primitiveLand);
                    GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;




                    Player.GetComponent<player_controle>().pos = -1;
                            Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                            Player.GetComponent<player_controle>().changingMoney = true;
                        }

                     if (gameObject.tag == "extendpx1")
                    {

                    

                         if (blockspx.Count > 0)
                         {
                             transform.position = transform.position + new Vector3(4, 0, 0);
                             Destroy(blockspx[0]);
                             blockspx.RemoveAt(0);
                           
                    }
                         else
                          {
                            Destroy(gameObject);
                          }

                           

                          primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(4, 0, 0);



                          Instantiate(primitiveLand);
                          blocks.Add(primitiveLand);
                            GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;
                    Player.GetComponent<player_controle>().pos = -1;
                          Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                          Player.GetComponent<player_controle>().changingMoney = true;


                    }
                if (gameObject.tag == "extendpx2")
                {



                    if (blockspx.Count > 0)
                    {
                        transform.position = transform.position + new Vector3(4, 0, 0);
                        Destroy(blockspx[0]);
                        blockspx.RemoveAt(0);
                      
                    }
                    else
                    {
                        Destroy(gameObject);
                    }

                   

                    primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(4, 0, 0);



                    Instantiate(primitiveLand);
                    blocks.Add(primitiveLand);
                    GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;
                    Player.GetComponent<player_controle>().pos = -1;
                    Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                    Player.GetComponent<player_controle>().changingMoney = true;


                }
                if (gameObject.tag == "extendpx3")
                {



                    if (blockspx.Count > 0)
                    {
                        transform.position = transform.position + new Vector3(4, 0, 0);
                        Destroy(blockspx[0]);
                        blockspx.RemoveAt(0);
                      
                    }
                    else
                    {
                        Destroy(gameObject);
                    }

                

                    primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(4, 0, 0);



                    Instantiate(primitiveLand);
                    blocks.Add(primitiveLand);
                    GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;
                    Player.GetComponent<player_controle>().pos = -1;
                    Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                    Player.GetComponent<player_controle>().changingMoney = true;


                }
                if (gameObject.tag == "extendpx4")
                {



                    if (blockspx.Count > 0)
                    {
                        transform.position = transform.position + new Vector3(4, 0, 0);
                        Destroy(blockspx[0]);
                        blockspx.RemoveAt(0);
                        
                    }
                    else
                    {
                        Destroy(gameObject);
                    }

                   

                    primitiveLand.transform.position = currStd.transform.localPosition + new Vector3(4, 0, 0);



                    Instantiate(primitiveLand);
                    blocks.Add(primitiveLand);
                    GameObject.Find("Player (1)").GetComponent<player_controle>().addingBlock = true;
                    GameObject.Find("Player (1)").GetComponent<player_controle>().blocks = blocks;
                    Player.GetComponent<player_controle>().pos = -1;
                    Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money - 3;
                    Player.GetComponent<player_controle>().changingMoney = true;


                }



            }
                   

               // }

           // }
        }


        

    }
    
    void calcul()
    {

        blocks = GameObject.Find("Player (1)").GetComponent<player_controle>().blocks;

        newBlocksArray = GameObject.FindGameObjectsWithTag("invblue");

        foreach(GameObject obj in newBlocksArray)
        {
            blocks.Add(obj);
        }


        if (gameObject.tag == "extendpz")
        {
            toCompare = new Vector3(transform.position.x, 0.2133f, transform.position.z-4);

        }
        if (gameObject.tag == "extendpx")
        {
            toCompare = new Vector3(transform.position.x-4, 0.2133f, transform.position.z);
        }
        if (gameObject.tag == "extendmz")
        {
            toCompare = new Vector3(transform.position.x, 0.2133f, transform.position.z + 4);
        }
        if (gameObject.tag == "extendmx")
        {
            toCompare = new Vector3(transform.position.x + 4, 0.2133f, transform.position.z);
        }
        if (gameObject.tag == "extendpx1")
        {
            toCompare = new Vector3(transform.position.x - 4, 0.2133f, transform.position.z);
        }
        if (gameObject.tag == "extendpx2")
        {
            toCompare = new Vector3(transform.position.x - 4, 0.2133f, transform.position.z);
        }
        if (gameObject.tag == "extendpx3")
        {
            toCompare = new Vector3(transform.position.x - 4, 0.2133f, transform.position.z);
        }
        if (gameObject.tag == "extendpx4")
        {
            toCompare = new Vector3(transform.position.x - 4, 0.2133f, transform.position.z);
        }

        foreach (GameObject obj in blocks)
        {
            
            
           
           
            if (Vector3.Distance(obj.transform.position, toCompare) < 0.5f)
            {
                
                currStd = obj;
                

                //primitiveLand = currStd;
                break;
            }
        }
    }
}
