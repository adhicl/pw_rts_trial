using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Material mTransparent;
    public Material mSolid;

    private float timeAlive;
    private bool isNotAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        if (MainController.instance.totalPortal < 2)
        {
            this.GetComponent<MeshRenderer>().material = mTransparent;
            isNotAlive = true;
		}
		else
		{
            this.GetComponent<MeshRenderer>().material = mSolid;
            isNotAlive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (isNotAlive)
		{
            if (MainController.instance.totalPortal >= 2)   //auto change material
            {
                this.GetComponent<MeshRenderer>().material = mSolid;
                isNotAlive = false;
            }
		}
		else
		{
            timeAlive += Time.deltaTime;
            if (timeAlive >= 10f)   //10 sec destroy
			{
                MainController.instance.removeObject(this.transform);
                Destroy(this.gameObject);
            }
		}

    }

    public void DestroyMyself()
	{
        if (isNotAlive)
		{
            MainController.instance.removeObject(this.transform);
            Destroy(this.gameObject);
		}
	}

}
