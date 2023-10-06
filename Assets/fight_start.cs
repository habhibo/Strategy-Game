using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight_start : MonoBehaviour
{
    // Start is called before the first frame update
    public void strf()
    {
        GameObject.Find("Player (1)").GetComponent<player_controle>().freeMooving=false;
    }

  
}
