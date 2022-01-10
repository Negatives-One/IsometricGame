using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 0;
    private Vector2 screenSize = new Vector2(0, 0);
    private Vector3 mousePos = new Vector3(0, 0, 0);

    [SerializeField]
    private float rightAndTopLimit = 0;
    [SerializeField]
    private float leftAndBottomLimit = 0;

    [SerializeField]
    private CameraStates currentState;

    enum CameraStates { Free, Stoped };

    [SerializeField]
    private float zoomLevel = 0;
    [SerializeField]
    private float minZoomLevel = 0;
    [SerializeField]
    private float maxZoomLevel = 0;
    [SerializeField]
    private float zoomMultiplier = 1;


    #region Set & Get
    public float GetZoomLevel
    {
        get { return zoomLevel; }
    }
    public float SetZoomLevel
    {
        set
        {
            zoomLevel = value;

            if (zoomLevel < minZoomLevel)
            {
                zoomLevel = minZoomLevel;
            }

            if (zoomLevel > maxZoomLevel)
            {
                zoomLevel = maxZoomLevel;
            }

        }
    }
    #endregion Set & Get


    void Start()
    {
        currentState = CameraStates.Stoped;
        zoomLevel = Camera.main.orthographicSize;
    }

    void Update()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        mousePos = Input.mousePosition;
        GetInput();
        if (currentState == CameraStates.Free)
        {
            MoveCamera();
        }
        else if(currentState == CameraStates.Stoped)
        {

        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (currentState == CameraStates.Free) currentState = CameraStates.Stoped;
            else currentState = CameraStates.Free;
        }
        Zoom(Input.GetAxisRaw("Mouse ScrollWheel"));
    }


    public void Zoom(float ammount)
    {
        SetZoomLevel = Camera.main.fieldOfView - ammount * zoomMultiplier;
        Camera.main.fieldOfView = GetZoomLevel;
    }

    private void MoveCamera()
    {
        if (mousePos.x > screenSize.x * rightAndTopLimit)
        {
            transform.Translate(new Vector3(1, 0, -1).normalized * Time.deltaTime * cameraSpeed, Space.World);
        }

        if (mousePos.x < screenSize.x * leftAndBottomLimit)
        {
            transform.Translate(new Vector3(-1, 0, 1).normalized * Time.deltaTime * cameraSpeed, Space.World);
        }

        if (mousePos.y > screenSize.y * rightAndTopLimit)
        {
            transform.Translate(new Vector3(1, 0, 1).normalized * Time.deltaTime * cameraSpeed, Space.World);
        }

        if (mousePos.y < screenSize.y * leftAndBottomLimit)
        {
            transform.Translate(new Vector3(-1, 0, -1).normalized * Time.deltaTime * cameraSpeed, Space.World);
        }
    }
}
