using UnityEngine.UI;
using UnityEngine;
namespace Sean
{
    public class WaveUI : MonoBehaviour
    {
        [SerializeField]Text waveText;
        [SerializeField] GameObject waveUIGameObject;
        private void Awake()
        {
        
        }

        /// <summary>
        /// 打開敵人波數UI True =打開, False = 關閉
        /// </summary>
        public void OpenOrCloseWaveUI(bool _OpenOrClose)
        {
            if (_OpenOrClose)
            {
                UpdateWaveUI();
            }
            waveUIGameObject.SetActive(_OpenOrClose);
        }
        public void UpdateWaveUI()
        {
            waveText.text = $"- Wave {EnemyManager.Instance.WaveNumber} -"; 
        }
    }
}