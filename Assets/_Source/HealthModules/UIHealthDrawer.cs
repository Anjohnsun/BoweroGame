using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    public class UIHealthDrawer : MonoBehaviour
    {
        [SerializeField] private Image _hpBarImage;

        public void InitHPbar(int maxHp, int currentHp)
        {
            //задать количество делений спрайта
            //указать актуальное кол-во хп
        }

        public void Refresh(int currentHp)
        {
            //подумать над тем, как это сделать красиво
            //указать актуальное кол-во хп
        }
    }
}