using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 15f;
    public float zoomSpeed = 500f;

    protected float minimalZoom = 5f;
    protected float maximalZoom = 35f;

    protected float speedAutoMove = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (autoMove)
		{
            pos = Vector3.Lerp(pos, targetPos, Time.deltaTime / speedAutoMove);
            autoMoveTime += Time.deltaTime;
            if (autoMoveTime >= speedAutoMove)
			{
                autoMove = false;
			}
		}
		else
        {
            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) ||
                (!EventSystem.current.IsPointerOverGameObject() && MainController.instance.cState == MainController.eGameState.move && Input.GetKey(KeyCode.Mouse0) && Input.mousePosition.y >= (Screen.height * .75f)))
            {
                pos.z += panSpeed * Time.deltaTime;
            }
            else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) ||
                (!EventSystem.current.IsPointerOverGameObject() && MainController.instance.cState == MainController.eGameState.move && Input.GetKey(KeyCode.Mouse0) && Input.mousePosition.y <= (Screen.height * .25f)))
            {
                pos.z -= panSpeed * Time.deltaTime;
            }

            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) ||
                (!EventSystem.current.IsPointerOverGameObject() && MainController.instance.cState == MainController.eGameState.move && Input.GetKey(KeyCode.Mouse0) && Input.mousePosition.x <= (Screen.width * .25f)))
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
            else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) ||
                (!EventSystem.current.IsPointerOverGameObject() && MainController.instance.cState == MainController.eGameState.move && Input.GetKey(KeyCode.Mouse0) && Input.mousePosition.x >= (Screen.width * .75f)))
            {
                pos.x += panSpeed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y -= scroll * Time.deltaTime * zoomSpeed;
            pos.y = Mathf.Clamp(pos.y, minimalZoom, maximalZoom);
        }

        transform.position = pos;
    }

    private Vector3 targetPos;
    private bool autoMove = false;
    private float autoMoveTime = 0f;
    public void MoveCamera(Vector3 iTargetPos)
	{
        //center camera
        iTargetPos.x -= 8f;
        iTargetPos.z -= 10f;
        iTargetPos.y = this.transform.position.y;

        targetPos = iTargetPos;
        autoMove = true;
        autoMoveTime = 0f;
	}
}
