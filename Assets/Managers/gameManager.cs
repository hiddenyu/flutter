using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private static gameManager instance;
    public gameStates currentState;
    public static gameManager Instance {
        get {
            if (instance == null) 
                Debug.LogError("game manager is null");
            return instance;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    [SerializeField] private int curWave = 1;
    [SerializeField] private int waveEnemyCount;

    public int getEnemyCount() {
        waveEnemyCount = (int)(System.MathF.Pow(2, (float)(0.5 * curWave)) + 10);
        return waveEnemyCount;
    }

    void Start() {
        currentState = gameStates.START;
    }

    public enum gameStates {
        START,
        RUNNING,
        RESPAWN,
        PAUSED
    }
}
