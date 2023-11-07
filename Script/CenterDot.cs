using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterDot : MonoBehaviour
{
    [Header("Refrences")]   
    public LineRenderer circleRenderer;
    [Header("Settings")]
    public int resolution = 100;
    [Range(-9,9)] public int x = 0;
    [Range(-4,4)] public int y = 0;
    [Range(0, 0.5f)] private float radius = .097f;

    void Update()
    {
        Draw();
    }


    void Draw()
    {
        circleRenderer.loop = true;
        circleRenderer.positionCount = resolution;

        float angle = 0f;

        for (int i = 0; i < resolution; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            circleRenderer.SetPosition(i, new Vector3(x + this.x, y + this.y, 0f));

            angle += 2f * Mathf.PI / resolution;
        }

    }
}
