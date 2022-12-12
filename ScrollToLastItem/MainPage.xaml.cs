namespace ScrollToLastItem;

public partial class MainPage : ContentPage
{
	int count = 0;
	MainPageViewModel _vm;

    public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
        _vm = vm;

        this.BindingContext = _vm;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		await _vm.DownloadHistory();
	}

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

	}
}

