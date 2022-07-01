
namespace ElectricCars_NetRom.Models.DB;
public class StationAndPlugType
{
    public Station StationInstance;
    public List<PlugType> PlugTypeInstance;
    public StationAndPlugType(ElectricCars_NetRomContext _changingStationContext, int StationId)
    {
        StationInstance = _changingStationContext.Stations.FirstOrDefault(s => s.Id == StationId);
        List<Plug> Plugs = _changingStationContext.Plugs.Where(s => s.StationId == StationId);


    }

}

