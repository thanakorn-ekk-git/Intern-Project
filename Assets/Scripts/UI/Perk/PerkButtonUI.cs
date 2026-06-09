using GameManagement;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Perk.UI
{
    public class PerkButtonUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;

        private PerkData data;
        private PerkMenuUI menu;

        public void Setup(PerkData data, PerkMenuUI menu)
        {
            this.data = data;
            this.menu = menu;

            gameObject.name = "Button_" + data.Name;
            Sprite perkIcon = Resources.Load<Sprite>(data.ImagePath);
            if(icon != null)
            {
                icon.sprite = perkIcon;
            }

            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(data.Size, data.Size);
            rect.anchoredPosition= new Vector2(data.Position_x, data.Position_y);

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            menu.Select(data);
        }
    }
}