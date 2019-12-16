using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    private float level;

    public GameObject level1, level2, level3;

	// Use this for initialization
	void Start ()
    {
        //Reset
        PlayerPrefs.SetInt("Score", 3);



        level = PlayerPrefs.GetInt("Score");
        Debug.Log(level);

        if (level > 0)
        {
            level1.SetActive(true);
            if (level > 1)
            {
                level2.SetActive(true);
                if (level > 2)
                {
                    level3.SetActive(true);
                }
            }
        }
    }
}
