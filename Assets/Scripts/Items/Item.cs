using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private string itemID;

        public ItemGameData Data { get; private set; }

        private void Start()
        {
            if(!GameData.GameData.Instance.TryGetItem(itemID, out var data))
            {
                Debug.LogError("No item with this id found :" + itemID);
                Destroy(gameObject);
                return;
            }
            Data = data;
        }
        public void Setup(ItemGameData item)
        {
           this.Data = item;
        }
    }
}