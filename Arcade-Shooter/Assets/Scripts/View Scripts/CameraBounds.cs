using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds
{

    public static Bounds GetCameraBounds()
    {
        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float leftBound = mainCamera.transform.position.x - cameraWidth / 2f;
        float rightBound = mainCamera.transform.position.x + cameraWidth / 2f;
        float lowerBound = mainCamera.transform.position.y - cameraHeight / 2f;
        float upperBound = mainCamera.transform.position.y + cameraHeight / 2f;

        return new Bounds(mainCamera.transform.position, new Vector3(cameraWidth, cameraHeight, 0));
    }
    public static float TopBoundary
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, Camera.main.nearClipPlane)).y;
        }
    }

    public static float BottomBoundary
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.nearClipPlane)).y;
        }
    }

    public static float LeftBoundary
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, Camera.main.nearClipPlane)).x;
        }
    }

    public static float RightBoundary
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, Camera.main.nearClipPlane)).x;
        }
    }

}
