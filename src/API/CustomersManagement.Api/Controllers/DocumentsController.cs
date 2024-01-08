using CustomersManagement.Application.Features.Documents.Commands.FillDocument;
using CustomersManagement.Application.Features.Documents.Queries.GetAllDocumentsTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: DocumentsController
    [HttpGet]
    public Task<List<DocumentDto>> Get()
    {
        var documents = _mediator.Send(new GetAllDocumentsTemplatesQuery());
        return documents;
    }

    [HttpPost]
    public async Task<IActionResult> FillDocumentForm(FillDocumentCommand data)
    {
        var response = await _mediator.Send(data);
        return NoContent();
    }

    //// GET: DocumentsController/Details/5
    //public ActionResult Details(int id)
    //{
    //    return View();
    //}

    //// GET: DocumentsController/Create
    //public ActionResult Create()
    //{
    //    //todo
    //    //always get document from FileSystem to given localization - for now it's still file system
    //    return View();
    //}

    //// POST: DocumentsController/Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create(IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: DocumentsController/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: DocumentsController/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: DocumentsController/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: DocumentsController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
}
