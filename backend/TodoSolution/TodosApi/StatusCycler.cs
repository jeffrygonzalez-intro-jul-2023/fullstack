namespace TodosApi;

public class StatusCycler : IProvideStatusCycling
{
    public TodoListItemResponseModel ProvideNextStatusFrom(TodoListItemResponseModel savedItem)
    {
        return savedItem with {  Status = TodoItemStatus.Now };
    }
}