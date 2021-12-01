using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWizard : MonsterWizard
{
    [SerializeField] private GameObject player;

    public override void Move()
    {
        //base.Move();
        Vector3 playerDirection = GetPlayerDirection();
        _rbMW.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
        _rbMW.AddForce(playerDirection * myData.speed, ForceMode.Impulse);
    } 
    public Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position; //Calcular la componente de desplazamento de donde estoy hasta el player
    }
}
