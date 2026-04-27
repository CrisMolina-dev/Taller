using UnityEngine;

public class Inspeccionar : MonoBehaviour
{
    public float velocidadRotacion = 200f;
    public float velocidadRetorno = 5f;

    private bool estaSeleccionado = false;
    private bool volverARotacionInicial = false;

    private Quaternion rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        // Detectar click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit))
            {
                if (hit.transform == transform)
                {
                    estaSeleccionado = true;
                }
            }
        }

        // Rotar mientras mantienes click
        if (Input.GetMouseButton(0) && estaSeleccionado && !volverARotacionInicial)
        {
            float movimientoX = Input.GetAxis("Mouse X");
            float movimientoY = Input.GetAxis("Mouse Y");

            transform.Rotate(Vector3.up, -movimientoX * velocidadRotacion * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, movimientoY * velocidadRotacion * Time.deltaTime, Space.World);
        }

        // Soltar click
        if (Input.GetMouseButtonUp(0))
        {
            estaSeleccionado = false;
        }

        // Presionar una vez la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            volverARotacionInicial = true;
        }

        // Retorno suave automático
        if (volverARotacionInicial)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionInicial, Time.deltaTime * velocidadRetorno);

            // Cuando esté casi igual, detener
            if (Quaternion.Angle(transform.rotation, rotacionInicial) < 0.1f)
            {
                transform.rotation = rotacionInicial;
                volverARotacionInicial = false;
            }
        }
    }
}