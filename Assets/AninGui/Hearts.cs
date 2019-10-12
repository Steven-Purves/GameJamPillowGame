using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour {


	public GameObject heart;
	//public Player player;
	List<Heart> heartScript = new List<Heart>();

    public bool reverse;

	void Start () {
		      
		StartCoroutine(InstantiateHearts());
	}

	IEnumerator InstantiateHearts()
	{
		int lives = 3;
		yield return new WaitForSeconds(1);

		for (int i = 0; i < lives; i++)
		{
            GameObject newheart = Instantiate(heart) as GameObject;
            newheart.transform.SetParent(transform, false);

            int dir = reverse ? 20 : -20;

			newheart.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * dir, 0);
            heartScript.Add(newheart.GetComponent<Heart>());

			yield return new WaitForSeconds(0.3f);
        }

	}
	public void AnimateHeart(int healthNum, bool direction)
	{


		heartScript[healthNum].AnimateHeartIn(direction);
	}
}
