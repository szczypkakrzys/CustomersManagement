using CustomersManagement.Application.Features.Newsletter.SendEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EmailController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(SendEmailCommand body)
    {
        var response = await _mediator.Send(body);
        return NoContent();
    }


    //// GET: EmailController
    //public ActionResult Index()
    //{
    //    return View();
    //}

    //// GET: EmailController/Details/5
    //public ActionResult Details(int id)
    //{
    //    return View();
    //}

    //// GET: EmailController/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: EmailController/Create
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

    //// GET: EmailController/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: EmailController/Edit/5
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

    //// GET: EmailController/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: EmailController/Delete/5
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
