using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    void Update()
    {
        updateTimeUI();
    }
}
