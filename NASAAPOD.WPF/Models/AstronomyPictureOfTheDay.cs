using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPOD.WPF.Models
{
    public class AstronomyPictureOfTheDay
    {
        public string Copyright { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public string Media_type { get; set; } = string.Empty;
        public string Service_version { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
