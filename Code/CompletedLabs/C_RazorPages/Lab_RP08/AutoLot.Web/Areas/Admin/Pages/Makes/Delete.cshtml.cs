// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class DeleteModel(IAppLogging<DeleteModel> appLogging, IMakeRepo repo)
    : BasePageModel<Make, DeleteModel>(appLogging, repo, "Delete")
{
    public void OnGet(int? id) => GetOne(id);
    public IActionResult OnPost(int id) => DeleteOne(id);
}