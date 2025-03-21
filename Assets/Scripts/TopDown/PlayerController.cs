using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Mouse mouse;
    private TDCharater tDCharater;

    void Start()
    {
        mouse = Mouse.current;
        tDCharater = GetComponent<TDCharater>();
    }


    void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                tDCharater.MoveTo(hit.point);
            }
        }
    }
}
