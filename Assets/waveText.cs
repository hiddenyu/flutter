using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waveText : MonoBehaviour
{
    public int waveNumber = 1;

    public TextMeshProUGUI textMesh;

    void Update() {
        waveNumber = gameManager.Instance.curWave;
        textMesh.text = "Wave " + waveNumber;
    }
}
