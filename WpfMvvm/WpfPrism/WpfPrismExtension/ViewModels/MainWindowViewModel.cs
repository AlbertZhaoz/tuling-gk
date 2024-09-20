using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Security.Cryptography;
using WpfPrismExtension.Views;

namespace WpfPrismExtension.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManger;
        private readonly IDialogService _dialogService;
        private IRegionNavigationJournal _journal;

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ChangeViewACmd { get; set; }
        public DelegateCommand ChangeViewBCmd { get; set; }
        public DelegateCommand ChangePreviewCmd { get; set; }
        public DelegateCommand ChangeForwardCmd { get; set; }
        public DelegateCommand ShowDialogCmd { get; set; }

        public MainWindowViewModel(IRegionManager regionManger, IDialogService dialogService)
        {
            _regionManger = regionManger;
            _dialogService = dialogService;

            ChangeViewACmd = new DelegateCommand(ChangeViewA);
            ChangeViewBCmd = new DelegateCommand(ChangeViewB);
            ChangePreviewCmd = new DelegateCommand(ChangePreview);
            ChangeForwardCmd = new DelegateCommand(ChangeForward);
            ShowDialogCmd = new DelegateCommand(ChangeDialog);
        }


        private void ChangeDialog()
        {
            _dialogService.ShowDialog("DialogTuling", arg =>
            {
                if (arg.Result == ButtonResult.OK)
                {
                    // 
                }
            });
        }

        private void ChangeForward()
        {
            _journal.GoForward();
        }

        private void ChangePreview()
        {
            _journal.GoBack();

        }

        private void ChangeViewA()
        {
            // 导航传参
            var param = new NavigationParameters();
            param.Add("Tuling", "TulingGkOne");

            // 导航的切换
            this._regionManger.RequestNavigate("ContentRegion", "PageA", arg =>
            {
                _journal = arg.Context.NavigationService.Journal;
            }, param);
        }

        private void ChangeViewB()
        {
            this._regionManger.RequestNavigate("ContentRegion", nameof(ViewB), arg =>
            {
                _journal = arg.Context.NavigationService.Journal;
            });
        }

    }
}
