using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{

    public float _timeScale;//0 to 1 float
    public Slider motionTimeSlider;

    public float max_Value;
    public float currentValue;
    // Start is called before the first frame update
    void Start()
    {
        motionTimeSlider.maxValue = max_Value;
        currentValue = max_Value;
        motionTimeSlider.value = currentValue;
    }

    // Update is called once per frame
    void Update()
    {
        motionTimeSlider.value = currentValue;

        if (Input.GetButton("Fire2")&&currentValue > 0f)
        {
            Time.timeScale = _timeScale;//1 = normal 2 = 2x normal speed 0.5,0.1 slow speed
            currentValue -= 50f * Time.deltaTime;
        }
        else
        {
            Time.timeScale = 1f;
            StartCoroutine(fillSlider());
        }
        if (currentValue <= 0f)
        {
            currentValue = 0f;
        }
    }
    IEnumerator fillSlider()
    {
        if (currentValue < max_Value)
        {
            yield return new WaitForSeconds(2f);
            currentValue += 5f * Time.deltaTime;
        }
        if (currentValue > max_Value)
        {
            currentValue = max_Value;
        }
    }
}
