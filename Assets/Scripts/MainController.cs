using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public enum eGameState { empty, move, build, command };

    public eGameState cState = eGameState.empty;

    public GameObject gUnit;

    public GameObject tempPortal;
    
    public GameObject prefabPortal;
    
    public int totalPortal;
    protected List<Transform> createdObject;
    protected GameObject friendPortal;

    public static MainController instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            createdObject = new List<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cState != eGameState.build)
		{
            tempPortal.transform.position = new Vector3(0f, 0f, -100f);
		}
    }

    public GameObject createObject()
    {
        GameObject newObject = GameObject.Instantiate(prefabPortal);
        createdObject.Add(newObject.transform);

        if (totalPortal == 0)
		{
            friendPortal = newObject;
		}
        totalPortal++;
        if (totalPortal >= 2)   //finish create adjacent portal
		{
            newObject.GetComponent<Portal>().friendPortal = friendPortal;
            friendPortal.GetComponent<Portal>().friendPortal = newObject;
            friendPortal = null;
            cState = eGameState.empty;
		}
        return newObject;
    }

    public void removeObject(Transform oldObject)
	{
        for (int i = 0; i< createdObject.Count; i++)
		{
            if (oldObject.Equals(createdObject[i])){
                createdObject.RemoveAt(i);
                break;
            }
		}
    }

    public void cleanTempPortal()
    {
        for (int i = createdObject.Count - 1; i >= 0; i--)
        {
            createdObject[i].GetComponent<Portal>().DestroyMyself();
        }
    }

    public void enablePortal()
    {
        for (int i = createdObject.Count - 1; i >= 0; i--)
        {
            createdObject[i].GetComponent<Portal>().disablePortal = false;
        }
    }

    public string GetStateString()
	{
		switch (cState)
		{
            case eGameState.empty: return "";
			case eGameState.move: return "HOLD LEFT CLICK TO DRAG";
            case eGameState.command: return "LEFT CLICK TO MOVE UNIT";
            case eGameState.build: return "LEFT CLICK TO BUILD PORTAL";
            default: return "";
		}
	}
}
