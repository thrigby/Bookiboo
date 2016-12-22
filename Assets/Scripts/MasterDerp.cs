using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Networking;

public class MasterDerp : MonoBehaviour {

		public GameObject fnerfenderp;

		public void AwardKill (NetworkInstanceId lastHitBy)
		{
				if (Network.isServer) {
				fnerfenderp = NetworkServer.FindLocalObject (lastHitBy);
//						string blarg = fnerfenderp.GetComponent<NetworkInstanceId> ().ToString();
//						if (blarg == lastHitBy) 
//						{
//							fnerfenderp.GetComponent<SealControl2> ().kills += 1;
//						}
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


