using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaseguridad : MonoBehaviour
{

    public GameObject cuadroseguro;

    void Start()
    {
        
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
{
    
 if (other.CompareTag("Player")) 
    {
    cuadroseguro.SetActive (true);
    Debug.Log("a donde fue?..");  
    }
}
}
