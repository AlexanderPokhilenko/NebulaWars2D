using System.Collections.Generic;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Synchronizers
{
    public abstract class AbstractNetworkSynchronizer<TSingleton, TKey, TValue>
        where TSingleton : AbstractNetworkSynchronizer<TSingleton, TKey, TValue>, new()
    {
        public static TSingleton Instance { get; } = new TSingleton();
        private uint _lastDictionaryMessageId;
        protected Dictionary<TKey, TValue> Dictionary = new Dictionary<TKey, TValue>();
        private uint _lastHashSetMessageId;
        protected HashSet<TKey> HashSet = new HashSet<TKey>();
        public bool DictionaryWasProcessed { get; set; } = true;
        public bool HashSetWasProcessed { get; set; } = true;

        public void Clear()
        {
            Dictionary.Clear();
            HashSet.Clear();
            _lastDictionaryMessageId = 0;
            _lastHashSetMessageId = 0;
            DictionaryWasProcessed = true;
            HashSetWasProcessed = true;
        }

        private void RemoveOld()
        {
            if (_lastDictionaryMessageId > _lastHashSetMessageId)
            {
                HashSet.ExceptWith(Dictionary.Keys);
            }
            else
            {
                foreach (var removedId in HashSet)
                {
                    Dictionary.Remove(removedId);
                }
            }

            DictionaryWasProcessed = false;
            HashSetWasProcessed = false;
        }

        public void Remove(IEnumerable<TKey> ids)
        {
            foreach (var id in ids)
            {
                Dictionary.Remove(id);
                HashSet.Remove(id);
            }
        }

        public virtual void HandleDictionary(uint messageId, Dictionary<TKey, TValue> dictionary)
        {
            if (_lastDictionaryMessageId > messageId)
            {
                foreach (var key in Dictionary.Keys)
                {
                    dictionary.Remove(key);
                }
            }
            else
            {
                _lastDictionaryMessageId = messageId;
            }

            foreach (var pair in dictionary)
            {
                Dictionary[pair.Key] = pair.Value;
            }

            RemoveOld();
        }

        public virtual void HandleSet(uint messageId, IEnumerable<TKey> set)
        {
            if (_lastHashSetMessageId < messageId)
            {
                _lastHashSetMessageId = messageId;
            }

            HashSet.UnionWith(set);

            RemoveOld();
        }
    }
}