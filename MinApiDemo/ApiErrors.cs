namespace MinApiDemo;

public enum ApiErrorState
{
    RestaurantIsClosed,
    InsufficientCapacity
}

public class ApiError : Exception
{
    private ApiErrorState error;
    private ApiError(ApiErrorState error)
        => this.error = error;

    public static ApiError OfState(ApiErrorState error)
        => new ApiError(error);

    public override string Message
        => error switch {
            ApiErrorState.RestaurantIsClosed => "restaurant is closed",
            ApiErrorState.InsufficientCapacity => "no free tables left for reservation",
            _ => "unknown error"
        };
}
