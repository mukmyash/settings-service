namespace Settings.Service;

public class ParamsExtracter
{
    enum StateExtracter
    {
        Find = 0,
        FindedDollar = 1,
        ReadParam = 3
    }

    public LinkedList<string> GetParams(ReadOnlySpan<char> value)
    {
        LinkedList<string> result = new LinkedList<string>();

        int startIndex = 0;

        StateExtracter state = StateExtracter.Find;


        int index = 0;
        foreach (var charV in value)
        {
            switch (state)
            {
                case StateExtracter.Find:
                    if (charV == '$')
                    {
                        state = StateExtracter.FindedDollar;
                    }

                    break;
                case StateExtracter.FindedDollar:
                    if (charV == '{')
                    {
                        state = StateExtracter.ReadParam;
                        startIndex = index + 1;
                        break;
                    }

                    if (charV == '$')
                    {
                        state = StateExtracter.FindedDollar;
                        break;
                    }

                    state = StateExtracter.Find;
                    break;
                case StateExtracter.ReadParam:
                    if (charV == '$')
                    {
                        state = StateExtracter.FindedDollar;
                    }

                    if (charV == '}')
                    {
                        state = StateExtracter.Find;
                        result.AddLast(value.Slice(startIndex, index - startIndex).ToString());
                    }

                    break;
            }

            index++;
        }

        return result;
    }
}