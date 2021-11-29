using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;
    // Start is called before the first frame update
    [SerializeField] private string playerName;
    [SerializeField] private bool isVisibleName;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
    public void SetVisibleName(bool newStatus)
    {
        isVisibleName = newStatus;
    }

    public bool GetVisibleName()
    {
        return isVisibleName;
    }

}
