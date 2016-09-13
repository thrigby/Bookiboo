using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TailTriggerController : NetworkBehaviour {


	[SyncVar(hook = "tailSlapCallback")]
    public bool netTailTrigger = false;

//	public bool tailTrigger = false;
//	public GameObject myTail;

//	public float tailSlapAnimTime = 0.5f;
//	public float tailSlapTimeEnabled = 0.5f;

	[Command]
	public void Cmd_EnableTail (bool tailTrigger)
	{
		netTailTrigger = tailTrigger;
	}

	[Command]
	void Cmd_DisableTail ()
	{
	}

	void tailSlapCallback (bool tailTrigger)
	{
		netTailTrigger = tailTrigger;
	}

	void DisableTail ()
	{
		netTailTrigger = false;
	}

}
