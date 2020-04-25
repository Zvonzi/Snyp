using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransitionName; // potrebna radi ulaska u novu scenu - omogućava spawnanje igrača na ulaz u scenu
    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        UIFade.instance.FadeToBlack();
        PlayerController.instance.areaTransitionName = areaTransitionName;
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(areaToLoad);
        UIFade.instance.FadeFromBlack();
    }
}
