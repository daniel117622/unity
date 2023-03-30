using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerAndScore : MonoBehaviour
{
    public GameObject o_timer;
    public GameObject o_score;

    private TextMeshProUGUI time;
    private TextMeshProUGUI score;

    public static int _score;
    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        time = o_timer.GetComponent<TextMeshProUGUI>();
        score = o_score.GetComponent<TextMeshProUGUI>();
        _time = 0;
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _time = _time + Time.deltaTime;
        time.text = ((int)(256 - _time)).ToString();
        score.text = _score.ToString("D8");
    }
}
