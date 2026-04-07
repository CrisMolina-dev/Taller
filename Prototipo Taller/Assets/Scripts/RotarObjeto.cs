using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public float anguloRotacion = 90f;
    public float velocidad = 200f;

    private bool rotando = false;
    private Quaternion rotacionObjetivo;

    public void RotarDerecha()
    {
        if (!rotando)
        {
            rotacionObjetivo = transform.rotation * Quaternion.Euler(0, anguloRotacion, 0);
            rotando = true;
        }
    }

    public void RotarIzquierda()
    {
        if (!rotando)
        {
            rotacionObjetivo = transform.rotation * Quaternion.Euler(0, -anguloRotacion, 0);
            rotando = true;
        }
    }

    void Update()
    {
        if (rotando)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotacionObjetivo,
                velocidad * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, rotacionObjetivo) < 0.1f)
            {
                transform.rotation = rotacionObjetivo;
                rotando = false;
            }
        }
    }
}