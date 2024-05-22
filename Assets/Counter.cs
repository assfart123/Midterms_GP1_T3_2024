using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI chickCountText;
    public TextMeshProUGUI henCountText;
    public TextMeshProUGUI eggCountText;
    public TextMeshProUGUI roosterCountText;

    // Update is called once per frame
    void Update()
    {
        UpdateCount("Chick", chickCountText, "Chicks:\n ");
        UpdateCount("Hen", henCountText, "Hens:\n ");
        UpdateCount("Egg", eggCountText, "Eggs:\n ");
        UpdateCount("Rooster", roosterCountText, "Rooster:\n ");
    }

    void UpdateCount(string tag, TextMeshProUGUI textElement, string label)
    {
        int count = GameObject.FindGameObjectsWithTag(tag).Length;
        textElement.text = label + count.ToString();
    }
}
