// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - ITemporalTableBaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/01
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

public interface ITemporalTableBaseRepo<T> : IBaseRepo<T> where T : BaseEntity, new()
{
    IEnumerable<TemporalViewModel<T>> GetAllHistory();
    IEnumerable<TemporalViewModel<T>> GetHistoryAsOf(DateTime dateTime);
    IEnumerable<TemporalViewModel<T>> GetHistoryBetween(DateTime startDateTime, DateTime endDateTime);
    IEnumerable<TemporalViewModel<T>> GetHistoryContainedIn(DateTime startDateTime, DateTime endDateTime);
    IEnumerable<TemporalViewModel<T>> GetHistoryFromTo(DateTime startDateTime, DateTime endDateTime);
}