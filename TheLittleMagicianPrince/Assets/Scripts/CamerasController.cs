using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{

    //public GameObject[] cameras;
    [SerializeField] private List<GameObject> cameras;
    [SerializeField] private int indexCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F1))
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);         
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
        }*/
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            indexCamera++;
            if (indexCamera == cameras.Count)
            {
                indexCamera = 0;
            }
            SwitchCameras(indexCamera);
        }
    }
    private void SwitchCameras(int index)
    {   
        for (int i = 0; i < cameras.Count; i++)
        {
            if (i == index)
            {
                cameras[i].SetActive(true);
            }
            else
            {
                cameras[i].SetActive(false);
            }

        }
    }
}
