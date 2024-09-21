using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_screen : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    private void Start()
    {

        StartCoroutine(LoadLevelAsync());
    }
    IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2);
        while (!asyncOperation.isDone)
        {
            _progressBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
