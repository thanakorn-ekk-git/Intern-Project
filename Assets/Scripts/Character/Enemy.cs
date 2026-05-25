using UnityEngine;

namespace Character
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private string id;
        private CharacterGameData data;

        private void Start()
        {
            if (!GameData.GameData.Instance.TryGetCharacter(id, out data))
            {
                Debug.LogError("No character with this id found :" + id);
                Destroy(gameObject);
                return;
            }
        }

        private void DropItems()
        {
            foreach(var item in data.ItemDrops)
            {
                CreateItemDrop(item.Item, item.Amount);
            }
        }

        private void CreateItemDrop(Items.ItemGameData item, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var prefab = Resources.Load<Items.Item>("Items/" + item.ID);
                var go = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
                go.Setup(item);
            }
        }
    }
}