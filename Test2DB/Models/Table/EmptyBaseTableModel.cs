using Test2DB.Models.Row;

namespace Test2DB.Models.Table;

public class EmptyBaseTableModel: BaseTableModel
{
    public void SetRow(RowModel row)
    {
    }

    public List<RowModel> GetRows()
    {
        return new List<RowModel>() { new EmptyRowModel() };
    }
}