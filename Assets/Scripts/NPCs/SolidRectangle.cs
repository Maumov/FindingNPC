using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidRectangle : MonoBehaviour
{
    public Vector3[] verts;
    private void OnEnable() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetRandomPositionInsideArea() {
        int vert1 = Random.Range(0, verts.Length);//4
        float randomBetweenCenterToVert1 = Random.Range(0f, 1f);
        Vector3 pos1 = Vector3.Lerp(transform.position, verts[vert1], randomBetweenCenterToVert1);
        float random = Random.Range(0,2); // selecting vertex2
        float randomBetweenVert1ToVert2 = Random.Range(0f, 1f);
        Vector3 pos2 = Vector3.zero;
        if(vert1 == 0) {
            if(random == 0) {
                pos2 = Vector3.Lerp(pos1, verts[3], randomBetweenVert1ToVert2);
            }
            if(random == 1) {
                pos2 = Vector3.Lerp(pos1, verts[1], randomBetweenVert1ToVert2);
            }
        }
        if(vert1 == 1) {
            if(random == 0) {
                pos2 = Vector3.Lerp(pos1, verts[0], randomBetweenVert1ToVert2);
            }
            if(random == 1) {
                pos2 = Vector3.Lerp(pos1, verts[2], randomBetweenVert1ToVert2);
            }
        }
        if(vert1 == 2) {
            if(random == 0) {
                pos2 = Vector3.Lerp(pos1, verts[1], randomBetweenVert1ToVert2);
            }
            if(random == 1) {
                pos2 = Vector3.Lerp(pos1, verts[3], randomBetweenVert1ToVert2);
            }
        }
        if(vert1 == 3) {
            if(random == 0) {
                pos2 = Vector3.Lerp(pos1, verts[2], randomBetweenVert1ToVert2);
            }
            if(random == 1) {
                pos2 = Vector3.Lerp(pos1, verts[0], randomBetweenVert1ToVert2);
            }
        }
        return pos2;
    }
}
