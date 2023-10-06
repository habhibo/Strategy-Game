using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class player_controle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8.0f;
    public Camera followCamera;
    private bool mooving = false;
    RaycastHit hit;
    private Vector3 realHitPoint;
    public List<GameObject> blocks = new List<GameObject>();
    public List<GameObject> newblocks = new List<GameObject>();
    GameObject[] array;
    bool nout = true;
    public float goldHeight = 0.5f;
    List<GameObject> specialArray = new List<GameObject>();
    List<GameObject> normalBlocks = new List<GameObject>();
    bool testToStartFn = true;
    private Rigidbody m_Rb;
    private Vector3 m_CameraPos;
    private GameObject specialBlock;
    private GameObject armyBlock;
    bool testTocalculateTime = false;
    private float secondsCount = 0;
    public GameObject gold;
    public GameObject army;
    public GameObject electricity;
    public GameObject radar;
    float min = 10;
    int index;
    public float money = 500;
    private TextMeshProUGUI text;
    private TextMeshProUGUI text1;

    public GameObject txt;
    public GameObject txt1;

    private GameObject canvas;
    public bool changingMoney = false;
    public float x;
    public int pos;
    private int electricUnitplus = 0;
    private int electricUnitminus = 1;
    public bool changingelct = false;
    public float x1;
    public int pos1;
    public int electunit;

    Animator anim;

    public bool freeMooving = true;

    public bool addingBlock = false;


    public GameObject[] newBlocksArray;

    public int newBlocksArrayCounter = 0;

    public GameObject thisNewBlock;

    public GameObject particule;


    int countfasakh = 0;


    void Start()

    {

        

        particule = GameObject.Find("Particle System");
        particule.SetActive(false);







        text = txt.GetComponent<TextMeshProUGUI>();
        text1 = txt1.GetComponent<TextMeshProUGUI>();
        electunit = int.Parse(text1.text.ToString());


        InvokeRepeating("electminus", 1.0f, 1f);

        InvokeRepeating("electplus", 1.0f, 10f);

        //text = canvas.transform.FindChild("LightMode").gameObject.transform.FindChild("Lobby").gameObject.transform.FindChild("StatusBar_Group_ColorButton").gameObject.transform.FindChild("Money").gameObject.transform.FindChild("Text").gameObject;

        array = GameObject.FindGameObjectsWithTag("cube");


        foreach (GameObject obj in array)
        {
            blocks.Add(obj);
            normalBlocks.Add(obj);
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
            specialArray.Add(obj);
            //newblocks.Add(obj);
        }
        money = float.Parse(text.text.ToString().Substring(0, text.text.ToString().Length - 1));

        anim = gameObject.GetComponent<Animator>();

        //newblocks.Clear();

    }

    void electminus()
    {
        if (electunit > 0)
        {
            electunit = electunit - electricUnitminus;
            if (electunit < 0) { electunit = 0; }
            text1.text = electunit.ToString();
        }
    }

    void electplus()
    {
        if (electunit < 500)
        {
            electunit = electunit + electricUnitplus;
            if (electunit > 500) { electunit = 500; }
            text1.text = electunit.ToString();
        }
    }

    void Update()
    {

        if (addingBlock)
        {
            AddNewBlock();
        }


        if (changingMoney)
        {
            changemoney(x, pos);
        }




        if (testToStartFn)
        {
            SearchSpecial();
        }

        if (testTocalculateTime)
        {
            if (Vector3.Distance(transform.position, specialBlock.transform.position) < 2.7)
            {
                secondsCount += Time.deltaTime;

            }
            else
            {
                secondsCount = 0;
                testTocalculateTime = false;
                testToStartFn = true;
            }
            if (secondsCount > 4)
            {
                BuildSpecialBlock();
                secondsCount = 0;
                testTocalculateTime = false;

            }
            if(secondsCount>3.6f && secondsCount < 4)
            {
                particule.transform.position = transform.position;
                particule.SetActive(true);
            }
            else
            {
                particule.SetActive(false);
            }

        }
    }
    void changemoney(float x, int pos)
    {
        money = float.Parse(text.text.ToString().Substring(0, text.text.ToString().Length - 1));

        //Debug.Log("diff is " + diff);
        if (money != x)
        {
            text.text = ((money + pos).ToString() + "k");
            money = money + pos;
        }
        else
        {
            changingMoney = false;
        }
    }
    void SearchSpecial()
    {
        testToStartFn = false;
        foreach (GameObject obj in specialArray)
        {
            if (Vector3.Distance(transform.position, obj.transform.position) < 2.7)
            {
                specialBlock = obj;
                testTocalculateTime = true;
                Debug.Log("you are in spetial");
                break;
            }
        }
        if (testTocalculateTime == false)
        {
            testToStartFn = true;
        }
    }

   
    void BuildSpecialBlock()
    {
        if (specialBlock.tag == "gold")
        {
            if (money > 9)
            {
                gold.transform.position = transform.position;
                gold.transform.Find("BlueCube (43)").position = new Vector3(specialBlock.transform.position.x, specialBlock.transform.position.y + 0.1f, specialBlock.transform.position.z);
                gold.transform.Find("Gold Miner").position = new Vector3(specialBlock.transform.position.x, 1, specialBlock.transform.position.z);
                transform.position = transform.position + new Vector3(-2, 0, 0);
                Instantiate(gold);
                specialArray.Remove(specialBlock);
                //money = money - 9;
                pos = -1;
                x = money - 9;
                changingMoney = true;
                electricUnitminus++;
            }



        }
        if (specialBlock.tag == "radar")
        {
            if (money > 12)
            {
                radar.transform.position = transform.position;
                radar.transform.Find("BlueCube (43)").position = new Vector3(specialBlock.transform.position.x, specialBlock.transform.position.y + 0.1f, specialBlock.transform.position.z);
                radar.transform.Find("RadarStationB02").position = new Vector3(specialBlock.transform.position.x, 1, specialBlock.transform.position.z);
                transform.position = transform.position + new Vector3(0, 0, -2);
                Instantiate(radar);
                radar.SetActive(true);
                radar.GetComponent<active>().enabled = true;
                specialArray.Remove(specialBlock);
                pos = -1;
                x = money - 12;
                changingMoney = true;
                electricUnitminus = electricUnitminus + 2;
            }
        }
        if (specialBlock.tag == "electricity")
        {
            if (money > 7)
            {
                electricity.transform.position = transform.position;
                electricity.transform.Find("BlueCube (43)").position = new Vector3(specialBlock.transform.position.x, specialBlock.transform.position.y + 0.1f, specialBlock.transform.position.z);
                electricity.transform.Find("Electricity Tower").position = new Vector3(specialBlock.transform.position.x, 1, specialBlock.transform.position.z);
                transform.position = transform.position + new Vector3(0, 0, -2);
                Instantiate(electricity);
                specialArray.Remove(specialBlock);
                pos = -1;
                x = money - 7;
                changingMoney = true;
                electricUnitplus = electricUnitplus + 2;
            }
        }
        if (specialBlock.tag == "army")
        {
            if (money > 12)
            {

                foreach (GameObject obj in normalBlocks)
                {
                    if (Vector3.Distance(obj.transform.position, specialBlock.transform.position) < min)
                    {
                        min = Vector3.Distance(obj.transform.position, specialBlock.transform.position);
                        armyBlock = obj;
                        index = normalBlocks.IndexOf(obj);

                    }
                }

                army.transform.position = armyBlock.transform.position - new Vector3(-3.5f, 3.5f, -3.5f);
                Debug.Log(armyBlock.transform.position);
                //army.tranarmy.transform.positionsform.FindChild("BlueCube (43)").position = new Vector3(specialBlock.transform.position.x, specialBlock.transform.position.y + 0.1f, specialBlock.transform.position.z);
                //army.transform.FindChild("RadarStationB02").position = new Vector3(specialBlock.transform.position.x - 2.3f, 3.799999f, specialBlock.transform.position.z - 0.4f);
                //transform.position = transform.position + new Vector3(4, 0, -4);
                Instantiate(army);
                normalBlocks.RemoveAt(index);
                min = 20;
                pos = -1;
                x = money - 12;
                changingMoney = true;
            }

        }
        testToStartFn = true;
    }

    void FixedUpdate()
    {




        
            float horizontalInput = Input.GetAxis("Vertical");
            float verticalInput = -Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

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
            m_Rb.MoveRotation(targetRotation);
        
    }

    private void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPos;
    }
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;
    }










    void AddNewBlock()
    {
        /*
        //Debug.Log("num :"+countfasakh.ToString() + thisNewBlock.transform.position);

        newblocks.Add(thisNewBlock);
        countfasakh++;
        addingBlock = false;




        int i = 0;
        foreach (GameObject obj in newblocks)
        {
            Debug.Log(i.ToString() + obj.transform.position.ToString());

            i++;


        }

        Debug.Log("count" + newblocks.Count);
    }*/
        int i = 0;
        
        newBlocksArray = GameObject.FindGameObjectsWithTag("invblue");
        //newBlocksArray[i] = thisNewBlock;
       
        //newBlocksArrayCounter++;
        addingBlock = false;

        


      
        


    }
}
