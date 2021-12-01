using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float speedEnemy = 5.0f;
    [SerializeField] public float liveEnemy = 7.0f;
    [SerializeField] bool isForward = true;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        MoveAfter();
    }
    private void MoveAfter()
    {
        Vector3 direction = (Player.transform.position - transform.position).normalized;
        transform.position += speedEnemy * direction * Time.deltaTime;
    }

    private void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(Player.transform.position - transform.position);
        transform.rotation = newRotation;
    }
}
