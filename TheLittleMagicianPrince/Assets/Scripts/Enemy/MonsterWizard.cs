using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWizard : MonoBehaviour
{
    [SerializeField] private GameObject originOne;
    [SerializeField] protected EnemyData myData;

    protected Rigidbody _rbMW;
    private Animator _aniMW;

    private bool isAttack = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rbMW = GetComponent<Rigidbody>();
        _aniMW = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate() // Trabajar con fisica usa Fixed
    {
        if (!isAttack)
        {
            Find();
            Move();
        }

    }
    public virtual void Move()
    {
        
        Vector3 direction = Vector3.left;  
        
        _rbMW.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _rbMW.AddForce(direction * myData.speed, ForceMode.Impulse);
        

    }
    public void Find() //Buscar con Ray
    {
        GenereteRay(originOne.transform);
    }
    private void GenereteRay(Transform origen) // Generar Raycast desde el enimigo
    {
        RaycastHit hit;
        if(Physics.Raycast(origen.position, origen.TransformDirection(Vector3.forward), out hit, myData.distanceRay))
        {
            if (hit.transform.CompareTag("Player"))
            {
                isAttack = true;
                _rbMW.velocity = Vector3.zero;
                _aniMW.SetBool("isAttack", isAttack);
            }
        }
    }
    private void DrawRay(Transform origen) //Dibujar la linea del Raycast
    {
        Gizmos.color = Color.red;
        Vector3 direction = origen.TransformDirection(Vector3.forward) * myData.distanceRay;
        Gizmos.DrawRay(origen.position, direction);
    }
    private void OnDrawGizmos() //Metodo para dibujar
    {
        DrawRay(originOne.transform);
    }
}
