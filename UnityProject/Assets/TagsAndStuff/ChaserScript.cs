using UnityEngine;
using System.Collections;

public class ChaserScript : MonoBehaviour {

	GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		target = FindClosestGameObjectWithTag("Target");

		if (target != null) 
		{
			transform.LookAt (target.transform.position);
			transform.position += (transform.forward * 1.1f);
		}
	}

	GameObject FindClosestGameObjectWithTag(string tagToFind)
	{
		GameObject result = null;
		GameObject[] allObjects = GameObject.FindGameObjectsWithTag(tagToFind);
		
		foreach (GameObject current in allObjects)
		{
			if (current != this.gameObject)
			{
				if (result == null)
				{
					result = current;
				} 
				else
				{
					if (Vector3.Distance(transform.position, result.transform.position) > Vector3.Distance(transform.position, current.transform.position))
					{
						result = current;
					}
				}
			}
		}
		return result;
	}
}
