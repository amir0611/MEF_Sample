namespace MEF.SimpleCalculator
{
    public interface IBinaryOperation : IOperation
    {
        int Operate(int leftData, int rightData);
    }
}