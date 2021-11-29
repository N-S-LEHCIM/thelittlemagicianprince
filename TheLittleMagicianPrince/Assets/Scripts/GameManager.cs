using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score;
    private int scoreInstanciado;

    //ENUMERACION PUBLICA 
    public enum typesFood { Hamburger };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            score = 0;
            scoreInstanciado = 0;
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
    public void addScore()
    {
        instance.scoreInstanciado += 1;
    }
    public static int GetScore()
    {
        return instance.scoreInstanciado;
    }
}
