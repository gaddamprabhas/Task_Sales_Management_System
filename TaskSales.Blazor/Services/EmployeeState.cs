namespace TaskSales.Blazor.Services
{
    public class EmployeeState
    {
        public event Action? OnChange;

        public void NotifyChanged()
        {
            OnChange?.Invoke();
        }
    }
}
