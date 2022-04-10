using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BaseClass
{
    public class List<T> : IList<T>, IBaseClass<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    {
        #region BaseClass Methods
        public void BCAdd(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The following item is null: " + nameof(obj));
            }

            this.Add(obj);
        }
        public void BCRemove(List<T> list)
        {
            if (list.Count == 0)
            {
                throw new ArgumentException(nameof(list) + "is empty.");
            }
            else
            {
                foreach (var i in list)
                {
                    if (i is BaseClass)
                    {
                        (i as BaseClass).Dispose();
                    }

                    this.Remove(i);
                }
            }
        }
        public void BCUpdate(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The following item is null: " + (nameof(obj)));
            }

            var index = this.IndexOf(obj);
            this[index] = obj;
        }
        public void BCSaveCSV(IEnumerable<T> list, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(";", props.Select(p => p.Name)));

                foreach (var item in list)
                {
                    writer.WriteLine(string.Join(";", props.Select(p => p.GetValue(item, null))));
                }
            }
        }
        public List<T> BCDeserializeObject<T>(string fileName)
        {
            var objectOut = new List<T>();

            if (string.IsNullOrEmpty(fileName))
            {
                return objectOut;
            }
            try
            {
                var ss = File.ReadAllText(fileName);
                var output = JsonConvert.DeserializeObject<dynamic>(ss);

                foreach (var Record in output)
                {
                    foreach (T data in Record)
                    {
                        objectOut.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

            return objectOut;
        }
        public void BCDivideList(List<T> list1, List<T> list2)
        {
            if (list1 == null || list2 == null)
            {
                throw new ArgumentNullException("One list or more were null.");
            }

            for (var i = 0; i < this.Count() / 2; i++)
            {
                list1[i] = this[i];
            }
            for (var b = this.Count() / 2; b < this.Count(); b++)
            {
                list2[b] = this[b];
            }
        }
        #endregion

        #region Implemented Properties
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();
        public bool IsReadOnly => throw new NotImplementedException();
        public bool IsSynchronized => throw new NotImplementedException();
        public object SyncRoot => throw new NotImplementedException();
        public bool IsFixedSize => throw new NotImplementedException();
        #endregion

        #region Implemented Methods
        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public int Add(object value)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }
        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        public void Remove(object value)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}