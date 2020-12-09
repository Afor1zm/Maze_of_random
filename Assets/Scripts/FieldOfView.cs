using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour 
{
    private Mesh newMesh;
    private MeshFilter meshFilter;
    private List<Vector3> circleVerteices = new List<Vector3>();
    private List<Vector2> uvs = new List<Vector2>();
    private List<int> triangles = new List<int>();
    private MeshCollider meshCollider;

   
    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshFilter = GetComponent<MeshFilter>();
        newMesh = new Mesh();
        meshFilter.mesh = newMesh;
        meshCollider.sharedMesh = newMesh;
        DrawFOW();        
    }

    void DrawFOW()
    {
        float val = 1f / 180f;
        float radius = 6.0f;
        int deltaAngle = 15;

        Vector3 center = Vector3.zero;
        circleVerteices.Add(center);
        uvs.Add(new Vector2(0.5f, 0.5f));
        int triangleCount = 0;

        float x1 = radius * Mathf.Cos(0);
        float y1 = radius * Mathf.Sin(0);
        float z1 = 0;
        Vector3 point1 = new Vector3(x1, y1, z1);
        circleVerteices.Add(point1);
        uvs.Add(new Vector2((x1 + radius) / 2 * radius, (y1 + radius) / 2 * radius));

        for (int i = 0; i < 359; i = i + deltaAngle)
        {
            float x2 = radius * Mathf.Cos((i + deltaAngle) * val);
            float y2 = radius * Mathf.Sin((i + deltaAngle) * val);
            float z2 = 0;
            Vector3 point2 = new Vector3(x2, y2, z2);

            circleVerteices.Add(point2);

            uvs.Add(new Vector2((x2 + radius) / 2 * radius, (y2 + radius) / 2 * radius));

            triangles.Add(0);
            triangles.Add(triangleCount + 2);
            triangles.Add(triangleCount + 1);

            triangleCount++;
            point1 = point2;
        }
        newMesh.RecalculateNormals();
        newMesh.vertices = circleVerteices.ToArray();
        newMesh.triangles = triangles.ToArray();
        newMesh.uv = uvs.ToArray();
    }
}