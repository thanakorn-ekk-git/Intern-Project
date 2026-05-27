using Items;
using UnityEngine;

namespace Character
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private string id;
        public CharacterGameData Data { get; private set; }

        private void Start()
        {
            if (!GameData.GameData.Instance.TryGetCharacter(id, out var data))
            {
                Debug.LogError("No character with this id found : " + id);
                Destroy(gameObject);
                return;
            }
            Data = data;
        }

        private void DropItems()
        {
            foreach(var item in Data.ItemDrops)
            {
                CreateItemDrop(item.Item, item.Amount);
            }
        }
        private void CreateItemDrop(ItemGameData item, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var prefab = Item.GetPrefab(item);
                var go = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
                go.Setup(item);
            }
        }

    }
}