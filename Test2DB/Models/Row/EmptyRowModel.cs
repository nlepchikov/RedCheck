namespace Test2DB.Models.Row;

public class EmptyRowModel: RowModel
{
    public override bool IsEmpty()
    {
        return true;
    }
}