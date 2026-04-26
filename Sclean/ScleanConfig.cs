using Torch;
using Torch.Views;

namespace Sclean
{
    public class ScleanConfig : ViewModel
    {
        public ScleanConfig()
        {
            ParseSubtypes();
        }

        private void ParseSubtypes()
        {
            _protectionSubtypes = _beaconSubtype
                .Split(',')
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .ToList();
        }

        private string _beaconSubtype = "ScrapBeacon";
        [Display(Name = "Beacon Subtype names", Description = "Comma-separated list of subtypes (SubtypeId ends with these)")]
        public string BeaconSubtype
        {
            get => _beaconSubtype;
            set
            {
                SetValue(ref _beaconSubtype, value);
                ParseSubtypes();
            }
        }

        public IReadOnlyList<string> ProtectionSubtypes => _protectionSubtypes;
        private List<string> _protectionSubtypes = new() { "ScrapBeacon" };

        private int _playerRange = 10000;
        [Display(Name = "Player", GroupName = "Protection Range", Description = "Radius of the protection AOE")]
        public int PlayerRange { get => _playerRange; set => SetValue(ref _playerRange, value); }

        private int _scrapBeaconRange = 250;
        [Display(Name = "Scrap Beacon", GroupName = "Protection Range", Description = "Radius of the protection AOE")]
        public int ScrapBeaconRange { get => _scrapBeaconRange; set => SetValue(ref _scrapBeaconRange, value); }
    }
}
