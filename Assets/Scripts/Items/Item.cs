using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private string itemID;

        private ItemGameData data;

        private void Start()
        {
            if(!GameData.GameData.Instance.TryGetItem(itemID, out data))
            {
                Debug.LogError("No item with this id found :" + itemID);
                Destroy(gameObject);
                return;
            }
        }
        public void Setup(ItemGameData item)
        {
           this.data = item;
        }
    }
}