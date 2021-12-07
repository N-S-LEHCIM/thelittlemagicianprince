using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //SCORE
    public static int score;
    private int scoreInstanciado;

    //ENUMERACION PUBLICA 
    public enum typesFood { Hamburger };

    private PlayerCtrl playerScript;

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
        PlayerCtrl.onDeath += GameOver;
    }

    private void GameOver()
    {
        scoreInstanciado = 0;
        
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
