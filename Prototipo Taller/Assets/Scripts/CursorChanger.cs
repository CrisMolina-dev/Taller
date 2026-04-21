using UnityEngine;
using UnityEngine.InputSystem;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorHover;

    private bool isHovering = false;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (!isHovering)
                {
                    Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);
                    isHovering = true;
                }
                return;
            }
        }

        if (isHovering)
        {
            Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
            isHovering = false;
        }
    }
}