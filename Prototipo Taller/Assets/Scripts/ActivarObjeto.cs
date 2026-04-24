using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    public GameObject objetoAActivar;
    public GameObject objetoADesactivar;

    void OnMouseDown()
    {
        // Click sobre este objeto
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }
    }

    void Update()
    {
        // Presionar ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (objetoADesactivar != null)
            {
                objetoADesactivar.SetActive(false);
            }
        }
    }
}