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
    public float durationTime = 0f;
    void Start()
    {
        Player.PlayerDie.PlayerDying += this.updateDeathUI;
    }
    void updateDeathUI()
    {
        deathTime++;
        deathUI.text = $"Death Time:{deathTime}";
    }
    void updateTimeUI()
    {
        durationTime += Time.deltaTime;
        timeUI.text = $"{durationTime:0}";
    }
    // Update is called once per frame
    void Update()
    {
        updateTimeUI();
    }
}
