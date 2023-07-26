namespace TodosApi;

public class StatusCycler : IProvideStatusCycling
{

    public TodoListItemResponseModel ProvideNextStatusFrom(TodoListItemResponseModel savedItem)
    {
        var currentStatus = savedItem.Status;
        var newStatus = currentStatus switch
        {
            TodoItemStatus.Later => TodoItemStatus.Now,
            TodoItemStatus.Now => TodoItemStatus.Waiting,
            TodoItemStatus.Waiting => TodoItemStatus.Completed,
            TodoItemStatus.Completed => TodoItemStatus.Later,
            _ => TodoItemStatus.Later // Talk about this
        };

        return savedItem with { Status = newStatus };
    }
}

public class StatusCyclerTwo : IProvideStatusCycling
{
    
    private static readonly TodoItemStatus[] _statusCycle = new[]
    {
        TodoItemStatus.Later,
        TodoItemStatus.Now,
        TodoItemStatus.Waiting,
        TodoItemStatus.Completed
    };
    public TodoListItemResponseModel ProvideNextStatusFrom(TodoListItemResponseModel savedItem)
    {
        var currentStatus = savedItem.Status;
        var currentStatusIndex = Array.IndexOf(_statusCycle, currentStatus);
        var nextStatusIndex = (currentStatusIndex + 1) % _statusCycle.Length;
        var newStatus = _statusCycle[nextStatusIndex];

        return savedItem with { Status = newStatus };
    }
}