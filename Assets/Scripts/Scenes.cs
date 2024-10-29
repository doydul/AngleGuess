using UnityEngine.SceneManagement;

public static class Scenes {
    
    public static void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }
    
    public static void LoadGame() {
        SceneManager.LoadScene("Game");
    }
}