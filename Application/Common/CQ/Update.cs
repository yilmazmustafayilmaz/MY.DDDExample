namespace Application.Common.CQ;

public class Update<TViewModel> : IRequest
{
    public TViewModel ViewModel { get; set; }
    public Update(TViewModel viewmodel) => ViewModel = viewmodel;
}