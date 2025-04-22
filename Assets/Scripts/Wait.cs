using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wait : MonoBehaviour
{
    public Slider loadingSlider; // Un slider pour afficher la progression du chargement
    public TextMeshProUGUI loadingText; // Un texte pour afficher des messages de chargement
    public GameObject loadingScreen;

    private void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MonopolyScene");

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // Le chargement est considéré comme terminé à 90%
            loadingSlider.value = progress;
            loadingText.text = "Chargement en cours : " + (progress * 100f).ToString("0") + "%";

            yield return null;

        }
        
            loadingScreen.SetActive(false);
        
        
    }
}
