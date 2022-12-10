using NasaAPOD.WPF.Commands;
using NasaAPOD.WPF.Models;
using NasaAPOD.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NasaAPOD.WPF.ViewModels;

public class NasaApodViewModel : ViewModelBase
{
	private string _apiKey;
	private AstronomyPictureOfTheDay _astronomyPictureOfTheDay;

	public string ApiKey
	{
		get
		{
			return _apiKey;
		}
		set
		{
			_apiKey = value;
			OnPropertyChanged(nameof(ApiKey));
			OnPropertyChanged(nameof(CanExecute));
		}
	}

	public AstronomyPictureOfTheDay AstronomyPictureOfTheDay
	{
		get
		{
			return _astronomyPictureOfTheDay;
		}
		set
		{
			_astronomyPictureOfTheDay = value;
			OnPropertyChanged(nameof(AstronomyPictureOfTheDay));
		}
	}

	public bool CanExecute => !string.IsNullOrEmpty(_apiKey);
	public bool HasMadeCall { get; private set; }
	public string Date => _astronomyPictureOfTheDay.Date;
	public string ImageUrl => _astronomyPictureOfTheDay.Url;
	public string Title => _astronomyPictureOfTheDay.Title;
	public string Explanation => _astronomyPictureOfTheDay.Explanation;
	public string Copyright => _astronomyPictureOfTheDay.Copyright;

    public ICommand GetAPODCommand { get; set; }

	public NasaApodViewModel()
	{
		GetAPODCommand = new GetAPODCommand(this);
		AstronomyPictureOfTheDay = new AstronomyPictureOfTheDay
		{
			Copyright = string.Empty,
			Date = string.Empty,
			Url = string.Empty,
			Title = string.Empty,
			Explanation = string.Empty
        };
	}

	public async Task GetAPODAsync()
	{
		AstronomyPictureOfTheDay = await NasaApiService.GetAPOD(ApiKey, AstronomyPictureOfTheDay!);

		if(AstronomyPictureOfTheDay is not null)
		{
			HasMadeCall = true;
            OnPropertyChanged(nameof(ImageUrl));
            OnPropertyChanged(nameof(Explanation));
            OnPropertyChanged(nameof(Copyright));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(Title));
			OnPropertyChanged(nameof(HasMadeCall));
        }
	}
}
