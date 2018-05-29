using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] baloni;
	public Vector3 spawnValues;
	public int brojBalona;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public float speed;

	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText scoreText;

	private bool gameOver;
	private bool restart;
    private string username;
    private int score;
    private int highscore;
    private AudioSource sound;

	void Start()
	{
        sound = GetComponent<AudioSource>();
        gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
        username = PlayerPrefs.GetString("player");
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
        InvokeRepeating("SpeedUp", 15.0f, 15.0f);
    }

	void Update()
	{
		if (restart)
            if ((Input.touchCount > 0) || Input.GetButton("Fire1") || Input.GetMouseButtonDown(0))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown (KeyCode.Escape) || Input.GetButton ("Cancel"))
        {
            if (score > 0)
            {
                PlayerPrefs.SetInt("normalScore", score);
                Highscores.AddNewHighscore(username, score);
            }

           /* if (PlayerPrefs.HasKey("normalHighscore"))
            {
                if (PlayerPrefs.GetInt("normalHigscore") < PlayerPrefs.GetInt("normalScore"))
                    PlayerPrefs.SetInt("normalHighscore", PlayerPrefs.GetInt("normalScore"));
            }
            else
                PlayerPrefs.SetInt("normalHighscore", score);*/
        }
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			
			for (int i = 0; i < brojBalona; i++)
				{
					GameObject balon = baloni [Random.Range (0, baloni.Length)];
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (balon, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
				
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Tap to restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

    void SpeedUp()
    {
        sound.Play();
        speed += 0.05f;
    }

    public void GameOver()
	{
        if (score > 0)
        {
            PlayerPrefs.SetInt("normalScore", score);
            Highscores.AddNewHighscore(username, score);
        }

       /* if (PlayerPrefs.HasKey("normalHighscore"))
        {
            if (PlayerPrefs.GetInt("normalHigscore") < PlayerPrefs.GetInt("normalScore"))
                PlayerPrefs.SetInt("normalHighscore", PlayerPrefs.GetInt("normalScore"));
        }
        else
            PlayerPrefs.SetInt("normalHighscore", score);*/

        gameOverText.text = "Game over";
		gameOver = true;
	}
}
