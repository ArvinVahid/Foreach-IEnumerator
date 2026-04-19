using System.Collections;

Cargo[] cargos = new Cargo[]
{
    new Cargo(1, 5000m),
    new Cargo(2, 6000m),
    new Cargo(3, 7000m),
    new Cargo(4, 8000m)
};


ManualEnumerator enumerator = new ManualEnumerator(cargos);
Console.WriteLine("Starting manual iteration ...");
while (enumerator.MoveNext())
{
    Console.WriteLine($"Cargo ID is {enumerator.Current.id} with Value {enumerator.Current}");
}
Console.WriteLine("Ending manual iteration ...");

public class ManualEnumerator : IEnumerator<Cargo>
{
    private readonly Cargo[] _internalData;
    private int _position;

    public ManualEnumerator(Cargo[] dataToIterate)
    {
        _internalData = dataToIterate;
        _position = -1;
    }

    public bool MoveNext()
    {
        _position++;

        if (_position < _internalData.Length)
            return true;

        return false;
    }

    public void Reset()
    {
        _position = -1;
    }

    object IEnumerator.Current => Current;

    public Cargo Current
    {
        get
        {
            if (_position < 0 || _position >= _internalData.Length)
            {
                throw new InvalidOperationException("Cursor is out of bounds. Call MoveNext() first.");
            }

            return _internalData[_position];
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
public record Cargo(int id, decimal value);
