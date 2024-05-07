using Test2DB.Models.Row;

namespace Test2DB.Models.Table;

public class LevelRisksBaseTableModel: BaseTableModel
{
    private RowModel _levelRiskRow = new LevelRisksRowModel();
    
    public void SetRow(RowModel row)
    {
        _levelRiskRow = row;
    }

    public List<RowModel> GetRows()
    {
        return new List<RowModel>() { _levelRiskRow };
    }
}