using LanguageExt;
using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.DAL.Repositories;

public class TableReservationRepository(
    ITableRepository tableRepository,
    IRestaurantRepository restaurantRepository,
    ICustomerRepository customerRepository
) : ITableReservationRepository
{
    private List<Models.TableReservation> reservations = [];

    public async Task<IList<TableReservation>> GetAllReservations(int restaurantId)
    {
        var tableIds = (await tableRepository.GetAllTables(restaurantId)).Select(x => x.TableId).ToList();
        var reservationsOfRestaurant = reservations.Where(x => tableIds.Contains(x.TableId)).ToList();
        return await Task.WhenAll(reservationsOfRestaurant.Select(MapDto));
    }

    public async Task CreateReservation(TableReservation reservation)
    {
        throw new NotImplementedException();
        //reservations.Add(new Models.TableReservation(
        //    reservation.Table.TableId,
        //    reservation.Customer.
        //));
    }

    private async Task<TableReservation> MapDto(Models.TableReservation dbDto)
        => new TableReservation(
            (await restaurantRepository.FindRestaurantById(dbDto.RestaurantId))!,
            (await customerRepository.FindCustomerById(dbDto.CustomerId))!,
            (await tableRepository.GetTable(dbDto.TableId))!,
            dbDto.AmountOfPeople,
            new Timespan(dbDto.From, dbDto.To)
        );
}
