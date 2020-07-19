using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController controller = null;
    Renderer renderer = null;
    [SerializeField] float movementSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleInvisibility();
        }

        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * movementSpeed);
    }

    void ToggleInvisibility()
    {
        renderer.enabled = !renderer.enabled;
    }
}
