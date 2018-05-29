using UnityEngine;
using System.Collections;

public class TonysHighscores : MonoBehaviour
{
    const string privateCode = "QNXMVibbike33bYLR6Y50wIVAdo6py5kW3kk8wpNY_GQ";
    const string publicCode = "5855e6068af60310ac364874";
    const string webURL = "http://dreamlo.com/lb/";

    TonysDisplayHighscores highscoreDisplay;
    public Highscore[] highscoresList;
    static TonysHighscores instance;

    void Awake()
    {
        highscoreDisplay = GetComponent<TonysDisplayHighscores>();
        instance = this;
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighscores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/0/10");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoreDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }

}

public struct TonysHighscore
{
    public string username;
    public int score;

    public TonysHighscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
