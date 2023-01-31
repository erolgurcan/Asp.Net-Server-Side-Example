using WebApplication1.Model.Dto;

namespace WebApplication1.Data
    {
    public class StoreExample
        {
        public static List<DtoExample> exampleList = new List<DtoExample>
        {
            new DtoExample { Id = 1, Name = "Pool view", Sqft = 100, Occupancy = 4},
            new DtoExample { Id = 2, Name = "Beach View", Sqft = 100, Occupancy = 3 }
        };
        }
    }
