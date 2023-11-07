using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Refrences")]
    public Text debugt;
    public LineRenderer circleRenderer;
    public LineRenderer tagLineRenderer;
    public LineRenderer cameraRenderer;
    public LineRenderer cameraLineRenderer;

    [Header("GeneralSettings")]
    public int bearing = 15;
    public int yaw = 15;

    // [Header("CenterDotSettings")]
    /* [Range(-9, 9)] */
    private int x = -6;
    /* [Range(-4, 4)] */ private int y = 3;
    private Vector3 centerLoc;

    [Header("TagLineSettings")]
    public float length = 1;
    public float width = .1f;
    private Color startColor = Color.red;
    private Color endColor = Color.red;

    [Header("CameraSettings")]
    [Range(-9, 9)] public int cx = 0;
    [Range(-4, 4)] public int cy = 0;
    private Vector3 cameraLoc;
    public int clength = 1;

    private float range;
    private float xloc;
    private float yloc;
    


    public static float ToRadians(float degrees)
    {
        return (float)(degrees * (Mathf.PI / 180.0));
    }

    void Update()
    {
        DrawCenterDot();
        DrawTagLine();
        DrawCamera();
        DrawCameraLine();

        range = Vector3.Distance(cameraLoc, centerLoc);

        xloc = range * Mathf.Cos(ToRadians(bearing) + (ToRadians(180) - (ToRadians(360) - ToRadians(90) - (ToRadians(90) - ToRadians(bearing)) - (ToRadians(90) - ToRadians(yaw)))));
        yloc = range * Mathf.Sin(ToRadians(bearing) + (ToRadians(180) - (ToRadians(360) - ToRadians(90) - (ToRadians(90) - ToRadians(bearing)) - (ToRadians(90) - ToRadians(yaw)))));

        Debug.Log("x: " + xloc);
        Debug.Log("y: " + yloc);

        debugt.text = "range: " + range.ToString(); // + "   x: " + xloc.ToString() + "   y: " + yloc.ToString();*/
    }

    void DrawCenterDot()
    {
        int resolution = 100;
        float radius = 0.097f;

        circleRenderer.loop = true;
        circleRenderer.positionCount = resolution;

        float angle = 0f;

        for (int i = 0; i < resolution; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            centerLoc = new Vector3(x + this.x, y + this.y, 0f);
            circleRenderer.SetPosition(i, centerLoc);

            angle += 2f * Mathf.PI / resolution;
        }
    }

    void DrawTagLine()
    {
        // float yawr = ToRadians(yaw);
        float radius = 0.097f;

        tagLineRenderer.startWidth = width;
        tagLineRenderer.endWidth = width;
        tagLineRenderer.startColor = startColor;
        tagLineRenderer.endColor = endColor;
        /*
        tagLineRenderer.SetPosition(0, new Vector3(centerLoc.x + (length * Mathf.Cos(yawr))-radius, centerLoc.y + (length * Mathf.Sin(yawr)), 0f));
        tagLineRenderer.SetPosition(1, new Vector3(centerLoc.x - (length * Mathf.Cos(yawr))-radius, centerLoc.y - (length * Mathf.Sin(yawr)), 0f));
        */

        tagLineRenderer.SetPosition(0, new Vector3(centerLoc.x + length - radius, centerLoc.y, 0f));
        tagLineRenderer.SetPosition(1, new Vector3(centerLoc.x - length - radius, centerLoc.y, 0f));
    }

    void DrawCamera()
    {
        int resolution = 100;
        float radius = 0.097f;

        cameraRenderer.startColor = Color.black;
        cameraRenderer.endColor = Color.black;

        cameraRenderer.loop = true;
        cameraRenderer.positionCount = resolution;

        float angle = 0f;

        for (int i = 0; i < resolution; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            cameraLoc = new Vector3(x + this.cx, y + this.cy, 0f);
            cameraRenderer.SetPosition(i, cameraLoc);

            angle += 2f * Mathf.PI / resolution;
        }
    }

    void DrawCameraLine()
    {
        float radius = 0.097f;
        cameraLineRenderer.SetWidth(width, width);

        cameraLineRenderer.SetPosition(0, new Vector3(cameraLoc.x - radius, cameraLoc.y, 0f));
        cameraLineRenderer.SetPosition(1, new Vector3(centerLoc.x - radius, centerLoc.y, 0f));
    }
}
