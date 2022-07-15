namespace ElectricCars_NetRom.Models.ViewModel
{
    public class Statistics
    {

        public List<StationStatistics> StationStatistic { get; set; } = null!;



        public string[] GetAllNames()
        {
            var names = new List<string>();
            foreach (StationStatistics statStas in StationStatistic)
            {
                names.Add(statStas.StationName);
            }
            string[] nt = { "ana", "banana" };
            return nt;
           // return string.Join(",", names);

        }
        //        public List<string> GetAllNames()
        //{
        //    var names = new List<string>();
        //    foreach (StationStatistics statStas in StationStatistic)
        //    {
        //        names.Add(statStas.StationName);
        //    }
        //    return names;
        //}

        //public string GetAllPercentages()
        //{
        //    var percentage = new List<string>();
        //    foreach (StationStatistics statStas in StationStatistic)
        //    {
        //        percentage.Add(statStas.OcupationPercentage.ToString());
        //    }
        //    double[] pt = { 20.5, 50 };
        //    return pt;
        //    return string.Join(",", percentage);
        //} 
        
        public double[] GetAllPercentages()
        {
            var percentage = new List<string>();
            foreach (StationStatistics statStas in StationStatistic)
            {
                percentage.Add(statStas.OcupationPercentage.ToString());
            }
            double[] pt = { 20.5, 50 };
            return pt;
        }
    }
}
