using UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PauseScreen pauseScreenUI;
        private void Update()
        {
            var pauseButtonDown = Input.GetButtonDown("Cancel");
            if (!pauseButtonDown) return;
            if (pauseScreenUI.GameObject().activeSelf)
                pauseScreenUI.ContinueGame();
            else pauseScreenUI.PauseGame();
        }
    }
}