using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BoundaryHit : MonoBehaviour
{
    public float delayBeforeGameOver = 1f; // Delay before scene transition
    private ScoreCalculator scoreCalculator;

    private void Start()
    {
        // Find ScoreCalculator dynamically (new Unity method)
        scoreCalculator = Object.FindFirstObjectByType<ScoreCalculator>();

        if (scoreCalculator == null)
        {
            Debug.LogError("ScoreCalculator script not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreCalculator.GameOver();
        // Debug.Log("Boundary Hit");

        // // Stop all game movement
        // Time.timeScale = 0f;

        // // Stop the background music
        // GameObject bgMusicObject = GameObject.FindGameObjectWithTag("Bgsound");
        // if (bgMusicObject != null)
        // {
        //     AudioSource bgMusic = bgMusicObject.GetComponent<AudioSource>();
        //     bgMusic.Stop();
        // }

        // // Play the collision sound
        // GameObject hitSoundObject = GameObject.FindGameObjectWithTag("Hitsound");
        // if (hitSoundObject != null)
        // {
        //     AudioSource hitSound = hitSoundObject.GetComponent<AudioSource>();
        //     hitSound.Play();
        // }
        // else
        // {
        //     Debug.LogWarning("No AudioSource with tag 'Hitsound' found!");
        // }

        // // Get the score safely
        // if (scoreCalculator != null)
        // {
        //     int score = scoreCalculator.getScore();
        //     PlayerPrefs.SetInt("FinalScore", score); // Save score before switching scene
        //     PlayerPrefs.Save();
        // }
        // else
        // {
        //     Debug.LogError("ScoreCalculator reference is null!");
        // }

        // // Wait and then load GameOver scene
        // StartCoroutine(LoadGameOverScene());
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSecondsRealtime(delayBeforeGameOver);
        SceneManager.LoadScene("GameOver");
    }
}
