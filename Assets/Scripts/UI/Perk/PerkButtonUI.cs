using UnityEngine;
using UnityEngine.UI;

namespace Perk.UI
{
    public class PerkButtonUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;
        [SerializeField] private RectTransform rectangle;

        private PerkData data;
        private PerkMenuUI menu;

        public void Setup(PerkData data, PerkMenuUI menu)
        {
            this.data = data;
            this.menu = menu;

            gameObject.name = "Button_" + data.ID;
            Sprite perkIcon = Resources.Load<Sprite>(data.ImagePath);
            icon.sprite = perkIcon;

            rectangle.sizeDelta = new Vector2(data.Size, data.Size);
            rectangle.localPosition = new Vector2(data.Position_x, data.Position_y);

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            menu.Select(data);
        }
    }
}