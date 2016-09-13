using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_SyncPosition : NetworkBehaviour {

	[SyncVar(hook = "FacingCallback")]
    public bool netFacingRight = true;

//    public bool facingMult;

 	[Command]
    public void CmdFlipSprite(bool facingRight) 
    {
         netFacingRight = facingRight;
         if (netFacingRight)
         {
             Vector3 SpriteScale = transform.localScale;
             SpriteScale.x = 1;
             transform.localScale = SpriteScale;
//            GetComponentInParent<SealControl2>().facingMult = 1;
         }
         else
         {
             Vector3 SpriteScale = transform.localScale;
             SpriteScale.x = -1;
             transform.localScale = SpriteScale;
//			 GetComponentInParent<SealControl2>().facingMult = -1;
         }
     }

     void FacingCallback(bool facingRight)
     {
         netFacingRight = facingRight;
         if (netFacingRight)
         {
             Vector3 SpriteScale = transform.localScale;
             SpriteScale.x = 1;
             transform.localScale = SpriteScale;
//			 GetComponentInParent<SealControl2>().facingMult = 1;
         }
         else
         {
             Vector3 SpriteScale = transform.localScale;
             SpriteScale.x = -1;
             transform.localScale = SpriteScale;
//			 GetComponentInParent<SealControl2>().facingMult = -1;
         }
     }
}
