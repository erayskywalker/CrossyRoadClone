using System.Collections;
using UnityEngine;
using UnityEngine.UI;

    public class WinGameUI : MonoBehaviour
    {
        public Text clickText;
        public Text coinText;

        int clickCount;
        int coinCount;

        public Animator animator;

        private bool isUiUpdated;

        private Coroutine updateUiCoroutine;

        private void Start()
        {
            clickText.text = "";
            coinText.text = "";
        }

        private void Update()
        {
            UpdateUi();
        }

        private void UpdateUi()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("anim")) return;
            if (isUiUpdated) return;

            if (updateUiCoroutine == null)
                updateUiCoroutine = StartCoroutine(ScoreUpdater());

            if (PlayerInputs.LeftClick && updateUiCoroutine != null)
            {
                StopCoroutine(updateUiCoroutine);

                clickText.text = ScoreManager.Instance.CurrentClickPoint.ToString();
                coinText.text = ScoreManager.Instance.CurrentCoin.ToString();
                isUiUpdated = true;
            }
        }

        private IEnumerator ScoreUpdater()
        {
            while (true)
            {
                if (clickCount < ScoreManager.Instance.CurrentClickPoint)
                {
                    clickCount++;
                    clickText.text = clickCount.ToString();
                    yield return new WaitForSeconds(0.2f);
                }
                else break;
            }

            while (true)
            {
                if (coinCount < ScoreManager.Instance.CurrentCoin)
                {
                    coinCount++;
                    coinText.text = coinCount.ToString();
                    yield return new WaitForSeconds(0.2f);
                }
                else if (ScoreManager.Instance.CurrentCoin == 0)
                {
                    coinText.text = coinCount.ToString();
                    break;
                }

                else
                {
                    StopCoroutine(ScoreUpdater());
                    break;
                }
            }
        }

        public void NextLevel()
        {
            Debug.Log("next level is on the way");
        }
    }
