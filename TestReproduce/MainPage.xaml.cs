using CommunityToolkit.Maui.Core;
using TestReproduce.Popups;

namespace TestReproduce;

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly IPopupService _popupService;

	public MainPage(IPopupService popupService)
	{
		InitializeComponent();
		_popupService = popupService;
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		await _popupService.ShowPopupAsync<TestpopupViewModel>();
	}
}


