using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Networking;

public class MasterDerp : MonoBehaviour {


	public void AwardKill (NetworkInstanceId lastHitBy)
	{

		GameObject fnerfenderp;

			if (Network.isServer) 
			{
				fnerfenderp = NetworkServer.FindLocalObject (lastHitBy);
				if (fnerfenderp == null)
					return;
				else
					fnerfenderp.GetComponent<SealControl2> ().kills += 1;
			} 
			else 
			{				
				fnerfenderp = ClientScene.FindLocalObject (lastHitBy);
				if (fnerfenderp == null)
					return;
				else
					fnerfenderp.GetComponent<SealControl2> ().kills += 1;
			}
	}
}


