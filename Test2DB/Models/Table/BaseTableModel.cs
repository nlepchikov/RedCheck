using Test2DB.Models.Row;

namespace Test2DB.Models.Table;

public abstract class BaseTableModel
{
    protected List<RowModel> Rows = new();

    public void SetRow(RowModel row)
    {
        Rows.Add(row);
    }

    public List<RowModel> GetRows()
    {
        return Rows;
    }
}