using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
