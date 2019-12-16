using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevel : MonoBehaviour
{
    public string nextScene;
    public bool isDead;
    public int levelSave;
    private int SavedCurrent;

    void Start()
    {
        SavedCurrent = PlayerPrefs.GetInt("Score");
    }

	// Update is called once per frame
	void Update ()
    {
        if (isDead)    
        {
            if (SavedCurrent < levelSave)
            {
                PlayerPrefs.SetInt("Score", levelSave);
            }

            StartCoroutine(BossDied());
        }
    }

    IEnumerator BossDied()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(nextScene);
    }
}
