using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabScript : MonoBehaviour
{
    private GameObject Player;
    private GameObject BackPack ;
    bool test = false;
    bool test0 = true;
    float goldHeight;

    public float x=1;
    public float y;
    public float z=1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player (1)");
        goldHeight = Player.GetComponent<player_controle>().goldHeight;
        BackPack = GameObject.FindGameObjectWithTag("realBackPack");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if ((Vector3.Distance(Player.transform.position, transform.position) < 2f) && test0==true)
        {
            transform.rotation = new Quaternion(0,0, 90, 90);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            test = true;
            goldHeight = goldHeight + 0.3f;
            test0 = false;
            Player.GetComponent<player_controle>().goldHeight = Player.GetComponent<player_controle>().goldHeight + 0.280f;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Player.GetComponent<player_controle>().pos = +1;
            Player.GetComponent<player_controle>().x = Player.GetComponent<player_controle>().money + 1;
            Player.GetComponent<player_controle>().changingMoney = true;
            

        }

        if (test)
        {
            
            transform.position = BackPack.transform.position + new Vector3(x, goldHeight, z);
        }
    }
}
