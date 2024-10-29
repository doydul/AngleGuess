using UnityEngine;

public class Main : MonoBehaviour {
    
    void Awake() => DontDestroyOnLoad(gameObject);
    void Start() => Scenes.LoadMenu();
}