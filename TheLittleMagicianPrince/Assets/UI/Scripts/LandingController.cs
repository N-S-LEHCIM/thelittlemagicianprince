using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    [SerializeField] private InputField InputUserName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnChangeInputUsername()
    {
        Debug.Log("CHANGE");
        Debug.Log(InputUserName.text);
    }
    public void OnEndEditInputUsername()
    {
        Debug.Log("END EDIT");
 
        ProfileManager.instance.SetPlayerName(InputUserName.text);
        Debug.Log("Username Guardado" + ProfileManager.instance.GetPlayerName());
    }
    public void OnChangeToggleName(bool newStatus)
    {
        Debug.Log("DINAMICO END" + newStatus);
        ProfileManager.instance.SetVisibleName(newStatus);
        Debug.Log("NEW PLAYER NAME " + ProfileManager.instance.GetVisibleName());
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Level 1");
    }
}
