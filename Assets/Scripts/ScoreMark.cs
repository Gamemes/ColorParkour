using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScoreMark : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timeUI;
    public Text deathUI;
    public int deathTime = 0;
    private bool isFinished = false;
    public float durationTime = 0f;
    void Start()
    {
        Player.PlayerDie.PlayerDying += this.updateDeathUI;
        ClearanceMenu.onGameFinished += this.onGameFinished;
    }
    void onGameFinished()
    {
        isFinished = true;
        StartCoroutine(PostGameDate("http://110.42.142.7:5556/rankinglist/upload"));
    }
    void updateDeathUI()
    {
        deathTime++;
        deathUI.text = $"Death Time:{deathTime}";
    }
    void updateTimeUI()
    {
        if (!isFinished)
            durationTime += Time.deltaTime;
        timeUI.text = $"{durationTime:0}";
    }
    private void OnDestroy()
    {
        Player.PlayerDie.PlayerDying -= this.updateDeathUI;
        ClearanceMenu.onGameFinished -= this.onGameFinished;
    }
    // Update is called once per frame
    IEnumerator PostGameDate(string url)
    {
        Debug.Log("upload form");
        WWWForm form = new WWWForm();
        form.AddField("name", MyGameManager.instance.currentUserInfo.name);
        form.AddField("finishTime", this.durationTime.ToString());
        form.AddField("deathTimes", deathTime.ToString());
        form.AddField("uniqueName", MyGameManager.instance.currentUserInfo.uniqueName);
        Debug.Log(form);
        using (UnityWebRequest req = UnityWebRequest.Post(url, form))
        {
            yield return req.SendWebRequest();
            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.LogError($"error in upload {req.error}");
            }
            else
            {
                Debug.Log(req.result);
            }
        }
    }
    void Update()
    {
        updateTimeUI();
    }
}
