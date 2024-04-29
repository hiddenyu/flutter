using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthText : MonoBehaviour
{
    public int livesLeft = 5;
    public TextMeshProUGUI textMesh;

    void Update() {
        textMesh.text = "HP Remaining: " + livesLeft;
    }
}
