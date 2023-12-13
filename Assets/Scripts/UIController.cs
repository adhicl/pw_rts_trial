using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI tState;

    public Button bMove;
    public Button bBuild;
    public Button bCommand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("b"))
		{
            onBuildPortalButton();
		}else if (Input.GetKeyUp("m"))
		{
            onMoveButton();
		}else if (Input.GetKeyUp("c"))
		{
            onCommandButton();
		}

        SetStateButton();
    }

    private MainController.eGameState newState;

    public void onBuildPortalButton()
    {
        if (MainController.instance.cState == MainController.eGameState.build && MainController.instance.totalPortal == 1)
		{
            //has not finish build portal
            MainController.instance.cleanTempPortal();
        }
		else
		{
            MainController.instance.totalPortal = 0;
        }
        newState = MainController.eGameState.build;
        onChangeToState();
    }

    public void onMoveButton()
    {
        newState = MainController.eGameState.move;
        onChangeToState();
    }

    public void onCommandButton()
    {
        newState = MainController.eGameState.command;
        onChangeToState();
    }

    protected void onChangeToState()
	{
        if (MainController.instance.cState == newState)
        {
            MainController.instance.cState = MainController.eGameState.empty;
        }
        else
        {
            MainController.instance.cState = newState;
        }
    }

    protected void SetStateButton()
	{
        bMove.image.color = Color.white;
        bBuild.image.color = Color.white;
        bCommand.image.color = Color.white;
        switch (MainController.instance.cState)
		{
            case MainController.eGameState.move: bMove.image.color = Color.blue; break;
            case MainController.eGameState.build: bBuild.image.color = Color.blue; break;
            case MainController.eGameState.command: bCommand.image.color = Color.blue; break;
        }
        tState.text = MainController.instance.GetStateString();
    }
}
