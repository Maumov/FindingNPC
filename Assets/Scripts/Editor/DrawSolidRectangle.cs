using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SolidRectangle))]
public class DrawSolidRectangle : Editor
{
    SolidRectangle t;
    void OnSceneGUI() {
        t = target as SolidRectangle;
        Vector3 pos = t.transform.position;
        Vector3[] verts = t.verts;
        for(int i = 0; i< verts.Length; i++) {
            verts[i] += pos;
        }
        Handles.DrawSolidRectangleWithOutline(verts, new Color(0.5f, 0.5f, 0.5f, 0.1f), new Color(0, 0, 0, 1));

        if(verts.Length < 1) {
            CreateVerts();
        } else {
            for(int i = 0; i < verts.Length; i++) {
                Vector3 temp = Handles.PositionHandle(verts[i], Quaternion.identity);
                t.verts[i] = temp - pos;
                //t.range = Handles.ScaleValueHandle(t.range, posCube, Quaternion.identity, 1.0f, Handles.CubeHandleCap, 1.0f);
            }
        }
    }

    private void OnEnable() {
        t = target as SolidRectangle;
        if(t.verts.Length < 1) {
            CreateVerts();
        }
    }

    void CreateVerts() {
        Vector3 pos = t.transform.position;
        t.verts = new Vector3[]
        {
                new Vector3(pos.x - 1f, pos.y, pos.z - 1f),
                new Vector3(pos.x - 1f, pos.y, pos.z + 1f),
                new Vector3(pos.x + 1f, pos.y, pos.z + 1f),
                new Vector3(pos.x + 1f, pos.y, pos.z - 1f)
        };
    }
}