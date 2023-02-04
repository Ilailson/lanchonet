using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    //injetando a dependencia no construtor.
    public LancheController
        (
        ILancheRepository lancheRepository, 
        ICategoriaRepository categoriaRepository
        )
    {
        _lancheRepository = lancheRepository;
        _categoriaRepository = categoriaRepository;
    }

    public IActionResult List()
    {
        /*var Lanches = _lancheRepository.Lanches;
        return View(Lanches);//retornando os lanches na view*/

        var lanchesListViewModel = new LancheListViewModel();
        lanchesListViewModel.Lanches = _lancheRepository.Lanches;
        lanchesListViewModel.CategoriaAtual = "Categoria Atual";
        return View( lanchesListViewModel );

    }
    
}
