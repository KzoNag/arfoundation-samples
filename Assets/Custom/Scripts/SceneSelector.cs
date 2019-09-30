using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
	public StringArrayObject sceneNameData;
    public Transform listRoot;
    public SceneSelectItem listItemPrefab;

    public GameObject sceneList;
    public GameObject backButton;

    private string current;

    void Start()
    {
        foreach(var sceneName in sceneNameData.values)
        {
            var item = Instantiate(listItemPrefab, listRoot);

            item.Setup(sceneName);
            item.onClick.AddListener(OnListItemClick);
        }
    }

    void OnListItemClick(GameObject item)
	{
        current = item.name;

        sceneList.SetActive(false);
        backButton.SetActive(true);

        SceneManager.LoadScene(current, LoadSceneMode.Additive);
	}

    public void OnBackButtonClick()
    {
        sceneList.SetActive(true);
        backButton.SetActive(false);

        SceneManager.UnloadSceneAsync(current);

        current = null;
    }
}
