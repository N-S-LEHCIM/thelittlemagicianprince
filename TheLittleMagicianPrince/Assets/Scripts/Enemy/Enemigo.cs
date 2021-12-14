using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int _rutina; //Rutina del enemigo
    public float _cronometro; //Tiempo entre rutinas
    public Animator _ani;
    public Quaternion _angulo; //Rotar el enemigo
    public float _grado;

    public GameObject _target;
    public bool atacando;

    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
        _target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }
    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) > 10)
        {
            _ani.SetBool("run", false);
            _cronometro += 1 * Time.deltaTime;
            if (_cronometro >= 4)
            {
                _rutina = Random.Range(0, 2);
                _cronometro = 0;
            }
            switch (_rutina)
            {
                case 0:
                    _ani.SetBool("walk", false);
                    break;

                case 1:
                    _grado = Random.Range(0, 360);
                    _angulo = Quaternion.Euler(0, _grado, 0);
                    _rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, _angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    _ani.SetBool("walk", true);
                    break;

            }
        }
        else
        {
            if(Vector3.Distance(transform.position, _target.transform.position) > 1 && !atacando)
            {
                var lookPos = _target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                _ani.SetBool("walk", false);

                _ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);

                _ani.SetBool("attack", false);
            } 
            else
            {
                _ani.SetBool("walk", false);
                _ani.SetBool("run", false);

                _ani.SetBool("attack", false);
                atacando = true;
            }
        }
    }
    public void Final_Ani()
    {
        _ani.SetBool("attack", false);
        atacando = false;
    }
}
