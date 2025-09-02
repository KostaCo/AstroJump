using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    [SerializeField] GameObject loseScreen;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            loseScreen.SetActive(true);
            Debug.Log("game over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        ScoreUpdate.scoreValue = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
