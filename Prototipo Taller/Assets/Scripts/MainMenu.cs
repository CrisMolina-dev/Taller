using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Creditos()
    {
        Application.Quit();
    }

    public void Salir()
    {
        Application.Quit();
    }

    //Salir del menu creditos
    //public void SalirCreditos()
    //{
        //Application.Quit();
    //}
}
