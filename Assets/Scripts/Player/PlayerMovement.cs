using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    private float currentMovementSpeed;
    private Vector3 direction;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        currentMovementSpeed = movementSpeed;
        characterController = GetComponent<CharacterController>();
    }

    private void OnDisable() {
        currentMovementSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Move();
    }


    void Inputs() {
        direction = new Vector3(Input.GetAxis("Horizontal"),0f , Input.GetAxis("Vertical"));
        direction = transform.rotation * direction * currentMovementSpeed;
        direction += Vector3.down * 20f;
    }

    void Move() {
        characterController.Move(direction * Time.deltaTime);
    }
}
