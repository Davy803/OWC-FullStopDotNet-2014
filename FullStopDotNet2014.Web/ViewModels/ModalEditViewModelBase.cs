namespace FullStopDotNet2014.Web.ViewModels
{
    public class ModalEditViewModelBase<T> : ModalEditViewModelBase
    {
        public T ViewModel { get; set; }
    }

    public class ModalEditViewModelBase
    {
        public string ModalTitle { get; set; }
        public string ModalPostUrl { get; set; }
    }
}