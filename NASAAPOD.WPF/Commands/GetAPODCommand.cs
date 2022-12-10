using NasaAPOD.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPOD.WPF.Commands;

public class GetAPODCommand : CommandBase
{
    public NasaApodViewModel NasaApodViewModel { get; }

    public GetAPODCommand(NasaApodViewModel nasaApodViewModel)
    {
        NasaApodViewModel = nasaApodViewModel;
    }

    public override void Execute(object? parameter)
    {
        NasaApodViewModel.GetAPODAsync();
    }
}
