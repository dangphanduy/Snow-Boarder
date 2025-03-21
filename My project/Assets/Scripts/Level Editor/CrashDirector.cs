using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDirector : MonoBehaviour
{
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip Clip;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindAnyObjectByType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(Clip);
            Invoke("ReloadScene", delayTime);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}   
