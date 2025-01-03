﻿namespace Interviewbot_API.BuildingBlocks.Application.Common.Paginations;

public class PagedQueryHelper<T> : List<T>
{
    public PageData PageData { get; }

    public PagedQueryHelper(List<T> items, int count, int pageNumber, int pageSize)
    {
        PageData = new PageData(count, pageNumber, pageSize);
        AddRange(items);
    }
}