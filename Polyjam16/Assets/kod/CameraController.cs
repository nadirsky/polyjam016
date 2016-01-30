using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Camera CameraContainer;
    public float zoomingSpeed;
    public float movingSpeed;
    public float borderWidth;
    Vector3 lastMousePos;
    Vector3 move;
    public float sizeMin, sizeMax;

	// Use this for initialization
	void Start ()
    {
        lastMousePos = Input.mousePosition;
        CameraContainer.transform.position = new Vector3(0,0, -(sizeMin + sizeMax) / 2);
    }

    void Update()
    {
        move = new Vector3((Input.mousePosition.x - lastMousePos.x)*movingSpeed, (Input.mousePosition.y - lastMousePos.y)*movingSpeed, -Input.mouseScrollDelta.y*zoomingSpeed);
        move *= CameraContainer.transform.position.y;
        if (!Input.GetMouseButton(1))
        {
            move.x = 0;
            move.y = 0;
        }

        if (CameraContainer.transform.position.x < sizeMin+borderWidth && move.x < 0)
            move.x = 0;
        if (CameraContainer.transform.position.z < sizeMin+borderWidth && move.y < 0)
            move.y = 0;
        if (CameraContainer.transform.position.x > sizeMax-borderWidth && move.x > 0)
            move.x = 0;
        if (CameraContainer.transform.position.z > sizeMax-borderWidth && move.y > 0)
            move.y = 0;
        if (CameraContainer.transform.position.y > (sizeMax-sizeMin)/2 && move.z < 0)
            move.z = 0;
        if (CameraContainer.transform.position.y < 20 && move.z > 0)
            move.z = 0;

        CameraContainer.transform.Translate(move * Time.deltaTime);

        lastMousePos = Input.mousePosition; 
    }
}