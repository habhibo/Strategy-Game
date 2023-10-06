using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildLand : MonoBehaviour
{
    public GameObject primitiveLand;
    private float x = 6.936073f;
    private int i;
    private int j;
    private List<Vector3> blocksLocation = new List<Vector3>();
    Vector3 tr;
    Vector3 currentBlock;
    Vector3 testBlock;
    Vector3 testBlock1;
    Vector3 testBlock2;
    Vector3 testBlock3;
    private int epsilonX;
    private int epsilonY;
    private List<Vector3> emptyCousinBlocks = new List<Vector3>();
    float diff1 = 4;
    float diff2 = 4;
    private bool mooving = false;
    RaycastHit hit;
    private Vector3 realHitPoint;
    bool yMove=false;
    Vector3 target;
    public GameObject border;
    private float  newX;
    private float  newY;
    void Start()
    {
        for (i = 0; i < 40; i = i + 4)
        {
            for (j = 0; j < 24; j = j + 4)
            {
                blocksLocation.Add(new Vector3(i,  6.0899f, j));
            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //x = x - 4;
            
            if((transform.position.x % 4)<2)
            {
                epsilonX = 0;
            }
            else
            {
                epsilonX = 4;
            }
            if((transform.position.z % 4)<2)
            {
                epsilonY = 0;
            }
            else
            {
                epsilonY=4;
            }
            currentBlock = new Vector3((transform.position.x -(transform.position.x % 4) + epsilonX), 6.0899f, (transform.position.z - (transform.position.z % 4) + epsilonY));
            //Debug.Log(currentBlock);
            testBlock = new Vector3(currentBlock.x - 4, currentBlock.y, currentBlock.z);
            //Debug.Log("test block 0 :" + testBlock);
            if (!blocksLocation.Contains(testBlock))
            {
                emptyCousinBlocks.Add(testBlock);

                
            }
            testBlock1= new Vector3(currentBlock.x + 4, currentBlock.y, currentBlock.z);
            //Debug.Log("test block 1 :" + testBlock1);
            if (!blocksLocation.Contains(testBlock1))
            {
                emptyCousinBlocks.Add(testBlock1);


            }
            testBlock2 = new Vector3(currentBlock.x, currentBlock.y, currentBlock.z-4);
            //Debug.Log("test block 2 :" + testBlock2);
            if (!blocksLocation.Contains(testBlock2))
            {
                emptyCousinBlocks.Add(testBlock2);


            }
            testBlock3 = new Vector3(currentBlock.x, currentBlock.y, currentBlock.z+4);
            //Debug.Log("test block 3 :" + testBlock3);
            if (!blocksLocation.Contains(testBlock3))
            {
                emptyCousinBlocks.Add(testBlock3);


            }
            
            //Debug.Log(emptyCousinBlocks);





            CreateLand(emptyCousinBlocks);



        }

        
        if (yMove == true)
        {

            transform.position = Vector3.MoveTowards(transform.position, target, 0.2f);
            if (Vector3.Distance(transform.position, target) < 0.3f)
            {
                mooving = false;
                yMove = false;
            }
        }




    }
     void CreateLand(List<Vector3> cos)

    {
        foreach (Vector3 bloc in cos)
        {
            //Debug.Log(bloc);
            blocksLocation.Add(bloc);
            primitiveLand.transform.localScale = new Vector3(1, 1, 1);
            primitiveLand.transform.position = bloc;
            Instantiate(primitiveLand);
            Debug.Log("position : " + primitiveLand.transform.position);

        }
        cos.Clear();
        border.transform.position = new Vector3(border.transform.position.x,border.transform.position.y,border.transform.position.z+4);
        
    }

    public Vector3 CreateLand2(Vector3 pos)

    {
        //Debug.Log(pos);
        List<Vector3> blocksLocation1 = new List<Vector3>();
        for (i = 0; i < 40; i = i + 4)
        {
            for (j = 0; j < 24; j = j + 4)
            {
                blocksLocation1.Add(new Vector3(i, 6.0899f, j));
            }
        }
        foreach (Vector3 bloc in blocksLocation1)
        {
            Debug.Log(Mathf.Abs(pos.x - bloc.x));
            if (Mathf.Abs(pos.x- bloc.x)<diff1)
            {
                diff1 = Mathf.Abs(pos.x - bloc.x);
                newX = bloc.x;
                



            }
            Debug.Log(Mathf.Abs(pos.z - bloc.z));
            if (Mathf.Abs(pos.z - bloc.z) < diff2)
            {
                diff2 = Mathf.Abs(pos.z - bloc.z);
                newY = bloc.z;
                

            }

        }

        //Debug.Log(target);

        target = new Vector3(newX,transform.position.y, newY);

        //yMove = true;

        return new Vector3(newX, transform.position.y, newY); 



    }

}
