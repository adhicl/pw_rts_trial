using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Material mTransparent;
    public Material mSolid;

    private float timeAlive;
    private bool isNotAlive = true;

    public GameObject friendPortal;
    public GameObject effectPortal;

    // Start is called before the first frame update
    void Start()
    {
        if (MainController.instance.totalPortal < 2)
        {
            this.GetComponent<MeshRenderer>().material = mTransparent;
            isNotAlive = true;
            effectPortal.SetActive(false);

        }
		else
		{
            this.GetComponent<MeshRenderer>().material = mSolid;
            isNotAlive = false;
            effectPortal.SetActive(true);

            AudioController.instance.PlaySoundBuild();
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
                effectPortal.SetActive(true);
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

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
            AudioController.instance.PlaySoundPortal();
            MainController.instance.PlayEffectEnter(other.transform.position);
            Vector3 targetTeleport = friendPortal.transform.position + (Vector3.forward * -2f);

            MainController.instance.gUnit.transform.position = targetTeleport;    //add some distance
            MainController.instance.gUnit.GetComponent<UnitAI>().ClearTargetPosition();
            MainController.instance.PlayEffectOut(targetTeleport);
            Camera.main.GetComponent<CameraController>().MoveCamera(targetTeleport);
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
