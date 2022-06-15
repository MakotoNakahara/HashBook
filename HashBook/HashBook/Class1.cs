using System.Text;
using System.Security.Cryptography;
namespace HashBook
{

    public class Item
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public Item(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
    public class HashSettings
    {
        private static void ShowHashBook(HashSettings hashBook)
        {
            if (hashBook == null) throw new ArgumentNullException(nameof(hashBook));

            foreach (var item in hashBook.Item)
            {
                Console.WriteLine(item.Key);
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"{value.Key} - {value.Value}");
                }
            }
            Console.WriteLine();
        }

        private readonly ushort _maxSize = 65535;

        private Dictionary<string, List<Item>> _item = null;

        public IReadOnlyCollection<KeyValuePair<string, List<Item>>> Item => _item?.ToList()?.AsReadOnly();

        public HashSettings()
        {
            _item = new Dictionary<string, List<Item>>(_maxSize);
        }

        public void Add(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

            var item = new Item(value);
            var hash = GetHash(item.Key);

            List<Item> hashBookItem = null;
            if (_item.ContainsKey(hash))
            {
                hashBookItem = _item[hash];
                var oldKey = hashBookItem.SingleOrDefault(q => q.Key == item.Key);
                if (oldKey != null) throw new ArgumentException($"Not a unique key({hash})", nameof(hash));
                _item[hash].Add(item);
            }
            else
            {
                hashBookItem = new List<Item> { item };
                _item.Add(hash, hashBookItem);
            }
        }

        public void Del(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (key.Length > _maxSize) throw new ArgumentException("Excess key(65535 MAX)");
            var hash = GetHash(key);
            if (!_item.ContainsKey(hash)) return;
            var hashBookItem = _item[hash];
            var item = hashBookItem.SingleOrDefault(q => q.Key == key);
            if (item != null) hashBookItem.Remove(item);
        }
        public string Search(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (key.Length > _maxSize) throw new ArgumentException("Excess key(65535 MAX)");

            var hash = GetHash(key);
            if (!_item.ContainsKey(hash)) return null;

            var hashBookItem = _item[hash];

            if (hashBookItem != null)
            {
                var item = hashBookItem.SingleOrDefault(q => q.Key == key);
                if (item != null) return item.Value;
            }

            return null;
        }
        private string GetHash(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
            if (value.Length > _maxSize) throw new ArgumentException("Excess key(65535 MAX)");
            var md5 = MD5.Create();
            var hashUtf = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            string hash = Convert.ToBase64String(hashUtf);
            return hash;
        }
    }
}