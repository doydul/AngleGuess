using UnityEngine;
using TMPro;

public class Game : MonoBehaviour {
    
    public AngleRenderer anglePrefab1;
    public AngleRenderer anglePrefab2;
    public TMP_Text angleGuessText;
    public TextAnimator messageText;
    public GameObject mainUI;
    public GameObject tryAgainButton;
    
    int actualAngle;
    int angleGuess;
    bool dragging;
    float lastMouseY;
    float dragSum;
    
    public void ConfirmGuess() {
        mainUI.SetActive(false);
        var angleRenderer = Instantiate(anglePrefab2);
        angleRenderer.angle = angleGuess;
        angleRenderer.position = new Vector3(0, 0, 1);
        int diff = Mathf.Abs(actualAngle - angleGuess);
        if (diff == 0) {
            messageText.AnimateText("PERFECT!");
        } else {
            messageText.AnimateText($"YOU WERE {diff} DEGREES OFF");
        }
        tryAgainButton.SetActive(true);
    }
    
    public void Reset() {
        Scenes.LoadGame();
    }
    
    void Start() {
        tryAgainButton.SetActive(false);
        
        actualAngle = 30 + (int)(Random.value * 100);
        var angleRenderer = Instantiate(anglePrefab1);
        angleRenderer.angle = actualAngle;
        
        angleGuessText.text = "0";
        messageText.SetText("");
    }
    
    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            dragging = false;
        }
        
        if (dragging) {
            float delta = Input.mousePosition.y - lastMouseY;
            dragSum += delta * 0.03f;
            if (dragSum < -1) {
                angleGuess -= 1;
                dragSum += 1;
            } else if (dragSum > 1) {
                angleGuess += 1;
                dragSum -= 1;
            }
            angleGuessText.text = "" + angleGuess;
            lastMouseY = Input.mousePosition.y;
        }
        
        if (Input.GetMouseButtonDown(0)) {
            dragging = true;
            lastMouseY = Input.mousePosition.y;
            dragSum = 0;
        }
    }
}