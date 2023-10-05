using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimeLoop : MonoBehaviour
{
    public static float loopDuration = 600f;
    [SerializeField] Slider timeSlider;
    int startTime = 6;
    int endTime = 12;
    float timeLeft = loopDuration;
    public static float seconds = 0f;
    int currentHour;
    [SerializeField] TextMeshProUGUI time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeLoopCoroutine());
        currentHour = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        currentHour = startTime + (int)(seconds / 60f);
        time.text = currentHour.ToString() + " : " + Mathf.RoundToInt(seconds%60f).ToString("D2");
        timeLeft -= Time.deltaTime;
        timeSlider.value = timeLeft/loopDuration;
    }

    IEnumerator TimeLoopCoroutine()
    {
        yield return new WaitForSeconds(loopDuration);
        SceneManager.LoadScene("Auditorium");
    }
}
