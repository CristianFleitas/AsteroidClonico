using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //Crear el OBJ en si 
    public GameObject menuPausa;
    public static bool isPaused; //Verdadero o Falso si está pausado
                                 //public static bool isPaused; lo convierte en una variable global 


    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
        //El menu de pausa no estará activo al iniciar
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Si pulsan la P pasaran dos cosas
        {
            if (isPaused) //si está pausado y se presiona P, el juego continua
            {
                ReanudarJuego();
            }
            else //De lo contrario, pausa el juego 
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        menuPausa.SetActive(true);
        //parar el 'ingame clock', detiene las animaciones updates etc.
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ReanudarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
