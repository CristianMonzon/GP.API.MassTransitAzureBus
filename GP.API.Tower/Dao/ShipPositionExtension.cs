using GP.API.Model;

namespace GP.API.Tower.Dao
{
    public static class ShipPositionExtension
    {
        public static ShipPositionUpdatedDao ToDao(this ShipPosition ship)
        {
            return new ShipPositionUpdatedDao
            {
                Id = ship.Id,
                MMSI = ship.MMSI,
                Speed = ship.Speed,
                Longitude = ship.Longitude,
                Latitude = ship.Latitude,
                EventDate = ship.EventDate,
                Heading = ship.Heading,
                CreationDate = ship.CreationDate                
            };
        }

        public static ShipPositionResponse ToResponse(this ShipPositionUpdatedDao ship)
        {
            return new ShipPositionResponse
            {
                Id = ship.Id,
                MMSI = ship.MMSI,
                Speed = ship.Speed,
                Longitude = ship.Longitude,
                Latitude = ship.Latitude,
                EventDate = ship.EventDate,
                Heading = ship.Heading,
                CreationDate = ship.CreationDate,
            };
        }

        public static ShipPosition ToShipPosition(this ShipPositionUpdatedDao shipPositionDao)
        {
            return new ShipPosition
            {
                MMSI = shipPositionDao.MMSI,
                EventDate = shipPositionDao.EventDate,
                Heading = shipPositionDao.Heading,
                Latitude = shipPositionDao.Latitude,
                Longitude = shipPositionDao.Longitude,
                Speed = shipPositionDao.Speed,
                CreationDate = shipPositionDao.CreationDate,
            };
        }
    }
}
