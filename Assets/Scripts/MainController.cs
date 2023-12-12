using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public enum eGameState { empty, move, build, command };

    public eGameState cState = eGameState.empty;

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
