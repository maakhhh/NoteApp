using System.Diagnostics;
using AutoMapper;
using Core.Domain;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Dto;
using NoteApp.Models;

namespace NoteApp.Controllers;

public class NodeController(ILogger<NodeController> logger, INodeService nodeService, IMapper mapper) : Controller
{
    private readonly ILogger<NodeController> logger = logger;
    
    [HttpGet("/health")]
    public IActionResult HealthCheck()
    {
        return Ok("Healthy");
    }
    
    public async Task<IActionResult> Index()
    {
        var nodes = mapper.Map<List<NodeInListDto>>(await nodeService.GetAll());
        return View(nodes);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Content")] NodeToCreateDto nodeToCreate)
    {
        var node = mapper.Map<Node>(nodeToCreate);
        nodeService.Add(node);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await nodeService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var node = mapper.Map<NodeDetailDto>(await nodeService.GetById(id));
        return View(node);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,Title,Content,CreatedAt")] NodeToEditDto nodeToEdit)
    {
        if (!ModelState.IsValid) return View(nodeToEdit);
        nodeToEdit.UpdatedAt = DateTime.UtcNow;
        await nodeService.Update(mapper.Map<Node>(nodeToEdit));
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var note = await nodeService.GetById(id);
        return View(mapper.Map<NodeToEditDto>(note));
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}