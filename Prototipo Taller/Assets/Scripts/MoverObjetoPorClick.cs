using UnityEngine;

public class MoverObjetoPorClick : MonoBehaviour
{
    [Header("Objeto que se moverá")]
    public Transform objetoAMover;

    [Header("Posición destino")]
    public Vector3 posicionDestino;

    private void OnMouseDown()
    {
        if (objetoAMover != null)
        {
            objetoAMover.position = posicionDestino;
        }
    }
}