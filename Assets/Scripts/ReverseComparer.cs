using System.Collections;

public class ReverseComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return (new CaseInsensitiveComparer()).Compare(y, x);
    }
}
