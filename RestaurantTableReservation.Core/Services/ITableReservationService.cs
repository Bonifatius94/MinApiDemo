using LanguageExt.Common;
using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Services;

public interface ITableReservationService
{
    Result<TableReservation> TryReserve(TableReservationRequest request);
}
