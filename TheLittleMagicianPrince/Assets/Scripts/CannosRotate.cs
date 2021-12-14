using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannosRotate : MonoBehaviour
{
    [SerializeField] private bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rotate());
    }
    IEnumerator Rotate()
    {
        while (isActive)
        {
            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(0.1f);
                transform.Rotate(0, 1f, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
