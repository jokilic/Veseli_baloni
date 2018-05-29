using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CasualGameCont : MonoBehaviour
{
	public GameObject[] baloni;
	public Vector3 spawnValues;
	public int brojBalona;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public float speed;

    public GUIText scoreText;

    private int score;
    private int highscore;
    private string username;
    private AudioSource sound;

	void Start()
	{
        sound = GetComponent<AudioSource>();
        score = 0;
        username = PlayerPrefs.GetString("player");
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
        InvokeRepeating("SpeedUp", 15.0f, 15.0f);
    }

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetButton("Cancel"))
        {
            if (score > 0)
            {
                PlayerPrefs.SetInt("casualScore", score);
                CasualHighscores.AddNewHighscore(username, score);
            }
           
          /*  if (PlayerPrefs.HasKey("casualHighscore"))
            {
                if (PlayerPrefs.GetInt("casualHigscore") < PlayerPrefs.GetInt("casualScore"))
                    PlayerPrefs.SetInt("casualHighscore", PlayerPrefs.GetInt("casualScore"));
            }
            else
                PlayerPrefs.SetInt("casualHighscore", score);*/
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
		}
	}

	public void AddScore(int newScore)
	{
		score += newScore;
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
}
