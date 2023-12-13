using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerrainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainController.instance.cState == MainController.eGameState.build)
        {
            //build portal
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 hitPosition = Vector3.zero;

            if (this.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) 
            {
                hitPosition = hit.point;
                hitPosition.y += 1f;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
			{
                if (!EventSystem.current.IsPointerOverGameObject())
				{
                    GameObject newPortal = MainController.instance.createObject();
                    newPortal.transform.position = hitPosition;
                }                    
			}
			else
			{
                GameObject tempObject = MainController.instance.tempPortal;
                tempObject.transform.position = hitPosition;
			}
        }else if (MainController.instance.cState == MainController.eGameState.command)
        {
            //command unit

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Vector3 hitPosition = Vector3.zero;

                    if (this.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
                    {
                        hitPosition = hit.point;
                        MainController.instance.gUnit.GetComponent<UnitAI>().SetTargetPosition(hitPosition);
                    }

                    //GameObject newPortal = MainController.instance.createObject();
                    //newPortal.transform.position = hitPosition;
                }
            }
        }
    }
}
