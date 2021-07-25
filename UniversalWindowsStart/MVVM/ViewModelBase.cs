namespace UniversalWindowsStart.MVVM
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
