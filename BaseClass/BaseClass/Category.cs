using System;

namespace BaseClass
{
    public class Category : ISubject, IComparable<Category>
    {
        private List<IObserver> eleObservers = new List<IObserver>();
        private static Category CSingletonInstance = null;
        private static readonly object CMyLock = new object();

        #region Constructors and Properties
        public Category()
        {

        }
        public Category(string code)
        {
            this._Code = code;
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
        }
        #endregion

        #region IComparable
        public int CompareTo(Category other)
        {
            if (string.Compare(this.Code, other.Code) > 0)
            {
                return -1;
            }
            if (string.Compare(this.Code, other.Code) < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int CompareTo(object obj)
        {
            if (obj is Category)
            {
                return this.CompareTo(obj as Category);
            }
            else
            {
                return this.ToString().CompareTo(obj.ToString());
            }
        }
        #endregion

        #region ISubject
        public void Attach(IObserver observer)
        {
            this.eleObservers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            this.eleObservers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in eleObservers)
            {
                observer.Update((IObserver)this);
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.Code}";
        }
        public static Category Instance
        {
            get
            {
                lock (CMyLock)
                {
                    if (CSingletonInstance == null)
                    {
                        CSingletonInstance = new Category();
                    }
                    return CSingletonInstance;
                }
            }
        }
        #endregion
    }
}