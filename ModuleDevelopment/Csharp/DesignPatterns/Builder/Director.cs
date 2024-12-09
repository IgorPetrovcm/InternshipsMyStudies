namespace Builder;

public class Director(Builder builder)
{
    private Builder _builder = builder;

    public void Construct(string templat)
    {
        _builder.BuildStart();

        foreach (var ch in templat)
        {
            switch (ch)
            {
                case 'A':
                    builder.BuildPartA();
                    break;
                case 'B':
                    _builder.BuildPartB();
                    break;
                case 'C':
                    _builder.BuildPartC();
                    break;
            }
        }
    }

    public string GetResult()
    {
        return _builder.GetResult();
    }
}