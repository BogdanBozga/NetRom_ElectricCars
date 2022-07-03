using System;
using System.Collections.Generic;
namespace ElectricCars_NetRom.Models.DB;
public class StationAndPlugType
{
    public int StationId { get; set; }
    public string StationName { get; set; } = null!;
    public string StationAdress { get; set; } = null!;
    public string StationCity { get; set; } = null!;
    public string PlugTypeName { get; set; } = null!;
    public int PlugId { get; set; } 



    //select s.Name, s.Adress, s.City, t.Name from Station as s
    //inner join Plug as p on s.ID = p.StationID
    //inner join PlugTypes as t on p.TypeID = t.ID




}

