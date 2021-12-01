using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    //INFORMACION DE INTERES
    [SerializeField]  private string EnemyName;

    [SerializeField] public int life;
    [SerializeField] public float speed;
    [SerializeField] public float distanceRay;

}
