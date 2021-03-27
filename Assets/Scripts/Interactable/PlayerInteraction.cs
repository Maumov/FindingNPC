using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float range;
    [SerializeField] Transform playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {

        playerCamera = GetComponentInChildren<Camera>().transform;
    }

    private void OnDisable() {

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Fire1")) {
        if(Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }   
    }


    void Interact() {
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = playerCamera.position;
        ray.direction = playerCamera.forward;
        //Debug.Log(ray.origin);
        //Debug.Log(ray.direction);
        Debug.DrawRay(ray.origin,ray.direction * range, Color.red, 2f);
        if(Physics.Raycast(ray,out hit ,range, layerMask )) {
            //Debug.Log(hit.collider.name);
            InteractionTarget target = hit.collider.GetComponent<InteractionTarget>();
            if(target != null) {
                target.Interact();
            }
        }
    }
}
