using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TonysGameCont : MonoBehaviour
{
	public GameObject[] tonyji;
	public Vector3 spawnValues;
	public int brojTonyja;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public float speed;
    public string username;

	public GUIText scoreText;

    private int score;
    private int highscore;
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
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetButton ("Cancel"))
        {
            if (score > 0)
            {
                PlayerPrefs.SetInt("tonyScore", score);
                TonysHighscores.AddNewHighscore(username, score);
            }
           
          /*  if (PlayerPrefs.HasKey("tonyHighscore"))
            {
                if (PlayerPrefs.GetInt("tonyHigscore") < PlayerPrefs.GetInt("tonyScore"))
                    PlayerPrefs.SetInt("tonyHighscore", PlayerPrefs.GetInt("tonyScore"));
            }
            else
                PlayerPrefs.SetInt("tonyHighscore", score);*/
        }
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{

			for (int i = 0; i < brojTonyja; i++)
			{
				GameObject balon = tonyji [Random.Range (0, tonyji.Length)];
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
