﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - ItemDeleteTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Mvc.TagHelpers;

public class ItemDeleteTagHelper : ItemLinkTagHelperBase
{
    public ItemDeleteTagHelper(
        IActionContextAccessor contextAccessor, 
        IUrlHelperFactory urlHelperFactory) 
        : base(contextAccessor, urlHelperFactory)
    {
        ActionName = nameof(CarsController.DeleteAsync).RemoveAsyncSuffix();
    }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        BuildContent(output,"text-danger","Delete","trash");
    }
}