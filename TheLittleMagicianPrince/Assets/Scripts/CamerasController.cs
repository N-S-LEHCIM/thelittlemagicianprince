using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
   
    enum camera { cam1,cam2 };
    public GameObject[] cameras;
    private camera CAM;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool cam1 = Input.GetKeyDown(KeyCode.F1);
        bool cam2 = Input.GetKeyDown(KeyCode.F2);

        switch (CAM)
        {
            case camera.cam1:
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
                break;
            case camera.cam2:
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                break;
            default:
                Debug.Log("<color=#FF0000>ERROR AL ELEGIR NIVEL</color>");
                break;
        }
    }
}
