using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaceManager : MonoBehaviour
{
    public bool pasarNlivel;
    public int indiceNivel;

    void update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CambiarNivel(indiceNivel);
        }

        if (pasarNlivel)
        {
            CambiarNivel(indiceNivel);
        }
    }

    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
