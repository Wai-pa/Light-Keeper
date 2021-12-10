using System.Collections;
using UnityEngine;

public class StreetLampController : MonoBehaviour
{
    public GameObject lightMask;
    public GameObject lightEffect;

    public bool triggerFlicker;
    public bool turnOff;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Toggle(false);
    }

    // Update is called once per frame
    void Update()
    {
#if DEBUG
        if (triggerFlicker)
        {
            FlickerOn();
            triggerFlicker = false;
        }

        if (turnOff)
        {
            Toggle(false);
            turnOff = false;
        }
#endif
    }

    public void FlickerOn()
    {
        audioSource.Play();
        StartCoroutine(FlickerOnCoroutine());
    }

    private IEnumerator FlickerOnCoroutine()
    {
        Toggle(true);

        yield return new WaitForSeconds(0.2f);

        Toggle(false);

        yield return new WaitForSeconds(0.2f);

        Toggle(true);
        
        yield return new WaitForSeconds(0.1f);

        Toggle(false);

        yield return new WaitForSeconds(0.1f);

        Toggle(true);

        yield return new WaitForSeconds(0.1f);

        Toggle(false);

        yield return new WaitForSeconds(0.1f);

        Toggle(true);
    }

    private void Toggle(bool isOn)
    {
        lightMask.SetActive(isOn);
        lightEffect.SetActive(isOn);
    }
}
