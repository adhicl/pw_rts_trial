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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
    }

    public void onBuildPortalButton()
	{
        if (MainController.instance.cState == MainController.eGameState.build)
		{
            MainController.instance.cState = MainController.eGameState.empty;
		}
		else
		{
            MainController.instance.cState = MainController.eGameState.build;
        }
        SetStateButton();
    }

    public void onMoveButton()
    {
        if (MainController.instance.cState == MainController.eGameState.move)
        {
            MainController.instance.cState = MainController.eGameState.empty;
        }
        else
        {
            MainController.instance.cState = MainController.eGameState.move;
        }
        SetStateButton();
    }

    protected void SetStateButton()
	{
        bMove.image.color = Color.white;
        bBuild.image.color = Color.white;
        switch (MainController.instance.cState)
		{
            case MainController.eGameState.move: bMove.image.color = Color.blue; break;
            case MainController.eGameState.build: bBuild.image.color = Color.blue; break;
        }
        tState.text = MainController.instance.GetStateString();
    }
}
