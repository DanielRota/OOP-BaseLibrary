using System;

namespace BaseClass
{
    public class BaseClass : IObserver, IDisposable
    {
        private static List<string> eleCodes = new List<string>();
        private static BaseClass SingletonInstance = null;
        private static readonly object MyLock = new object();

        #region Constructors and Properties
        public BaseClass()
        {

        }
        private BaseClass(string code, Category category)
        {
            if (eleCodes.Contains(code))
            {
                throw new Exception("The written Code is alreaduy used.");
            }
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("Code field can't be empty.");
            }

            this._Code = code;
            this.Category = category;
            eleCodes.Add(Code);
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
        }

        private Category _Category;
        public Category Category
        {
            get { return _Category; }
            set
            {
                if (_Category == null)
                {
                    throw new Exception();
                }
                _Category = value;
            }
        }
        #endregion

        #region IDisposable

        private bool Disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {

                }
                eleCodes.Remove(Code);
                Disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        ~BaseClass()
        {
            Dispose(disposing: false);
        }
        #endregion

        #region Observer
        public void Update(IObserver observer)
        {
            Console.WriteLine("Category values has changed.");
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.Code} - {this.Category}";
        }
        public static BaseClass Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (SingletonInstance == null)
                    {
                        SingletonInstance = new BaseClass();
                    }
                    return SingletonInstance;
                }
            }
        }
        #endregion
    }
}