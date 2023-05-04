using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class wendgionav: MonoBehaviour
{

    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo; 
    public float grado;

    public GameObject Muerto;
    public GameObject Vplayer;

    public GameObject target;

    public UnityEngine.AI.NavMeshAgent agente;
    public float distanciadeataque;
    public float radiodevision;

   

    void Start()
    {
        ani = GetComponent<Animator>();
       
    }

    public void ComportamientoEnemigo()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > radiodevision)
        {
            agente.enabled = false;
        ani.SetBool("run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >=2)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;     
       }
       switch (rutina)
       {
        case 0:
            ani.SetBool("walk", false);
        break;

        case 1:
            grado = Random.Range(0, 360);
            angulo = Quaternion.Euler(0, grado, 0);
            rutina ++;
        break;

        case 2:
            transform.rotation= Quaternion.RotateTowards (transform.rotation, angulo, 0.5f);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime );
            ani.SetBool("walk", true);
        break;
       }
     }
     else 
     {
        var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);

        agente.enabled = true;
        agente.SetDestination(target.transform.position );
        

        ani.SetBool("walk", false);
        ani.SetBool("run", true);
     }
    }

   private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) 
    {
          Muerto.SetActive(true);
    Vplayer.SetActive (true);
    Debug.Log("me mato");
    
    Invoke("CargarEscena", 1.5f);
    }
  

}


void CargarEscena() {
    SceneManager.LoadScene(2);
}

    void Update()
    {
        ComportamientoEnemigo();
    }
}
