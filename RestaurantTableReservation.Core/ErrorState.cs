namespace RestaurantTableReservation.Core;

public enum ErrorState
{
    RestaurantIsClosed,
    RestaurantNotFound,
    CustomerNotFound,
    CustomerAlreadyExists,
}

public class ServiceError : Exception
{
    public ErrorState Error { get; private set; }

    private ServiceError(ErrorState error)
        => Error = error;

    public static ServiceError OfState(ErrorState error)
        => new ServiceError(error);

    public override string Message
        => Error switch
        {
            ErrorState.RestaurantIsClosed => "restaurant is closed",
            ErrorState.RestaurantNotFound => "no free tables left for reservation",
            _ => "unknown error"
        };
}
