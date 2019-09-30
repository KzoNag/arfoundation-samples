using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SceneSelectItem : MonoBehaviour
{
    [System.Serializable]
    public class ItemClickEvent : UnityEvent<GameObject> { }

    public Text label;
    public ItemClickEvent onClick;

    public void Setup(string name)
    {
        this.name = name;
        label.text = name;
    }

    public void OnClick()
    {
        onClick.Invoke(gameObject);
    }
}
