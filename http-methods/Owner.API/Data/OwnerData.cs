namespace Owner.API
{
    public class OwnerData
    {
        public static List<Owner> OwnerList = new List<Owner>()
        {
            new Owner{
                Id = 1,
                Name = "Ahmet",
                Surname = "Ay",
                Date = new DateTime(2001,06,12),
                Description = "Test Description",
                Type = "Type1"
            },
            new Owner{
                Id = 2,
                Name = "Ayşe",
                Surname = "Didim",
                Date = new DateTime(2012,06,01),
                Description = "Example Description",
                Type = "Type2"
            },
            new Owner{
                Id = 3,
                Name = "Luffy",
                Surname = "Aydin",
                Date = new DateTime(2008,01,07),
                Description = "Sample Description",
                Type = "Type3"
            }
        };
    }
}