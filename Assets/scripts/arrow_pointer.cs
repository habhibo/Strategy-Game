using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_pointer : MonoBehaviour
{

    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    private GameObject pointer;
    private GameObject base1;
    private GameObject player;
    [SerializeField] private Camera uiCamera;
    private GameObject cam;
    public bool test = false;
    public bool test1 = false;
    // Start is called before the first frame update
    private void Start()
    {

        pointer = GameObject.FindGameObjectWithTag("pointer");
        pointer.SetActive(false);

        uiCamera = GameObject.Find("Camera").GetComponent<Camera>();
        cam = GameObject.Find("Camera");
        cam.SetActive(false);
        
       
        
       
        //GameObject.Find("Camera").SetActive(false);

    }
    private void Awake()
    {
       
            //transform.Find("Pointer").GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (test1)
        {
            fn();
        }
        if (test)
        {
            Vector3 toPosition = targetPosition;
            Vector3 fromPosition = Camera.main.transform.position;
            //Camera.main.transform.position;
            fromPosition.y = 0f;
            Vector3 dir = (toPosition - fromPosition).normalized;
            float angle = (Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg) % 360;

            pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle + 90);

            Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
            bool isOffScreen = targetPositionScreenPoint.x <= 0 || targetPositionScreenPoint.x >= Screen.width || targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y > Screen.height;
            if (isOffScreen && pointer.activeSelf == false)
            {
                pointer.SetActive(true);
            }
            if (isOffScreen == false)
            {
                pointer.SetActive(false);
            }


            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPosition;

            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x + 60, -pointerRectTransform.localPosition.y + 90, 0f);

            if (GetComponent<player_controle>().electunit < 1)
            {
                pointer.SetActive(false);

            }

            if (GetComponent<player_controle>().electunit > 0)
            {
                pointer.SetActive(true);

            }


        }

        




    }
    void fn()
    {


        pointer.SetActive(true);


        //uiCamera = GameObject.FindGameObjectWithTag("cam").transform.FindChild("camera");
        //GameObject.Find("CAM").GetComponent<Camera>();
        base1 = GameObject.Find("Base red");
        targetPosition = new Vector3(base1.transform.position.x, base1.transform.position.z);
        //new Vector3(10, 10, 10);

        pointerRectTransform = pointer.GetComponent<RectTransform>();
        test1 = false;

    }
}
