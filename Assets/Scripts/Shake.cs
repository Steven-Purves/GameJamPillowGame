using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

	public IEnumerator ShakeMe(float duration, float magitude)
	{
		Vector3 originalPos = transform.localPosition;
		float elapsed = 0.0f;
		while(elapsed < duration)
		{
			float x = Random.Range(-3f, 3f) * magitude;
			float y = Random.Range(-0f, 0f) * magitude;

			Vector3 here;
			here = new Vector3(x, originalPos.y, originalPos.z);
			transform.localPosition = Vector3.Lerp(transform.localPosition, here, 2f);
            
			elapsed += Time.deltaTime;

			yield return null;
		}
		transform.localPosition = originalPos;
	}

}
