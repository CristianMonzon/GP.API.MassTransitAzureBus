using GP.API.Tower.Model;

namespace GP.API.Tower.Dao
{
    public static class ShipExtension
    {
        public static ShipDao ToDao(this Ship ship)
        {
            return new ShipDao
            {
                MMSI = ship.MMSI,
                BuildingDate = ship.BuildingDate,
                Draught = ship.Draught,
                Flag = ship.Flag,
                Length = ship.Length,
                ShipName = ship.ShipName,
                CreationDate = ship.CreationDate,
                ModificationDate = ship.ModificationDate                
            };
        }

        public static Ship ToShip(this ShipDao shipdao)
        {
            return new Ship
            {
                MMSI = shipdao.MMSI,
                BuildingDate = shipdao.BuildingDate,
                Draught = shipdao.Draught,
                Flag = shipdao.Flag,
                Length = shipdao.Length,
                ShipName = shipdao.ShipName,
                CreationDate = shipdao.CreationDate,
                ModificationDate = shipdao.ModificationDate
            };
        }

        public static ShipCreateOrUpdateResponse ToResponse(this ShipDao shipDao)
        {
            return new ShipCreateOrUpdateResponse
            {
                MMSI = shipDao.MMSI,
                ShipName = shipDao.ShipName,
                Flag = shipDao.Flag,
                Draught = shipDao.Draught,
                Length = shipDao.Length,
                BuildingDate = shipDao.BuildingDate,
                CreationDate = shipDao.CreationDate,
                ModificationDate = shipDao.ModificationDate
            };
        }
    }
}
