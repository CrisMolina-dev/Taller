using TMPro;
using UnityEngine;

public class KeypadManager2 : MonoBehaviour
{
    public static KeypadManager2 instancia1;

    public TextMeshPro pantallaTexto;

    public int maxDigitos = 4;
    public string codigoCorrecto = "123";

    // ? Lista de objetos a activar
    public GameObject[] objetosAActivar;

    // ? Lista de objetos a desactivar
    public GameObject[] objetosADesactivar;

    private string codigoActual = "";

    private void Awake()
    {
        instancia1 = this;
    }

    public void AgregarNumero(string numero)
    {
        if (codigoActual.Length >= maxDigitos)
            return;

        codigoActual += numero;
        pantallaTexto.text = codigoActual;

        if (codigoActual.Length == maxDigitos)
        {
            VerificarCodigo();
        }
    }

    void VerificarCodigo()
    {
        if (codigoActual == codigoCorrecto)
        {
            Debug.Log("? Código correcto");

            // Activar objetos
            foreach (GameObject obj in objetosAActivar)
            {
                if (obj != null)
                    obj.SetActive(true);
            }

            // Desactivar objetos
            foreach (GameObject obj in objetosADesactivar)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
        else
        {
            Debug.Log("? Código incorrecto");
        }

        Invoke(nameof(BorrarTodo), 0.5f);
    }

    public void BorrarUltimo()
    {
        if (codigoActual.Length > 0)
        {
            codigoActual = codigoActual.Substring(0, codigoActual.Length - 1);
            pantallaTexto.text = codigoActual;
        }
    }

    public void BorrarTodo()
    {
        codigoActual = "";
        pantallaTexto.text = "";
    }
}