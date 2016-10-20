using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public int m_ObjectPoolSize = 5;
    public GameObject m_Prefab;
    public GameObject[] m_Pool;

    public NetworkHash128 assetId { get; set; }
    
    public delegate GameObject SpawnDelegate(Vector3 position, NetworkHash128 assetId);
    public delegate void UnSpawnDelegate(GameObject spawned);

		// get assetId on an existing prefab
//NetworkHash128 bulletAssetId = bulletPrefab.GetComponent<NetworkIdentity>().assetId;

// register handlers for an existing prefab you'd like to custom spawn
//ClientScene.RegisterSpawnHandler(bulletAssetId, SpawnBullet, UnSpawnBullet);

// spawn a bullet - SpawnBullet will be called on client.
//NetworkServer.Spawn(gameObject, creatureAssetId);


    void Start()
    {
//		NetworkHash128 bulletAssetId = m_Prefab.GetComponent<NetworkIdentity>().assetId;
        assetId = m_Prefab.GetComponent<NetworkIdentity> ().assetId;
//		m_Prefab.GetComponent<NetworkIdentity> ().RemoveClientAuthority (NetworkConnection conn);
//     	m_Prefab.GetComponent<NetworkIdentity> ().serverOnly = true;
//     	m_Prefab.GetComponent<NetworkIdentity> ().hasAuthority = true;
        m_Pool = new GameObject[m_ObjectPoolSize];
        for (int i = 0; i < m_ObjectPoolSize; ++i)
        {
            m_Pool[i] = (GameObject)Instantiate(m_Prefab, Vector3.up * 5, Quaternion.identity);
            m_Pool[i].name = "PoolObject" + i;
//            m_Pool[i].GetComponent<"weapon"> ().SetActive (true);

            m_Pool[i].SetActive(true);
//			SetUpWeapon(i);
//			SetUpHat(i);
			SetUpGear(i);


//			m_Pool[i].GetComponent<Animator> ().SetLayerWeight (2, 1);
//			m_Pool[i].GetComponent<SealControl2> ().hasAxe = true;
//			m_Pool[i].GetComponent<SealControl2> ().PowerUp_Axe_Callback (true);

        }
        
        ClientScene.RegisterSpawnHandler(assetId, SpawnObject, UnSpawnObject);

    }

    public GameObject GetFromPool(Vector3 position)
    {
        foreach (var obj in m_Pool)
        {
            if (!obj.activeInHierarchy)
            {
                Debug.Log("Activating object " + obj.name + " at " + position);
                obj.transform.position = position;
                obj.SetActive (true);
                return obj;
            }
        }
        Debug.LogError ("Could not grab object from pool, nothing available");
        return null;
    }
    
    public GameObject SpawnObject(Vector3 position, NetworkHash128 assetId)
    {
        return GetFromPool(position);
    }
    
    public void UnSpawnObject(GameObject spawned)
    {
        Debug.Log ("Re-pooling object " + spawned.name);
        spawned.SetActive (false);
    }

    public void SetUpGear (int i)
	{
		int x = Random.Range (1, 10);
		Debug.Log ("SETUP GEAR X = " + x);				
		switch (x) {
			case 1:
			{
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (1, 1);
				m_Pool [i].GetComponent<SealControl2> ().hasOar = true;		
				m_Pool [i].GetComponent<SealControl2> ().netHasOar = true;		
				Debug.Log ("x = 1 oar spawn");
				break;
			}
			case 2:
			{
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (2, 1);
				m_Pool [i].GetComponent<SealControl2> ().hasAxe = true;	
				m_Pool [i].GetComponent<SealControl2> ().netHasAxe = true;
				Debug.Log ("x = 2 axe spawn");			
				break;
			}
			case 3:
			{
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (4, 1);	
//				m_Pool[i].GetComponent<Animator> ().SetLayerWeight (5, 0);
				m_Pool [i].GetComponent<SealControl2> ().hasCutlass = true;
				m_Pool [i].GetComponent<SealControl2> ().netHasCutlass = true;
				Debug.Log ("x = 3 cutlass spawn");
				break;
			}
			case 4:
			{
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (2, 1);
				m_Pool [i].GetComponent<SealControl2> ().hasAxe = true;	
				m_Pool [i].GetComponent<SealControl2> ().netHasAxe = true;
				Debug.Log ("x = 2 axe spawn");			
				break;
			}
			case 5:
			{
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (3, 1);	
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (5, 0);
				m_Pool [i].GetComponent<SealControl2> ().hasTricorn = true;
				m_Pool [i].GetComponent<SealControl2> ().netHasTricorn = true;
				Debug.Log ("x = 4 tricorn spawn");
				break;
			}
			case 6:
			{
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (3, 0);	
				m_Pool [i].GetComponent<Animator> ().SetLayerWeight (5, 1);
				m_Pool [i].GetComponent<SealControl2> ().hasFrogmouth = true;
				m_Pool [i].GetComponent<SealControl2> ().netHasFrogmouth = true;
				Debug.Log ("x = 6 frogmouth spawn");
				break;
			}
//			case 7:
//			{


		}		
    }
	

    public void SetUpWeapon (int i)
	{
		int x = Random.Range (1, 5);
		if (x == 1) {
			m_Pool [i].GetComponent<Animator> ().SetLayerWeight (1, 1);
			m_Pool [i].GetComponent<SealControl2> ().hasOar = true;		
			m_Pool [i].GetComponent<SealControl2> ().netHasOar = true;		
			Debug.Log ("x = 1 oar spawn");
		}
		if (x == 2) {
			m_Pool [i].GetComponent<Animator> ().SetLayerWeight (2, 1);
			m_Pool [i].GetComponent<SealControl2> ().hasAxe = true;	
			m_Pool [i].GetComponent<SealControl2> ().netHasAxe = true;
			Debug.Log ("x = 2 axe spawn");			
		}
		if (x == 3) {	
			m_Pool [i].GetComponent<Animator> ().SetLayerWeight (4, 1);	
//			m_Pool[i].GetComponent<Animator> ().SetLayerWeight (5, 0);
			m_Pool [i].GetComponent<SealControl2> ().hasCutlass = true;
			m_Pool [i].GetComponent<SealControl2> ().netHasCutlass = true;
			Debug.Log ("x = 3 cutlass spawn");
		} else {
		}
	}

	public void SetUpHat (int i)
	{
		int y = Random.Range (1, 3);
		if (y == 1) {
			m_Pool [i].GetComponent<Animator> ().SetLayerWeight (3, 1);	
			m_Pool [i].GetComponent<Animator> ().SetLayerWeight (5, 0);
			m_Pool [i].GetComponent<SealControl2> ().hasTricorn = true;
			m_Pool [i].GetComponent<SealControl2> ().netHasTricorn = true;
			Debug.Log ("y = 1 tricorn spawn");
		}
		if (y == 2) {
			m_Pool [i].GetComponent<Animator> ().SetLayerWeight (3, 0);	
			m_Pool [i].GetComponent<Animator> ().SetLayerWeight (5, 1);
			m_Pool [i].GetComponent<SealControl2> ().hasFrogmouth = true;
			m_Pool [i].GetComponent<SealControl2> ().netHasFrogmouth = true;
			Debug.Log ("y = 2 frogmouth spawn");
		} else {
		}
	}
}