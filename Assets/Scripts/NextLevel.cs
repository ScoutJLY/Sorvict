using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextScene;

    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Door");
            FadeToLevel();
        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(nextScene);
    }
}
