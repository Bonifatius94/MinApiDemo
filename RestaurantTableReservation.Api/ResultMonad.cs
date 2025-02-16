using LanguageExt.Common;

namespace RestaurantTableReservation.Api;

internal static class ResultMonadEx
{
    public static Result<T> WrapAsResult<T>(this T orig)
        => new Result<T>(orig);

    public static Result<TOut> ContinueWith<TIn, TOut>(
            this Result<TIn> input, Func<TIn, Result<TOut>> map)
        => input.Match(
            res => map(res),
            err => new Result<TOut>(err)
        );

    public static Result<TOut> ContinueWith<TIn, TOut>(
            this Result<TIn> input, Func<TIn, TOut> map)
        => input.Match(
            res => map(res),
            err => new Result<TOut>(err)
        );

    public static IResult AsHttpResult<TRes>(this Result<TRes> result)
        => result.Match(
            res => Results.Ok(res),
            err => Results.Problem(err.Message)
        );
}
