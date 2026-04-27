using UnityEngine;

public class BloquearMovimiento : MonoBehaviour
{
    public GameObject objetoQueBloquea;

    public static bool bloqueoActivo = false;

    void Update()
    {
        if (objetoQueBloquea != null)
        {
            bloqueoActivo = objetoQueBloquea.activeSelf;
        }
    }
}