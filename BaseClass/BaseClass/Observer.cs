namespace BaseClass
{
    public interface IObserver
    {
        void Update(IObserver subject);
    }
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}